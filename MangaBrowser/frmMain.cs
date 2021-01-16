using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MangaBrowser.Global;

namespace MangaBrowser
{
    public partial class frmMain : Form
    {
        // Pre-run
        public string breakLine = "###################################################################\n";
        public string DEF_MANGAPATH = "Path To Manga Folder";

        // Setup
        BackgroundWorker bgwCheckMangaFolder = new BackgroundWorker();

        public ImageList coverList = new ImageList();

        ToolStripItem tOpenFolder;

        string[] cbItemStatus = { "Unknown", "Ongoing", "Completed", "Licensed" };

        int SummaryLIMIT = 390; // Number of characters allowed on tooltip
        int ChapterLIMIT = 5; // Nummber of Latest Chapter names to show

        string DEF_IMGKEY = "img000"; // default imagekey for items with No cover image

        // Main Class Start-up
        public frmMain()
        {
            InitializeComponent();

            //GlobalVar.ShowLoading(this);

            // Load-In app Settings
            SettingsLoad();

            // Setup BGWorker
            bgwCheckMangaFolder.DoWork += new DoWorkEventHandler(bgw_CMFstart);
            bgwCheckMangaFolder.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_CMFend);

            // Setup Controls Events

            // Form properties
            Text = GlobalVar.appTitle + " v" + GlobalVar.appVersion;
            FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            // Control Properties
            lvManga.ShowItemToolTips = true;
            lvManga.Columns.Add("ColName"); // Manga Name
            lvManga.Columns.Add("ColAuthor"); // Author
            lvManga.Columns.Add("ColArtist"); // Artist
            lvManga.Columns.Add("ColDesc"); // Description or Summary
            lvManga.Columns.Add("ColGenre"); // List of Genre
            lvManga.Columns.Add("ColStat"); // Status ["0 = Unknown", "1 = Ongoing", "2 = Completed", "3 = Licensed"]
            lvManga.AllowDrop = false;
            lvManga.AllowColumnReorder = false;
            lvManga.MultiSelect = false;
            lvManga.Sorting = SortOrder.Ascending;
            lvManga.View = View.LargeIcon;
            lvManga.LargeImageList = coverList;
            //lvManga.SmallImageList = coverList;
            lvManga.TileSize = new Size(120, 90);
            lvManga.Items.Clear();
            //lvManga.FindControl("ColDesc").Visible = false;
            lvManga.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;

            cbStatus.Items.AddRange(cbItemStatus);
            cbStatus.SelectedIndex = 0;

            tOpenFolder = cMenuLV.Items.Add("&Open Folder");
            cMenuLV.ItemClicked += new ToolStripItemClickedEventHandler(cMenuLV_ItemCLicked);

            // ImageList for ListView, Properties
            coverList.Images.Clear();
            coverList.ImageSize = new Size(150, 200);//new Size(154, 205);

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(btnOpen, "Open 'details.json' file in Notepad++");
            tooltip.SetToolTip(btnSave, "Save info to 'details.json'.");

            //GlobalVar.ShowLoading(this, true);

            // Start BGWorker to Check Manga Folder
            bgwCheckMangaFolder.RunWorkerAsync();
        }
        // ############################################################################## BACKGROUND WORKERS
        private void bgw_CMFstart(object sender, DoWorkEventArgs e)
        {
            GlobalVar.ShowLoading(this);

            // Invoke required
            this.Invoke(new Action(() =>
            {
                // Dispose previous images
                GlobalVar.DisposeImgList(coverList);
                coverList.Images.Add(DEF_IMGKEY, Image.FromFile(GlobalVar.FILE_DEF_COVER));

                // Set default Picture
                SetPicboxImg();
            }));

            // Read Paths from mangaPaths.txt file in Data folder
            GlobalVar.pathMangaFolder = GlobalVar.ReadAllFromFile(GlobalVar.FILE_MANGAPATH);
            GlobalVar.Log($"Manga Path: {GlobalVar.pathMangaFolder}");

            // Read Paths from mangaTachiyomi.txt file in Data folder
            GlobalVar.pathTachiFolder = GlobalVar.ReadAllFromFile(GlobalVar.FILE_MANGATACHI);
            GlobalVar.Log($"Tachiyomi Path: {GlobalVar.pathTachiFolder}");

            // Get all Folder Names from specified Path
            string[] sDir = (!String.IsNullOrWhiteSpace(GlobalVar.pathMangaFolder)) ? GlobalVar.pathMangaFolder.Split('*') : null;

            // Vars and Objects
            List<string> list = new List<string>();
            string imgKey = "";
            int count = 0; // Total Manga counts
            int countImg = 0; // Image Added to ImageList, used in ListView

            // Clear ListView
            this.Invoke(new Action(() => lvManga.Items.Clear())); // Clear previous items

            // Get all Manga from MangaFolder Path, and Tachiyomi folder
            try
            {
                GlobalVar.Log($"List of Directories to Add:");

                // Loop thru all folders in Manga Folder
                if (sDir != null)
                {
                    foreach (string mainDir in sDir)
                    {
                        foreach (string folder in Directory.GetDirectories(mainDir))
                        {
                            if (String.IsNullOrWhiteSpace(Path.GetFileName(folder)) == false)
                            {
                                // Add to list
                                list.Add(folder);
                                GlobalVar.Log($"Added: {folder}");
                            }
                        }
                    }
                }
                else
                {
                    GlobalVar.Log($"Empty Manga folders!");
                }

                // Loop thru Tachiyomi folder structure
                if (!String.IsNullOrWhiteSpace(GlobalVar.pathTachiFolder))
                {
                    foreach (string src in Directory.GetDirectories(GlobalVar.pathTachiFolder + @"\downloads"))
                    {
                        // Loop thru folder inside sources
                        foreach (string manga in Directory.GetDirectories(src))
                        {
                            // Add to list
                            list.Add(manga);
                        }
                    }
                }

                // Loop thru the list and add to ListView
                if (list.Count > 0)
                {
                    foreach (string mangaPath in list)
                    {
                        // Add to ListView
                        // Create Vars to hold strings 
                        string j1 = ""; // Manga Title
                        string j2 = "Unknown"; // Author
                        string j3 = "Unknown"; // Artist
                        string j4 = "Manga Summary"; // Description / Summary
                        string[] j5 = new string[] { "" }; // Genre, List
                        string j6 = "Unknown"; // Status
                        GlobalVar.Log($"Added to ListView: [{ mangaPath }]");

                        // Add Image to ImageList
                        try
                        {
                            string imageFile = mangaPath + @"\cover.jpg";
                            if (File.Exists(imageFile))
                            {
                                countImg += 1;
                                var img = Image.FromFile(imageFile);
                                imgKey = "img" + GlobalVar.ValidateZero(countImg);
                                this.Invoke(new Action(() => coverList.Images.Add(imgKey, img)));
                                GlobalVar.Log($"Added Image to ImageList. ImagePath ({ imgKey }): { mangaPath }\\cover.jpg");
                            }
                            else
                            {
                                imgKey = DEF_IMGKEY;
                                GlobalVar.Log($"File: 'cover.jpg' does not exists!");
                            }

                        }
                        catch (Exception ex)
                        {
                            // Write to Error Log
                            imgKey = DEF_IMGKEY;
                            GlobalVar.LogError(ex);
                            GlobalVar.Log($"Cannot load image for this item!");
                        }

                        // Deserialize JSON file
                        string deetsfile = GlobalVar.ReadAllFromFile(mangaPath + @"\details.json");
                        if (String.IsNullOrWhiteSpace(deetsfile) == false)
                        {
                            MangaInfo minfo = JsonConvert.DeserializeObject<MangaInfo>(deetsfile);

                            j1 = minfo.title;
                            j2 = minfo.author;
                            j3 = minfo.artist;
                            j4 = minfo.description;
                            j5 = minfo.genre;
                            j6 = minfo.status;

                        }
                        else
                        {
                            j1 = Path.GetFileName(mangaPath);
                            j6 = "0";
                        }

                        // loop thru j5, all genres
                        string j5line = j5[0].ToString();

                        // Create ListView Item
                        ListViewItem temp = new ListViewItem();

                        temp.Text = j1;
                        temp.SubItems.Add(j2);
                        temp.SubItems.Add(j3);
                        temp.SubItems.Add(j4);
                        temp.SubItems.Add(j5line);
                        temp.SubItems.Add(MangaStatus(Convert.ToInt16(j6)));
                        temp.Tag = mangaPath; // Put the manga path to item tag
                        temp.SubItems[1].Tag = imgKey; // Put imagekey to subitem tag

                        // Set Image by using ImageKey
                        if (String.IsNullOrWhiteSpace(imgKey))
                        {
                            temp.ImageIndex = 0;
                            GlobalVar.Log($"ListView Item ImageIndex: 0");
                        }
                        else
                        {
                            temp.ImageKey = imgKey;
                            GlobalVar.Log($"ListView Item ImageKey used: { imgKey }");
                        }

                        // Get last 3 Chapters
                        string lastChap = StringLatestChapters(mangaPath, ChapterLIMIT);

                        // Limit Summary to MaxLength characters
                        j4 = GlobalVar.StringLimit(j4, SummaryLIMIT);

                        // Set ToolTip on Item, Mouse Hover
                        temp.ToolTipText = StringLVTooltip(j4, j5line, lastChap);

                        // Add ListView item to ListView
                        this.Invoke(new Action(() => lvManga.Items.Add(temp)));
                        count += 1;
                    }
                }

                e.Result = count;
            }
            catch (Exception excpt)
            {
                // Log error
                GlobalVar.LogError(excpt);
                e.Result = null;
            }
        }
        private void bgw_CMFend(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                // Result contains data
                int count = (int) e.Result;

                // End of foreach loop
                GlobalVar.Log($"Total Items added: {count.ToString()}");
            }

            //lvManga.LargeImageList = coverList;
            lvManga.Refresh();
            //lvManga.Invalidate();
            GlobalVar.ShowLoading(this, true);
        }
        // ############################################################################## FUNCTIONS
        // Load Settings from file
        private void SettingsLoad()
        {
            string file = GlobalVar.FILE_CONFIG;
            if (File.Exists(file))
            {
                string src = GlobalVar.ReadAllFromFile(file);
                Config config = JsonConvert.DeserializeObject<Config>(src);
                GlobalVar.pathLogFileLocation = (String.IsNullOrWhiteSpace(config.LogFileLocation) ? Application.StartupPath : config.LogFileLocation);
            }
            else
            {
                // Create new config file
                SettingsSave(true);
            }
        }
        // Save settings to file
        private void SettingsSave(bool ShowMsg)
        {
            // Delete prev Config file
            string file = GlobalVar.FILE_CONFIG;
            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);

                } catch (Exception ex)
                {
                    GlobalVar.LogError(ex);
                    if (ShowMsg)
                    {
                        GlobalVar.ShowError("Cannot delete old configuration file!");
                    }
                }
            }
            // Make Config
            Config c = new Config();
            c.LogFileLocation = GlobalVar.pathLogFileLocation;

            // Save to file
            // Serialize into JSON file
            string json = JsonConvert.SerializeObject(c, Formatting.Indented);

            // Write to file
            if (ShowMsg)
            {
                GlobalVar.WriteToFile(file, json, "Settings saved!", "Cannot save configuration file!");
            }
            else
            {
                GlobalVar.WriteToFile(file, json);
            }
        }
        // Return Status string from int Index
        private String MangaStatus(int index)
        {
            if (index > 0)
            {
                return cbItemStatus[index];
            }
            else
            {
                return cbItemStatus[0];
            }
        }
        // Set Image for picBox control
        private void SetPicboxImg(string ImageKey = "")
        {
            int sel = coverList.Images.IndexOfKey(ImageKey);
            if (sel < 1)
            {
                sel = 0;
            }
            picBox.Image = coverList.Images[sel];
        }
        // Return Folder Names of Latest chapters, from Folder Path
        private string StringLatestChapters(string folderPath, int count)
        {
            int cc = count;
            string lastChap = "";
            foreach (string ss in GlobalVar.FolderNames(folderPath))
            {
                string folderName = Path.GetFileName(ss);
                lastChap += folderName.Replace('_', ':') + "\n";
                cc -= 1;
                if (cc < 1)
                {
                    break;
                }
            }
            lastChap = lastChap.TrimEnd('\n');
            return lastChap;
        }
        // Return a string for ListView Item tooltip text
        private string StringLVTooltip(string summary, string genre, string latestChapters)
        {
            return "Summary:\n" + summary + "\n\nGenre:\n" + genre + "\n\nLatest Chapters:\n" + latestChapters;
        }
        // Validate String SUmmary
        private string SummaryLoadToTextbox(string summary)
        {
            return summary.Replace("\n", "\r\n");
        }
        // Open ListView lvManga Item, and access its info
        private void OpenLVItem()
        {
            // View Manga details on the right side, for selected index
            if (lvManga.SelectedItems.Count > 0)
            {
                // Get ImageKey and set Image for picBox on the right
                string key = lvManga.SelectedItems[0].ImageKey;
                SetPicboxImg(key); // set image according to selected manga

                // Change Info on the Right (Manga Details)
                ListViewItem index = lvManga.SelectedItems[0];
                txtTitle.Text = index.Text;
                txtMangaPath.Text = index.Tag.ToString(); //txtTitle.Tag = index.Tag; // get the path hidden in item tag
                txtAuthor.Text = index.SubItems[1].Text; // author
                txtArtist.Text = index.SubItems[2].Text; // artist
                txtSummary.Text = SummaryLoadToTextbox(index.SubItems[3].Text); // summary
                txtGenre.Text = index.SubItems[4].Text; // genre
                string status = index.SubItems[5].Text; // status

                // Process status
                int statIndex = Array.IndexOf(cbItemStatus, status);
                if (statIndex > 0)
                {
                    cbStatus.SelectedIndex = statIndex;
                }
                else
                {
                    cbStatus.SelectedIndex = 0;
                }
            }
        }
        // Return unique imageKey
        private string GetUniqueImgKey()
        {
            int count = coverList.Images.Count;
            string imageKey = "img" + GlobalVar.ValidateZero(count);
            while (coverList.Images.ContainsKey(imageKey))
            {
                count += 1;
                imageKey = "img" + GlobalVar.ValidateZero(count);
            }
            return imageKey;
        }
        // Adjust Buttons Position
        private void AdjustButtons(int Main)
        {
            btnOpen.Top = Main;
            btnSave.Top = Main;
            btnReload.Top = Main;
        }
        // ############################################################################## CUSTOM EVENTS
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save Settings
            //SettingSave(false);

            // Dispose objects
            foreach (Image img in coverList.Images)
            {
                img.Dispose();
            }

            bgwCheckMangaFolder.Dispose();
        }
        // Context Menu Item is Selected
        void cMenuLV_ItemCLicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            // check which item is clicked
            if (item == tOpenFolder)
            {
                // Open Folder of selected LV Item
                try
                {
                    // Open folder location
                    string folder = lvManga.SelectedItems[0].Tag.ToString();
                    Process.Start(folder);
                } catch (Exception ex)
                {
                    // Log Error
                    GlobalVar.LogError(ex);
                }
            }
        }
        // When ListView lvManga is clicked on
        private void lvManga_MouseClick(object sender, MouseEventArgs e)
        {
            // Right clicked? Show Context menu
            if (e.Button == MouseButtons.Right)
            {
                // Check if something is focused
                if (lvManga.FocusedItem != null)
                {
                    // check if mouse is on lv Item Bounds
                    if (lvManga.FocusedItem.Bounds.Contains(e.Location))
                    {
                        // Show pop-up context menu
                        cMenuLV.Show(Cursor.Position);
                    }
                }
            }
        }
        // ############################################################################## STANDARD EVENTS
        // Start Up Actions
        private void frmMain_Load(object sender, EventArgs e)
        {
            txtMangaPath.Text = DEF_MANGAPATH;
        }
        private void lvManga_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Call function to Open LV Item
            OpenLVItem();
        }
        // When ENTER Key is pressed on ListView
        private void lvManga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Call function to Open LV Item
                OpenLVItem();
            }
        }
        // Resize GUI. Responsive UI
        private void frmMain_Resize(object sender, EventArgs e)
        {
            // Figure out Minimize/Maximized event, for optimizations
            if ((WindowState == FormWindowState.Maximized) || (WindowState == FormWindowState.Normal))
            {
                // Sizes var
                double sizeLV = 0.65;
                double sizeFPanel = 0.35;

                // Normal screen
                if (WindowState == FormWindowState.Normal)
                {
                    try
                    {
                        sizeLV = 0.55;
                        sizeFPanel = 0.4;
                        Size nLV = new Size(Convert.ToInt32(this.ClientSize.Width * sizeLV), this.ClientSize.Height);
                        Size nFP = new Size(Convert.ToInt32(this.ClientSize.Width * sizeFPanel), this.ClientSize.Height);
                        lvManga.Size = nLV;
                        fPanelInfo.Size = nFP;

                        // Resize Right-side controls
                        double RClientW = fPanelInfo.ClientSize.Width;
                        double RClientH = fPanelInfo.ClientSize.Height;
                        int WHalfBox = Convert.ToInt32(RClientW * 0.5);
                        int WFullBox = Convert.ToInt32(RClientW * 0.95);

                        txtGenre.Width = WHalfBox;
                        txtGenre.Height = Convert.ToInt32(RClientH * 0.14);

                        txtSummary.Width = WFullBox;
                        txtSummary.Height = Convert.ToInt32(RClientH * 0.3);

                        txtTitle.Width = WFullBox;

                        txtMangaPath.Width = WFullBox;
                        txtMangaPath.Top = Convert.ToInt32(RClientH - (txtMangaPath.Height + 2));

                        AdjustButtons(Convert.ToInt32(txtMangaPath.Top - (btnOpen.Height + 2)));

                    } catch (Exception ex)
                    {
                        GlobalVar.LogError(ex);
                    }
                }
                else
                {
                    // Maximized
                    try
                    {
                        Rectangle handle = Screen.PrimaryScreen.WorkingArea;
                        Size newSizeLV = new Size(Convert.ToInt32(handle.Width * sizeLV), handle.Height);
                        lvManga.Size = newSizeLV;
                        Size newSizePanel = new Size(Convert.ToInt32(handle.Width * sizeFPanel), handle.Height);
                        fPanelInfo.Size = newSizePanel;


                        // Resize Right-side controls
                        double RClientW = fPanelInfo.ClientSize.Width;
                        double RClientH = fPanelInfo.ClientSize.Height;
                        int WHalfBox = Convert.ToInt32(RClientW * 0.57);
                        int WFullBox = Convert.ToInt32(RClientW * 0.95);

                        txtGenre.Width = WHalfBox;
                        txtGenre.Height = Convert.ToInt32(RClientH * 0.12);

                        txtSummary.Width = WFullBox;
                        txtSummary.Height = Convert.ToInt32(RClientH * 0.4);

                        txtTitle.Width = WFullBox;

                        txtMangaPath.Width = WFullBox;
                        txtMangaPath.Top = Convert.ToInt32(RClientH - (txtMangaPath.Height + 50));

                        AdjustButtons(Convert.ToInt32(txtMangaPath.Top - (btnOpen.Height + 10)));

                    } catch (Exception ex)
                    {
                        GlobalVar.LogError(ex);
                    }
                }

            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save changes to Manga Details
            if (GlobalVar.ShowYesNo("Are you sure you want to overwrite Manga details?"))
            {
                string PATH = txtMangaPath.Text;
                string file = PATH + @"\details.json";
                // Check if previous file exists, and delete it
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                // Setup MangaInfo.cs first
                MangaInfo manga = new MangaInfo();
                manga.title = txtTitle.Text;
                manga.artist = txtArtist.Text;
                manga.author = txtAuthor.Text;
                manga.description = txtSummary.Text.Replace("\r", "");
                // Process Genre
                string Genre = "";
                foreach (string s in txtGenre.Text.Replace("\r\n", ",").Split(','))
                {
                    if (String.IsNullOrWhiteSpace(s) == false)
                    {
                        Genre += s.Trim() + ", ";
                    }
                }
                Genre = Genre.Trim();
                Genre = Genre.TrimEnd(',');
                List<string> genreDone = new List<string>();
                genreDone.Add(Genre);
                manga.genre = genreDone.ToArray();
                // Process Status
                int index = Array.IndexOf(cbItemStatus, cbStatus.Text);
                if (index < 1)
                {
                    index = 0;
                }
                manga.status = index.ToString();
                // Serialize into JSON file
                string json = JsonConvert.SerializeObject(manga, Formatting.Indented);

                // Trim json string
                string strRep = "";
                try
                {
                    // Get substring between [ ]
                    string cStart = "[";
                    string cEnd = "]";
                    var start = json.IndexOf(cStart) + cStart.Length;

                    strRep = json.Substring(start, json.IndexOf(cEnd) - start);
                    
                    json = json.Replace(strRep, strRep.Trim());

                }
                catch (Exception ex1)
                {
                    // LogError
                    GlobalVar.LogError(ex1);
                }

                // Write to file
                GlobalVar.WriteToFile(file, json, "Done saving!", "Error on saving Manga details!");
                
                // Reflect changes to listview item
                foreach (ListViewItem lv in lvManga.Items)
                {
                    // Search all and find
                    if (lv.Tag.ToString() == PATH)
                    {
                        // Found the one
                        lv.Text = manga.title;
                        lv.SubItems[1].Text = manga.author; // author
                        lv.SubItems[2].Text = manga.artist; // artist
                        lv.SubItems[3].Text = manga.description; // summary
                        lv.SubItems[4].Text = Genre; // genre
                        lv.SubItems[5].Text = MangaStatus(Convert.ToInt32(manga.status)); // status
                        lv.ToolTipText = StringLVTooltip(GlobalVar.StringLimit(manga.description, SummaryLIMIT), Genre, StringLatestChapters(PATH, ChapterLIMIT));
                        lvManga.Refresh();
                        break;
                    }
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Open folder for selected Manga, in Windows Explorer
            string PATH = txtMangaPath.Text;
            Clipboard.SetText(PATH);
            try
            {
                //Process.Start("explorer.exe", @"/select," + $"{ PATH }" + '"');
                Process.Start("notepad++.exe", '"' + PATH + @"\details.json" + '"');

            } catch (Exception ex)
            {
                GlobalVar.LogError(ex, true);
            }
        }
        // Change Image cover
        private void picBox_Click(object sender, EventArgs e)
        {
            // Check if there is a seleted item
            if (lvManga.SelectedItems.Count > 0)
            {
                string selectedFilename = GlobalVar.GetAFile("Select new Cover image for Manga...", "JPG Files (*.jpg)|*.jpg", "");
                if (String.IsNullOrWhiteSpace(selectedFilename) == false)
                {
                    string mangapath = lvManga.SelectedItems[0].Tag.ToString();
                    string newCoverPath = Path.GetFullPath(mangapath) + "\\cover.jpg";
                    string imageKey = lvManga.SelectedItems[0].SubItems[1].Tag.ToString();

                    // Confirm change
                    if (GlobalVar.ShowYesNo("Changing Image cover file. Confirm?"))
                    {
                        // Dispose previous image
                        if ((picBox.Image != null) && (imageKey != DEF_IMGKEY))
                        {
                            picBox.Image.Dispose();
                        }

                        // If imageKey is NOT the default imageKey
                        if (imageKey != DEF_IMGKEY)
                        {
                            // If imageKey already exists, remove it from image list
                            if (coverList.Images.ContainsKey(imageKey))
                            {
                                coverList.Images.RemoveByKey(imageKey);
                            }
                        }
                        else
                        {
                            // If imagekey is the default, Get a NEW Unique ImageKey
                            imageKey = GetUniqueImgKey();
                        }

                        // Try Copy cover file to manga folder location
                        try
                        {
                            // Copy, replace existing
                            File.Copy(selectedFilename, newCoverPath, true);
                            coverList.Images.Add(imageKey, Image.FromFile(newCoverPath));
                            SetPicboxImg(imageKey);

                        }
                        catch (Exception ex)
                        {
                            // LogError
                            // Revert to default image
                            imageKey = DEF_IMGKEY;
                            GlobalVar.LogError(ex);
                        }

                        // Set the ImageKey on SubItem[1].Tag on LV Item
                        lvManga.SelectedItems[0].SubItems[1].Tag = imageKey;

                        // Set ImageKey for LV Item
                        lvManga.SelectedItems[0].ImageKey = imageKey;

                        // Refresh Manga ListView
                        lvManga.Refresh();

                    }
                }
            }
        }
        // Refresh Manga List
        private void btnReload_Click(object sender, EventArgs e)
        {
            try { bgwCheckMangaFolder.RunWorkerAsync(); }
            catch (Exception ex)
            {
                GlobalVar.ShowError("Cannot refresh list!");
                GlobalVar.LogError(ex);
            }
        }
    }
}
