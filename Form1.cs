using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TorrentDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static WebBrowser browser = new WebBrowser();
        public HtmlNodeCollection FindTorrents(string query)
        {
            string url = $"https://thepiratebay10.org/search/{query}/1/99/0";
            browser.ScriptErrorsSuppressed = true;
            browser.Navigate(url);

            waitTillLoad(browser);

            HtmlWindow window = browser.Document.Window;
            string str = window.Document.Body.OuterHtml;

            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDoc.LoadHtml(str); 
            HtmlNode node = HtmlDoc.GetElementbyId("searchResult");
            HtmlNodeCollection torrents = node.SelectNodes("//tbody//tr");
            return torrents;
        }

        private static void waitTillLoad(WebBrowser webBrControl)
        {
            WebBrowserReadyState loadStatus;
            int waittime = 100000;
            int counter = 0;
            while (true)
            {
                loadStatus = webBrControl.ReadyState;
                Application.DoEvents();
                if ((counter > waittime) || (loadStatus == WebBrowserReadyState.Uninitialized) || (loadStatus == WebBrowserReadyState.Loading) || (loadStatus == WebBrowserReadyState.Interactive))
                {
                    break;
                }
                counter++;
            }

            counter = 0;
            while (true)
            {
                loadStatus = webBrControl.ReadyState;
                Application.DoEvents();
                if (loadStatus == WebBrowserReadyState.Complete && webBrControl.IsBusy != true)
                {
                    break;
                }
                counter++;
            }
        }

        private void GenerateResults(int index, int panelY, HtmlNode torrent)
        {
            HtmlNode typeNode = torrent.SelectSingleNode(".//td[@class='vertTh']");
            HtmlNode nameNode = torrent.SelectSingleNode(".//div[@class='detName']");
            HtmlNode descNode = torrent.SelectSingleNode(".//font[@class='detDesc']");
            HtmlNode seedNode = torrent.SelectSingleNode(".//td[3]");
            HtmlNode leechNode = torrent.SelectSingleNode(".//td[4]");
            HtmlNode magnetNode = torrent.SelectSingleNode(".//td[2]//a[@title='Download this torrent using magnet']");
            string magnetLink = magnetNode.Attributes["href"].Value;

            Panel panel = new Panel
            {
                Name = "panel" + index,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(0, panelY),
                Size = new Size(770, 64)
            };

            TextBox typeBox = new TextBox
            {
                Font = new Font("Sitka Subheading", 15, FontStyle.Regular),
                Text = typeNode.InnerText.Trim(),
                Size = new Size(100, 64),
                Multiline = true,
                Location = new Point(5, 0),
                ReadOnly = true
            };

            TextBox nameBox = new TextBox
            {
                Font = new Font("Sitka Subheading", 12, FontStyle.Bold),
                Text = nameNode.InnerText.Trim(),
                Size = new Size(373, 32),
                Multiline = true,
                Location = new Point(111, 0),
                BackColor = Color.White,
                ForeColor = Color.DarkBlue,
                ReadOnly = true
            };

            string description = descNode.InnerText.Trim().Replace("&nbsp", " ");
            TextBox descBox = new TextBox
            {
                Font = new Font("Sitka Subheading", 12, FontStyle.Regular),
                Text = description,
                Size = new Size(373, 32),
                Multiline = true,
                Location = new Point(111, 32),
                ReadOnly = true
            };

            Button button = new Button
            {
                Size = new Size(75, 64),
                Location = new Point(503, 0),
                BackgroundImage = Properties.Resources.magnet,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            button.Click += (sender, e) => OpenMagnetLink(magnetLink.ToString());

            Label seedLabel = new Label
            {
                Text = seedNode.InnerText,
                ForeColor = Color.Green,
                Location = new Point(590, 17),
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true
            };

            Label leechLabel = new Label
            {
                Text = leechNode.InnerText,
                ForeColor = Color.Red,
                Location = new Point(640, 17),
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true
            };

            panel.Controls.Add(typeBox);
            panel.Controls.Add(nameBox);
            panel.Controls.Add(descBox);
            panel.Controls.Add(button);
            panel.Controls.Add(seedLabel);
            panel.Controls.Add(leechLabel);

            ResultPanel.Controls.Add(panel);
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string query = SearchText.Text;
            if (query.Length > 0)
            {
                HtmlNodeCollection torrents = FindTorrents(query);
                ResultPanel.Controls.Clear();
                Label resultPanelLabel = new Label
                {
                    Font = new Font("Siyam Rupali", 15, FontStyle.Bold),
                    ForeColor = Color.White,
                    Size = new Size(790, 50),
                    Location = new Point(0, 0)
                };
                if (torrents == null)
                {
                    resultPanelLabel.Text = "No result found for: " + query;
                }
                else
                {
                    int panelY = 40;
                    resultPanelLabel.Text = "Search results for: " + query;
                    for (int i = 0; i < torrents.Count - 1; i++)
                    {
                        GenerateResults(i, panelY, torrents[i]);
                        panelY += 70;
                    }
                }
                ResultPanel.Controls.Add(resultPanelLabel);
                ResultPanel.Visible = true;
                SearchText.Clear();
            }
        }

        private void OpenMagnetLink(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SubmitBtn.PerformClick();
            }
        }

        private void SearchLabel_Click(object sender, EventArgs e)
        {
            SearchText.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
