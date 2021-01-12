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
            this.lvManga = new System.Windows.Forms.ListView();
            this.fPanelInfo = new System.Windows.Forms.GroupBox();
            this.txtMangaPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lbMangaTitle = new System.Windows.Forms.Label();
            this.cMenuLV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnReload = new System.Windows.Forms.Button();
            this.fPanelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lvManga
            // 
            this.lvManga.BackColor = System.Drawing.Color.Black;
            this.lvManga.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvManga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvManga.HideSelection = false;
            this.lvManga.Location = new System.Drawing.Point(0, 0);
            this.lvManga.Name = "lvManga";
            this.lvManga.Size = new System.Drawing.Size(520, 721);
            this.lvManga.TabIndex = 0;
            this.lvManga.UseCompatibleStateImageBehavior = false;
            this.lvManga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvManga_KeyDown);
            this.lvManga.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvManga_MouseClick);
            this.lvManga.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvManga_MouseDoubleClick);
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
            this.fPanelInfo.Location = new System.Drawing.Point(520, 0);
            this.fPanelInfo.Name = "fPanelInfo";
            this.fPanelInfo.Size = new System.Drawing.Size(742, 721);
            this.fPanelInfo.TabIndex = 1;
            this.fPanelInfo.TabStop = false;
            this.fPanelInfo.Text = "Manga Details";
            // 
            // txtMangaPath
            // 
            this.txtMangaPath.Enabled = false;
            this.txtMangaPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMangaPath.Location = new System.Drawing.Point(5, 688);
            this.txtMangaPath.Name = "txtMangaPath";
            this.txtMangaPath.Size = new System.Drawing.Size(545, 30);
            this.txtMangaPath.TabIndex = 18;
            this.txtMangaPath.Text = "Path To Manga Folder";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Black;
            this.btnOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOpen.Location = new System.Drawing.Point(5, 645);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(128, 39);
            this.btnOpen.TabIndex = 16;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Location = new System.Drawing.Point(139, 645);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 39);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGenre
            // 
            this.txtGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenre.Location = new System.Drawing.Point(278, 243);
            this.txtGenre.Multiline = true;
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGenre.Size = new System.Drawing.Size(272, 99);
            this.txtGenre.TabIndex = 14;
            this.txtGenre.Text = "Genres";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(278, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "Genre :";
            // 
            // txtSummary
            // 
            this.txtSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSummary.Location = new System.Drawing.Point(5, 428);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(545, 213);
            this.txtSummary.TabIndex = 12;
            this.txtSummary.Text = "Summary of Manga";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Summary :";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(278, 183);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(272, 33);
            this.cbStatus.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(278, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Status :";
            // 
            // txtArtist
            // 
            this.txtArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtist.Location = new System.Drawing.Point(278, 122);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(272, 30);
            this.txtArtist.TabIndex = 8;
            this.txtArtist.Text = "Artist Name";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(278, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Artist :";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(278, 60);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(272, 30);
            this.txtAuthor.TabIndex = 6;
            this.txtAuthor.Text = "Author Name";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(278, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Author: ";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(5, 369);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(545, 30);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Text = "Manga Title";
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.Black;
            this.picBox.Location = new System.Drawing.Point(9, 37);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(255, 305);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 2;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.picBox_Click);
            // 
            // lbMangaTitle
            // 
            this.lbMangaTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMangaTitle.ForeColor = System.Drawing.Color.Black;
            this.lbMangaTitle.Location = new System.Drawing.Point(6, 345);
            this.lbMangaTitle.Name = "lbMangaTitle";
            this.lbMangaTitle.Size = new System.Drawing.Size(137, 29);
            this.lbMangaTitle.TabIndex = 3;
            this.lbMangaTitle.Text = "Manga Title :";
            // 
            // cMenuLV
            // 
            this.cMenuLV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMenuLV.Name = "cMenuLV";
            this.cMenuLV.Size = new System.Drawing.Size(61, 4);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Black;
            this.btnReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReload.Location = new System.Drawing.Point(273, 645);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(156, 39);
            this.btnReload.TabIndex = 19;
            this.btnReload.Text = "RELOAD";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1262, 721);
            this.Controls.Add(this.fPanelInfo);
            this.Controls.Add(this.lvManga);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.fPanelInfo.ResumeLayout(false);
            this.fPanelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvManga;
        private System.Windows.Forms.GroupBox fPanelInfo;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lbMangaTitle;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtMangaPath;
        private System.Windows.Forms.ContextMenuStrip cMenuLV;
        private System.Windows.Forms.Button btnReload;
    }
}

