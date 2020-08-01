using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookBackupParser
{
    public partial class Form1 : Form
    {
        string inputPath;
        readonly string photosFolderName = "photos";
        readonly string videosFolderName = "videos";
        readonly string htmlFileName = "message.html";
        readonly string newPhotoFolderName = "parsedPhotos";
        readonly string newVideoFolderName = "parsedVideos";
        readonly string imageFormat = ".jpg";
        readonly string videoFormat = ".mp4";
        readonly string dateFormat = "yyyy-MM-dd_HH'h'-mm'm'-ss's'";
        HtmlAgilityPack.HtmlDocument document;

        public Form1()
        {
            InitializeComponent();
        }

        private void chooseFolderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
                inputPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(inputPath))
            {
                string inputText = folderTextBox.Text;
                if (Directory.Exists(inputText))
                {
                    inputPath = inputText;
                }
            }

            if (!String.IsNullOrEmpty(inputPath))
            {
                progressBox.Text = "Parsing HTML file...";
                progressBox.Refresh();

                ParseHTML();

                progressBox.Text = "Writing photo information...";
                progressBox.Refresh();

                WritePhotos();

                progressBox.Text = "Writing video information...";
                progressBox.Refresh();

                WriteVideos();
                
                progressBox.Text = "Completed!";
            }
        }

        private void ParseHTML()
        {
            string htmlPath = Path.Combine(inputPath, htmlFileName);
            string loaded = File.ReadAllText(htmlPath);
            document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(loaded);
        }

        private void WritePhotos()
        {
            string directoryPath = Path.Combine(inputPath, photosFolderName);
            if (Directory.Exists(directoryPath))
            {
                string outputFolder = directoryPath;
                if (backup.Checked)
                {
                    outputFolder = Path.Combine(inputPath, newPhotoFolderName);
                    Directory.CreateDirectory(outputFolder);
                }


                foreach (String fileName in Directory.GetFiles(directoryPath))
                {
                    string originalFileName = fileName;
                    string dateString = searchHtml(image: Path.GetFileName(fileName));
                    DateTime date = DateTime.Parse(dateString);
                    string dateName = date.ToString(dateFormat);
                    string newFileName = Path.Combine(outputFolder, dateName + imageFormat);

                    int tentative = 0;
                    while (File.Exists(newFileName))
                    {
                        newFileName = Path.Combine(outputFolder, dateName + tentative + imageFormat);
                        tentative++;
                    }

                    if (backup.Checked)
                        File.Copy(originalFileName, newFileName);
                    else
                        File.Move(originalFileName, newFileName);
                }
            }
        }

        private void WriteVideos()
        {
            string directoryPath = Path.Combine(inputPath, videosFolderName);
            if (Directory.Exists(directoryPath))
            {
                string outputFolder = directoryPath;
                if (backup.Checked)
                {
                    outputFolder = Path.Combine(inputPath, newVideoFolderName);
                    Directory.CreateDirectory(outputFolder);
                }


                foreach (String fileName in Directory.GetFiles(directoryPath))
                {
                    string originalFileName = fileName;
                    string dateString = searchHtml(video: Path.GetFileName(fileName));
                    DateTime date = DateTime.Parse(dateString);
                    string dateName = date.ToString(dateFormat);
                    string newFileName = Path.Combine(outputFolder, dateName + videoFormat);

                    int tentative = 0;
                    while (File.Exists(newFileName))
                    {
                        newFileName = Path.Combine(outputFolder, dateName + tentative + videoFormat);
                        tentative++;
                    }

                    if (backup.Checked)
                        File.Copy(originalFileName, newFileName);
                    else
                        File.Move(originalFileName, newFileName);
                }
            }
        }

        private string searchHtml(string image = null, string video = null)
        {
            if (image != null)
            {
                HtmlAgilityPack.HtmlNode node =
                document.DocumentNode.Descendants("img")
                    .Where(e => e.GetAttributeValue("src", null).Contains(image))
                    .FirstOrDefault();

                return node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.SelectSingleNode(".//div[@class='_3-94 _2lem']").InnerText;
            }
            else if (video != null)
            {
                HtmlAgilityPack.HtmlNode node =
                document.DocumentNode.Descendants("video")
                    .Where(e => e.GetAttributeValue("src", null).Contains(video))
                    .FirstOrDefault();

                return node.ParentNode.ParentNode.ParentNode.ParentNode.SelectSingleNode(".//div[@class='_3-94 _2lem']").InnerText;
            }
            else
                throw new ArgumentException();
        }

        private void folderTextBox_Click(object sender, EventArgs e)
        {
            folderTextBox.Clear();
        }
    }
}
