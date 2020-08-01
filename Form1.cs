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
        readonly string htmlFileName = "message.html";
        readonly string newFolderName = "parsedPhotos";
        readonly string imageFormat = ".jpg";
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
            if (!String.IsNullOrEmpty(inputPath))
            {
                string htmlPath = Path.Combine(inputPath, htmlFileName);
                string loaded = File.ReadAllText(htmlPath);
                document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(loaded);

                string directoryPath = Path.Combine(inputPath, photosFolderName);
                string outputFolder = directoryPath;

                if (backup.Checked)
                {
                    outputFolder = Path.Combine(inputPath, newFolderName);
                    Directory.CreateDirectory(outputFolder);
                }
                    

                foreach (String fileName in Directory.GetFiles(directoryPath))
                {
                    string originalFileName = fileName;
                    string dateString = searchHtml(Path.GetFileName(fileName));
                    DateTime date = DateTime.Parse(dateString);
                    string dateName = date.ToString(dateFormat) + imageFormat;
                    string newFileName = Path.Combine(outputFolder, dateName);

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

        private string searchHtml(string image)
        {
            HtmlAgilityPack.HtmlNode node =
    document.DocumentNode.Descendants("img")
                .Where(e => e.GetAttributeValue("src", null).Contains(image))
                .FirstOrDefault();

            return node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.SelectSingleNode(".//div[@class='_3-94 _2lem']").InnerText;
        }
    }
}
