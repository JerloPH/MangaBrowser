using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MangaBrowser
{
    public partial class frmLoad : Form
    {
        public string Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public string Message
        {
            get { return label1.Text; }
            set
            {
                if (label1.InvokeRequired)
                {
                    BeginInvoke((Action)delegate
                    {
                        label1.Text = value;
                    });
                }
                else
                    label1.Text = value;
            }
        }
        public bool isCanceled { get; set; }
        public int TopPosition { get; set; }
        public frmLoad(string message, string caption)
        {
            InitializeComponent();
            Message = message;
            Caption = caption;
            isCanceled = false;
            TopPosition = 0;
        }

        private void frmLoad_Shown(object sender, EventArgs e)
        {
            if (BackgroundWorker.IsBusy)
                return;
            BackgroundWorker.RunWorkerAsync();
            if (TopPosition != 0)
                this.Top = TopPosition;
        }

        private void frmLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BackgroundWorker.IsBusy)
                e.Cancel = true;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isCanceled = true;
        }

        private void frmLoad_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    escapeButton.PerformClick();
                    break;
            }
        }
    }
}
