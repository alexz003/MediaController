namespace Media_Distributor
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.titleListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.totalEpsCount = new System.Windows.Forms.Label();
            this.epsAvailableCount = new System.Windows.Forms.Label();
            this.totalEps = new System.Windows.Forms.Label();
            this.epAvailableLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.detailsGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.titleListBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(155, 355);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // titleListBox
            // 
            this.titleListBox.FormattingEnabled = true;
            this.titleListBox.Location = new System.Drawing.Point(3, 3);
            this.titleListBox.Name = "titleListBox";
            this.titleListBox.Size = new System.Drawing.Size(152, 342);
            this.titleListBox.TabIndex = 0;
            this.titleListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.detailsGroupBox);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(165, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 355);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.descriptionLabel);
            this.panel3.Location = new System.Drawing.Point(136, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(497, 264);
            this.panel3.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 13);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(0, 13);
            this.descriptionLabel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.locationLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 320);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 32);
            this.panel2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open Explorer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLabel.Location = new System.Drawing.Point(120, 3);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(33, 24);
            this.locationLabel.TabIndex = 1;
            this.locationLabel.Text = "C:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Location:";
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.totalEpsCount);
            this.detailsGroupBox.Controls.Add(this.epsAvailableCount);
            this.detailsGroupBox.Controls.Add(this.totalEps);
            this.detailsGroupBox.Controls.Add(this.epAvailableLabel);
            this.detailsGroupBox.Location = new System.Drawing.Point(6, 181);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(123, 133);
            this.detailsGroupBox.TabIndex = 3;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "Details";
            // 
            // totalEpsCount
            // 
            this.totalEpsCount.AutoSize = true;
            this.totalEpsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalEpsCount.Location = new System.Drawing.Point(6, 99);
            this.totalEpsCount.Name = "totalEpsCount";
            this.totalEpsCount.Size = new System.Drawing.Size(24, 25);
            this.totalEpsCount.TabIndex = 3;
            this.totalEpsCount.Text = "0";
            // 
            // epsAvailableCount
            // 
            this.epsAvailableCount.AutoSize = true;
            this.epsAvailableCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epsAvailableCount.Location = new System.Drawing.Point(6, 39);
            this.epsAvailableCount.Name = "epsAvailableCount";
            this.epsAvailableCount.Size = new System.Drawing.Size(24, 25);
            this.epsAvailableCount.TabIndex = 2;
            this.epsAvailableCount.Text = "0";
            // 
            // totalEps
            // 
            this.totalEps.AutoSize = true;
            this.totalEps.Location = new System.Drawing.Point(6, 77);
            this.totalEps.Name = "totalEps";
            this.totalEps.Size = new System.Drawing.Size(83, 13);
            this.totalEps.TabIndex = 1;
            this.totalEps.Text = "Total Episodes: ";
            // 
            // epAvailableLabel
            // 
            this.epAvailableLabel.AutoSize = true;
            this.epAvailableLabel.Location = new System.Drawing.Point(6, 16);
            this.epAvailableLabel.Name = "epAvailableLabel";
            this.epAvailableLabel.Size = new System.Drawing.Size(102, 13);
            this.epAvailableLabel.TabIndex = 0;
            this.epAvailableLabel.Text = "Episodes Available: ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(136, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 41);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 35);
            this.titleLabel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 170);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(820, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webUpdateToolStripMenuItem,
            this.localUpdateToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // webUpdateToolStripMenuItem
            // 
            this.webUpdateToolStripMenuItem.Name = "webUpdateToolStripMenuItem";
            this.webUpdateToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.webUpdateToolStripMenuItem.Text = "Web Update";
            this.webUpdateToolStripMenuItem.Click += new System.EventHandler(this.webUpdateToolStripMenuItem_Click);
            // 
            // localUpdateToolStripMenuItem
            // 
            this.localUpdateToolStripMenuItem.Name = "localUpdateToolStripMenuItem";
            this.localUpdateToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.localUpdateToolStripMenuItem.Text = "Local Update";
            this.localUpdateToolStripMenuItem.Click += new System.EventHandler(this.localUpdateToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 399);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "MainForm";
            this.Text = "Media Control";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox titleListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.Label totalEpsCount;
        private System.Windows.Forms.Label epsAvailableCount;
        private System.Windows.Forms.Label totalEps;
        private System.Windows.Forms.Label epAvailableLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webUpdateToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ToolStripMenuItem localUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}