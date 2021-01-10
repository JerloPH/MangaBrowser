using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace TachiLocal.Global
{
    public class GlobalVar
    {
        // ############################################################################################# Constant Variables
        public static string appTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
        public static string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static int appBuild = 1;
        public static string FILE_CONFIG = Application.StartupPath + @"\Data\config.json";
        public static string FILE_MANGAPATH = Application.StartupPath + @"\Data\mangaPaths.txt";
        public static string FILE_MANGATACHI = Application.StartupPath + @"\Data\mangaTachiyomi.txt";
        public static string FILE_LOG = Application.StartupPath + @"\App.log";

        // ############################################################################################# Variables
        public static string pathMangaFolder { get; set; } = "";
        public static string pathTachiFolder { get; set; } = "";
        public static string pathLogFileLocation { get; set; } = "";

        // ############################################################################################# Functions
        // Log actions
        public static void Log(string text)
        {
            // Log to file
            WriteAppend(FILE_LOG, $"[{ DateTime.Now.ToString() }] {text}");
        }
        // Log Error to File
        public static void LogError(Exception error, bool ShowMsg = false)
        {
            string fName = pathLogFileLocation + @"\MangaErrorLog.txt";
            try
            {
                using (StreamWriter w = File.AppendText(fName))
                {
                    w.Write("##############################################################################################\n");
                    w.Write($"App Name: { appTitle }\n");
                    w.Write($"App Version: { appVersion }\n");
                    w.Write($"Time and Date: {DateTime.Now.ToString()}\nError message:\n\t");
                    w.Write(error.Message.ToString());
                    w.Write("\nActual Error:\n\t" + error.ToString());
                    w.Write("\n");
                }
                if (ShowMsg)
                {
                    string msg = $"Application Error!\n{error.ToString()}";
                    ShowError(msg);
                }

            } catch {  }
        }
        // Show Message Box
        public static void ShowMsg(string msg)
        {
            MessageBox.Show(msg, appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, appTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool ShowYesNo(string msg)
        {
            if (MessageBox.Show(msg, appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        // Write to File
        public static void WriteLog(string fName, string toWrite)
        {
            WriteToFile(pathLogFileLocation + "\\" + fName, toWrite, "", "");
        }
        public static void WriteToFile(string fullPath, string toWrite)
        {
            WriteToFile(fullPath, toWrite, "", "");
        }
        public static void WriteToFile(string fullPath, string toWrite, string msg, string errMsg = "")
        {
            try
            {
                using (StreamWriter w = File.CreateText(fullPath))
                {
                    w.Write(toWrite);
                }
                if (String.IsNullOrWhiteSpace(msg) == false)
                {
                    // show message
                    ShowMsg(msg);
                }
            }
            catch (Exception ex)
            {
                // Log error
                LogError(ex);
                if (String.IsNullOrWhiteSpace(errMsg) == false)
                {
                    // Show error message
                    ShowError(errMsg + "\nError:\n" + ex.ToString());
                }
            }
        }
        // Write append to file
        public static void WriteAppend(string fullPath, string toWrite)
        {
            try
            {
                using (StreamWriter w = File.AppendText(fullPath))
                {
                    w.WriteLine(toWrite);
                }
            }
            catch (Exception ex)
            {
                // Log error
                LogError(ex);
            }
        }
        // Convert BITMAP SRC to IMAGE
        public static Bitmap ImgFromSrc(BitmapSource bmpsrc)
        {
            try
            {
                Bitmap img;
                using (MemoryStream outstream = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(bmpsrc));
                    enc.Save(outstream);
                    img = new Bitmap(outstream);
                }
                return img;
            } catch { return null; }
        }
        // Select a File
        public static string GetAFile(string Title, string filter, string InitialDir = "")
        {
            string ret = "";
            OpenFileDialog selectFile = new OpenFileDialog
            {
                InitialDirectory = InitialDir,
                Filter = filter,
                Title = Title,
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                Multiselect = false
            };
            selectFile.ShowDialog();
            if (String.IsNullOrWhiteSpace(selectFile.FileName) == false)
            {
                ret = selectFile.FileName;
            }
            selectFile.Dispose();
            return ret;
        }
        // Validate int, return string with zeroes
        public static string ValidateZero(int num)
        {
            if (num < 10)
            {
                return "000" + num.ToString();
            }
            else if (num < 100)
            {
                return "00" + num.ToString();
            }
            else if (num < 1000)
            {
                return "0" + num.ToString();
            }
            return num.ToString();
        }
        // Return a List of Folder Names in a Path, Descending Order Default
        public static List<string> FolderNames(string directory, bool Asc = false)
        {
            List<string> list = new List<string>();
            foreach (string d in Directory.GetDirectories(directory))
            {
                list.Add(d);
            }
            if (Asc)
            {
                list.Sort((a, b) => a.CompareTo(b)); // ascending sort
            }
            else
            {
                list.Sort((a, b) => b.CompareTo(a)); // descending sort
            }

            return list;
        }
        // Return a string with limited characters
        public static string StringLimit(string text, int MaxLength)
        {
            string ret = text;
            if (ret.Length > MaxLength)
            {
                ret = ret.Substring(0, MaxLength);
                ret += "...";
            }
            return ret;
        }
        // Return List of filenames of images/pages inside chapter folders of Manga
        public static List<string> AllChapterPage(string folderPath)
        {
            string toWrite = "";
            List<string> list = new List<string>();
            foreach (string folder in GlobalVar.FolderNames(folderPath, true))
            {
                List<string> chapter = Directory.GetFiles(folder).ToList();
                chapter.Sort((a, b) => a.CompareTo(b));
                foreach (string file in chapter)
                {
                    if (Path.GetFileName(file) != ".nomedia")
                    {
                        list.Add(file);
                        toWrite += file + "\n";
                    }
                }
                chapter.Clear();
            }
            GlobalVar.WriteLog("AllChapters.log", toWrite);
            return list;
        }
        // Read all String from File
        public static string ReadAllFromFile(string localFile)
        {
            string ret = String.Empty;
            if (File.Exists(localFile))
            {
                try
                {
                    using (StreamReader r = new StreamReader(localFile))
                    {
                        ret = r.ReadToEnd();
                    }
                    return ret;
                }
                catch (Exception ex)
                {
                    // Log error
                    LogError(ex);
                }
            }
            return String.Empty;
        }
        // #############################################################################################
    }
}
