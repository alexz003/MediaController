using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Distributor
{
    public partial class SettingsForm : Form
    {
        private Configuration config;

        public String finishedLocation, unfinishedLocation, unsortedLocation;
        public int MaxResults;

        public SettingsForm(Configuration cfg)
        {
            config = cfg;
            
            InitializeComponent();
            initCustom();
            
        }

        private void initCustom()
        {
            finishedShowsTextBox.Text = config.FinishedShowsFolder;
            UnfinishedShowsTextBox.Text = config.UnfinishedShowsFolder;
            UnsortedShowsTextBox.Text = config.UnsortedShowsFolder;
            maxResultsCounter.Value = config.MaxResults;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                finishedShowsTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UnfinishedShowsTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UnsortedShowsTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            finishedLocation = finishedShowsTextBox.Text;
            unfinishedLocation = UnfinishedShowsTextBox.Text;
            unsortedLocation = UnsortedShowsTextBox.Text;
            MaxResults = (int)maxResultsCounter.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
