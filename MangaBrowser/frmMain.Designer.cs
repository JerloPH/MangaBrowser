namespace MangaBrowser
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.tabManga = new System.Windows.Forms.TabControl();
            this.pageManga = new System.Windows.Forms.TabPage();
            this.lvManga = new System.Windows.Forms.ListView();
            this.pageTachi = new System.Windows.Forms.TabPage();
            this.lbMangaTitle = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtMangaPath = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.fPanelInfo = new System.Windows.Forms.GroupBox();
            this.cMenuLV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lvMangaTachi = new System.Windows.Forms.ListView();
            this.tabManga.SuspendLayout();
            this.pageManga.SuspendLayout();
            this.pageTachi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.fPanelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabManga
            // 
            this.tabManga.Controls.Add(this.pageManga);
            this.tabManga.Controls.Add(this.pageTachi);
            this.tabManga.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabManga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabManga.Location = new System.Drawing.Point(0, 0);
            this.tabManga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabManga.Name = "tabManga";
            this.tabManga.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabManga.SelectedIndex = 0;
            this.tabManga.Size = new System.Drawing.Size(466, 591);
            this.tabManga.TabIndex = 0;
            // 
            // pageManga
            // 
            this.pageManga.Controls.Add(this.lvManga);
            this.pageManga.Location = new System.Drawing.Point(4, 25);
            this.pageManga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pageManga.Name = "pageManga";
            this.pageManga.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pageManga.Size = new System.Drawing.Size(458, 562);
            this.pageManga.TabIndex = 0;
            this.pageManga.Text = "Local Manga";
            this.pageManga.UseVisualStyleBackColor = true;
            // 
            // lvManga
            // 
            this.lvManga.BackColor = System.Drawing.Color.Black;
            this.lvManga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvManga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvManga.HideSelection = false;
            this.lvManga.Location = new System.Drawing.Point(2, 2);
            this.lvManga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvManga.Name = "lvManga";
            this.lvManga.Size = new System.Drawing.Size(454, 558);
            this.lvManga.TabIndex = 3;
            this.lvManga.UseCompatibleStateImageBehavior = false;
            this.lvManga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvManga_KeyDown);
            this.lvManga.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvManga_MouseClick);
            this.lvManga.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvManga_MouseDoubleClick);
            // 
            // pageTachi
            // 
            this.pageTachi.Controls.Add(this.lvMangaTachi);
            this.pageTachi.Location = new System.Drawing.Point(4, 25);
            this.pageTachi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pageTachi.Name = "pageTachi";
            this.pageTachi.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pageTachi.Size = new System.Drawing.Size(458, 562);
            this.pageTachi.TabIndex = 1;
            this.pageTachi.Text = "Tachiyomi";
            this.pageTachi.UseVisualStyleBackColor = true;
            // 
            // lbMangaTitle
            // 
            this.lbMangaTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMangaTitle.ForeColor = System.Drawing.Color.Black;
            this.lbMangaTitle.Location = new System.Drawing.Point(4, 280);
            this.lbMangaTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMangaTitle.Name = "lbMangaTitle";
            this.lbMangaTitle.Size = new System.Drawing.Size(103, 24);
            this.lbMangaTitle.TabIndex = 3;
            this.lbMangaTitle.Text = "Manga Title :";
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.Black;
            this.picBox.Location = new System.Drawing.Point(7, 30);
            this.picBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(191, 248);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 2;
            this.picBox.TabStop = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(4, 300);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(410, 26);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Text = "Manga Title";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(208, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Author: ";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(208, 49);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(205, 26);
            this.txtAuthor.TabIndex = 6;
            this.txtAuthor.Text = "Author Name";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(208, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Artist :";
            // 
            // txtArtist
            // 
            this.txtArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtist.Location = new System.Drawing.Point(208, 99);
            this.txtArtist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(205, 26);
            this.txtArtist.TabIndex = 8;
            this.txtArtist.Text = "Artist Name";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(208, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Status :";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(208, 149);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(205, 28);
            this.cbStatus.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 329);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Summary :";
            // 
            // txtSummary
            // 
            this.txtSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSummary.Location = new System.Drawing.Point(4, 348);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(410, 174);
            this.txtSummary.TabIndex = 12;
            this.txtSummary.Text = "Summary of Manga";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(208, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Genre :";
            // 
            // txtGenre
            // 
            this.txtGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenre.Location = new System.Drawing.Point(208, 197);
            this.txtGenre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGenre.Multiline = true;
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGenre.Size = new System.Drawing.Size(205, 81);
            this.txtGenre.TabIndex = 14;
            this.txtGenre.Text = "Genres";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Location = new System.Drawing.Point(104, 524);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Black;
            this.btnOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOpen.Location = new System.Drawing.Point(4, 524);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(96, 32);
            this.btnOpen.TabIndex = 16;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtMangaPath
            // 
            this.txtMangaPath.Enabled = false;
            this.txtMangaPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMangaPath.Location = new System.Drawing.Point(4, 559);
            this.txtMangaPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMangaPath.Name = "txtMangaPath";
            this.txtMangaPath.Size = new System.Drawing.Size(410, 26);
            this.txtMangaPath.TabIndex = 18;
            this.txtMangaPath.Text = "Path To Manga Folder";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Black;
            this.btnReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReload.Location = new System.Drawing.Point(205, 524);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(117, 32);
            this.btnReload.TabIndex = 19;
            this.btnReload.Text = "RELOAD";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // fPanelInfo
            // 
            this.fPanelInfo.BackColor = System.Drawing.Color.DarkGray;
            this.fPanelInfo.Controls.Add(this.btnReload);
            this.fPanelInfo.Controls.Add(this.txtMangaPath);
            this.fPanelInfo.Controls.Add(this.btnOpen);
            this.fPanelInfo.Controls.Add(this.btnSave);
            this.fPanelInfo.Controls.Add(this.txtGenre);
            this.fPanelInfo.Controls.Add(this.label5);
            this.fPanelInfo.Controls.Add(this.txtSummary);
            this.fPanelInfo.Controls.Add(this.label4);
            this.fPanelInfo.Controls.Add(this.cbStatus);
            this.fPanelInfo.Controls.Add(this.label3);
            this.fPanelInfo.Controls.Add(this.txtArtist);
            this.fPanelInfo.Controls.Add(this.label2);
            this.fPanelInfo.Controls.Add(this.txtAuthor);
            this.fPanelInfo.Controls.Add(this.label1);
            this.fPanelInfo.Controls.Add(this.txtTitle);
            this.fPanelInfo.Controls.Add(this.picBox);
            this.fPanelInfo.Controls.Add(this.lbMangaTitle);
            this.fPanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fPanelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fPanelInfo.Location = new System.Drawing.Point(466, 0);
            this.fPanelInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fPanelInfo.Name = "fPanelInfo";
            this.fPanelInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fPanelInfo.Size = new System.Drawing.Size(480, 591);
            this.fPanelInfo.TabIndex = 3;
            this.fPanelInfo.TabStop = false;
            this.fPanelInfo.Text = "Manga Details";
            // 
            // cMenuLV
            // 
            this.cMenuLV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMenuLV.Name = "cMenuLV";
            this.cMenuLV.Size = new System.Drawing.Size(61, 4);
            // 
            // lvMangaTachi
            // 
            this.lvMangaTachi.BackColor = System.Drawing.Color.Black;
            this.lvMangaTachi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMangaTachi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvMangaTachi.HideSelection = false;
            this.lvMangaTachi.Location = new System.Drawing.Point(2, 2);
            this.lvMangaTachi.Margin = new System.Windows.Forms.Padding(2);
            this.lvMangaTachi.Name = "lvMangaTachi";
            this.lvMangaTachi.Size = new System.Drawing.Size(454, 558);
            this.lvMangaTachi.TabIndex = 4;
            this.lvMangaTachi.UseCompatibleStateImageBehavior = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(946, 591);
            this.Controls.Add(this.fPanelInfo);
            this.Controls.Add(this.tabManga);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabManga.ResumeLayout(false);
            this.pageManga.ResumeLayout(false);
            this.pageTachi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.fPanelInfo.ResumeLayout(false);
            this.fPanelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabManga;
        private System.Windows.Forms.TabPage pageManga;
        internal System.Windows.Forms.ListView lvManga;
        private System.Windows.Forms.TabPage pageTachi;
        private System.Windows.Forms.Label lbMangaTitle;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtMangaPath;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox fPanelInfo;
        private System.Windows.Forms.ContextMenuStrip cMenuLV;
        internal System.Windows.Forms.ListView lvMangaTachi;
    }
}

