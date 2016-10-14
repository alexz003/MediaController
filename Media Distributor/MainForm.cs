using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Distributor
{
    public partial class MainForm : Form
    {
        private Configuration config;
        
        public MainForm(Configuration cfg)
        {
            InitializeComponent();
            config = cfg;
            initCustom();
        }

        public void initCustom()
        {

            ThreadPool.SetMaxThreads(15, 15);

            /****** Form Items ********/
            //ListBox items
            foreach(KeyValuePair<String, String> kvp in config.getTitleList())
                titleListBox.Items.Add(kvp.Key);
            titleListBox.Update();

            //TitleLabel
            titleLabel.MaximumSize = new Size(tableLayoutPanel1.Size.Width, 0);

            //DescriptionLabel
            descriptionLabel.MaximumSize = new System.Drawing.Size(panel3.Width - descriptionLabel.Location.X - 25, 0);

            //PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String item = titleListBox.SelectedItem.ToString();
            titleLabel.Text = item;
            try
            {
                String value;
                config.getTitleList().TryGetValue(item, out value);
                locationLabel.Text = value;

                TitleData td;
                if (config.WebData.TryGetValue(item, out td))
                {
                    titleLabel.Text = td.Title;
                    descriptionLabel.Text = td.Synopsis;
                    pictureBox1.ImageLocation = td.ImageURL;
                    pictureBox1.Load();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void webUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you wish to update your titles with information from the web?", "Web Update", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                List<WebCrawler> crawlers = new List<WebCrawler>();
                List<Thread> workers = new List<Thread>();
                Dictionary<String, TitleData> allTitleData = new Dictionary<string, TitleData>();

                foreach (String title in config.getTitleList().Keys)
                {
                    WebCrawler wc = new WebCrawler();
                    wc.SearchTitle = title;
                    crawlers.Add(wc);
                    ThreadPool.QueueUserWorkItem(a => wc.crawl(title));
                    Thread.Sleep(300);
                    //Thread thread = new Thread(() => wc.crawl(title));
                    //workers.Add(thread);

                    //thread.Start();
                }

                foreach (Thread t in workers)
                {
                    while (t.IsAlive)
                        Thread.Sleep(100);
                }

                foreach (WebCrawler wc in crawlers)
                {
                    if (wc.Result != null)
                    {
                        allTitleData.Add(wc.SearchTitle, wc.Result);
                        Console.WriteLine(wc.Result.Title + ": was added to the list");
                    }
                }
                config.database.saveTitleData(allTitleData);
                config.loadWebData();
            }

        }

        private void localUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to update your list of titles from your folders?", "Local Update", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Navigator nav = new Navigator(config);
                nav.updateTitleList();
                nav.updateTitleListFromFinished();
                config.updateTitleList(nav.getTitleList());
                titleListBox.Items.Clear();
                config.database.saveTitles(config.getTitleList());
                initCustom();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(config);

            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                config.FinishedShowsFolder = sf.finishedLocation;
                config.UnfinishedShowsFolder = sf.unfinishedLocation;
                config.UnsortedShowsFolder = sf.unsortedLocation;
                config.MaxResults = sf.MaxResults;
                config.database.saveConfiguration(sf.finishedLocation, sf.unfinishedLocation, sf.unsortedLocation, sf.MaxResults);
            }
        }
    }
}
