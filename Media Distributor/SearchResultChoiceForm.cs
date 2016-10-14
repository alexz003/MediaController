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
    public partial class SearchResultChoiceForm : Form
    {
        public DialogResult Result { get; set; }

        private List<TitleData> searchResults;
        public int listIndex;
        public String SearchTitle;

        public SearchResultChoiceForm(List<TitleData> search, String searchTitle)
        {
            SearchTitle = searchTitle;
            searchResults = search;
            InitializeComponent();
            InitializeNewComponents();

        }

        private void updateComponents()
        {
            if (searchResults.Count > 0)
            {
                TitleData item = searchResults.ElementAt(listIndex % searchResults.Count);

                pictureBox.ImageLocation = item.ImageURL;
                pictureBox.Load();
                pictureBox.Update();

                titleLabel.Text = item.Title;
                titleLabel.Update();

                descLabel.Text = item.Synopsis;
                descLabel.Update();
            }
        }

        //Fashion this into our new display with pictures and such
        private void InitializeNewComponents()
        {
            listIndex = 0;

            label1.Text = "Unfortunately, " + SearchTitle + " wasn't found. Please choose from below";
            label1.Update();

            descLabel.MaximumSize = new System.Drawing.Size(panel1.Width - descLabel.Location.X - 25, 0);
            descLabel.AutoSize = true;

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            updateComponents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listIndex++;
            updateComponents();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listIndex == 0)
                listIndex = searchResults.Count - 1;
            else
                listIndex--;

            updateComponents();
        }
    }
}
