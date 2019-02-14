using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MylarSideCar.Core;
using MylarSideCar.Forms;
using MylarSideCar.Manager;
using MylarSideCar.Model;
using MylarSideCar.Model.ComicVine;

namespace MylarSideCar
{
    public partial class Main : Form
    {
        private ComicMaster _currentComic = new ComicMaster();
        private CvVolumeResponse _currentVolume;
        private List<NewzNabSearchResult> _nzbResults;
        private List<TorzNabResult> _torzNabResults;
        private List<Title> _titles;

        public Main()
        {
            InitializeComponent();
            FormatComicsList();
            FormatIssuesList();
            ClearAll();
        }

        private void GetData()
        {
            SetStatus("fetching data");


            _titles = MylarManager.GetTitles();

            SetStatus("Ready ...");
        }

        private void LoadData()
        {
            ConfigManager.Load();
            GetData();
            BindData();
        }

        private void BindData()
        {
            if (_titles == null)
            {
                SetStatus("No results from Mylar check config");
                return;
            }
        

        SetStatus("loading");

            lstComics.Items.Clear();

            foreach (var title in _titles)
                if (string.IsNullOrEmpty(txtComicFilter.Text))
                {
                    lstComics.Items.Add(title);
                }
                else
                {
                    var values = txtComicFilter.Text.ToLower().Split(char.Parse(" "));
                    var match = values.All(value => title.BindingName.ToLower().Contains(value));
                    if (match)
                        lstComics.Items.Add(title);
                }


            SetStatus("ready ...");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetStatus(string value)
        {
            lblStatus.Text = value;
        }

        private void CinfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var config = new Config();
            config.ShowDialog();
        }


        private void FormatComicsList()
        {
            lstComics.DrawMode = DrawMode.OwnerDrawFixed;
            lstComics.ItemHeight += 5;
            lstComics.DrawItem += LstComics_DrawItem;
            lstComics.SelectedIndexChanged += LstComics_SelectedIndexChanged;
        }

        private void LstComics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstComics.SelectedIndex < 0) return;
            ClearSearchResults();

            lstComics.Refresh();
            BindComic((Title) lstComics.Items[lstComics.SelectedIndex]);

            tabMain.SelectedIndex = 0;
            BindIssues();
            lstNZBResults.Items.Clear();
            SetStatus("Ready ...");
        }

        private void LstComics_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var title = (Title) lstComics.Items[e.Index];

            if (title.Have != title.Total)
            {
                e.Graphics.FillRectangle(Brushes.LightPink, e.Bounds);
            }
            else
            {
                if (e.Index % 2 == 0) e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            }

            if (lstComics.SelectedIndex == e.Index)
            {
                e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                e.Graphics.DrawString(((Title) lstComics.Items[e.Index]).BindingName, Font, Brushes.White, 0,
                    e.Bounds.Y + 2);
            }
            else
            {
                e.Graphics.DrawString(((Title) lstComics.Items[e.Index]).BindingName, Font, Brushes.Black, 0,
                    e.Bounds.Y + 2);
            }
        }

        private void BtnFilterComics_Click(object sender, EventArgs e)
        {
            lstComics.DrawItem -= LstComics_DrawItem;
            BindData();
            lstComics.DrawItem += LstComics_DrawItem;
            lstComics.Refresh();
        }

        private void FormatIssuesList()
        {
            lstIssues.DrawMode = DrawMode.OwnerDrawFixed;
            lstIssues.ItemHeight += 5;
            lstIssues.DrawItem += ListIssues_DrawItem;
            lstIssues.SelectedIndexChanged += ListIssues_SelectedIndexChanged;
        }

        private void ListIssues_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var identifier = "?";
            var issue = (Issue) lstIssues.Items[e.Index];
            if (issue.Status == "Downloaded")
            {
                identifier = "+";
                e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds);
            }

            if (issue.Status == "Snatched")
            {
                identifier = "$";
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }

            if (issue.Status == "Archived")
            {
                identifier = "@";
                e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, e.Bounds);
            }

            if (issue.Status == "Wanted")
            {
                identifier = "-";
                e.Graphics.FillRectangle(Brushes.LightSalmon, e.Bounds);
            }

            if (issue.Status == "Skipped")
            {
                identifier = "*";
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            }

            if (lstIssues.SelectedIndex == e.Index)
            {
                e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                e.Graphics.DrawString("[ " + identifier + " ] - " + issue.BindingName, Font, Brushes.White, 0,
                    e.Bounds.Y + 2);
            }
            else
            {
                e.Graphics.DrawString("[ " + identifier + " ] - " + issue.BindingName, Font, Brushes.Black, 0,
                    e.Bounds.Y + 2);
            }
        }

        private void ListIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            lstIssues.Refresh();
            
            ClearSearchResults();
            if (lstIssues.SelectedIndex < 0) return;
            string issueId = ((Issue) lstIssues.SelectedItem).IssueID;
            lblComicName.Text = _currentComic.Comics[0].ComicName;
            lblComicName.Text += @"  (" + _currentVolume.Volume.StartYear + @") " + @" Issue #" + ((Issue)lstIssues.SelectedItem).Issue_Number;
            CvIssueResponse issue = ComicVineManager.GetIssue(issueId);
            webDetails.DocumentText = "0";
            if (webDetails.Document != null)
            {
                webDetails.Document.OpenNew(true);
                webDetails.Document.Write(issue.Issue.Description);
            }

            webDetails.Refresh();
            if (issue.Issue.Image != null)
            {
                if (!string.IsNullOrEmpty(issue.Issue.Image.LargeUrl))
                {
                   imgDetail.Image = ImageCacheManager.GetImage( issue.Issue.Image.LargeUrl);
                }
                else
                {
                    imgDetail.Image = ImageCacheManager.GetImage(_currentComic.Comics[0].ComicImageURL);

                }
            }



            SetStatus("Ready ...");
        }

        private void BindComic(Title title)
        {
            _currentComic = MylarManager.GetComic(title.ComicID);
  
            imgDetail.Image = ImageCacheManager.GetImage(_currentComic.Comics[0].ComicImageURL);
            lblComicName.Text = _currentComic.Comics[0].ComicName; 

            _currentVolume = ComicVineManager.GetVolume(title.ComicID);
            lblComicName.Text += @"  (" + _currentVolume.Volume.StartYear + @")";

            webDetails.DocumentText = "0";
            if (webDetails.Document != null)
            {
                webDetails.Document.OpenNew(true);
                webDetails.Document.Write(_currentVolume.Volume.Description);
            }

            webDetails.Refresh();

            var pub = ComicVineManager.GetPublisher(_currentVolume.Volume.Publisher.Id);
            imgPublisher.Image = ImageCacheManager.GetImage(pub.Publisher.Image.IconUrl);

        }

        private void BindIssues()
        {
            lstIssues.DrawItem -= ListIssues_DrawItem;
            lstIssues.Items.Clear();
            foreach (var issue in _currentComic.Issues) lstIssues.Items.Add(issue);
            lstIssues.DrawItem += ListIssues_DrawItem;
            lstIssues.Refresh();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            ClearAll();
            LoadData();
        }


        private void btnSearchIssue_Click(object sender, EventArgs e)
        {

            if (lstIssues.SelectedIndex < 0) return;
            ClearSearchResults();

            SetStatus("Searching ...");

            _nzbResults = NzbSearchManager.Search((Issue) lstIssues.SelectedItem, _currentComic.Comics[0]);
            _torzNabResults =
                TorzNabSearchManager.Search((Issue)lstIssues.SelectedItem, _currentComic.Comics[0]);

            foreach (var result in _nzbResults) lstNZBResults.Items.Add(result);
            foreach (var result in _torzNabResults) lstTorrentResults.Items.Add(result);

            if ((_nzbResults == null || _nzbResults.Count == 0) && (_torzNabResults == null || _torzNabResults.Count == 0))
                SetStatus("No Results found");
            else
                SetStatus("Search Complete - " +  (_nzbResults.Count + _torzNabResults.Count)   + " results found");
        }

        private void btnSendToSab_Click(object sender, EventArgs e)
        {
            var result = (NewzNabSearchResult) lstNZBResults.SelectedItem;
            SabnzbdManager.UploadNzb(result, (Issue) lstIssues.SelectedItem, _currentComic.Comics[0]);
        }

        private void btnSearchComic_Click(object sender, EventArgs e)
        {

            if (lstComics.SelectedIndex < 0) return;
    
            ClearSearchResults();

            SetStatus("Searching ...");

            _nzbResults = NzbSearchManager.Search( _currentComic.Comics[0]);
            _torzNabResults =
                TorzNabSearchManager.Search(_currentComic.Comics[0]);

            foreach (var result in _nzbResults) lstNZBResults.Items.Add(result);
            foreach (var result in _torzNabResults) lstTorrentResults.Items.Add(result);

            if ((_nzbResults == null || _nzbResults.Count == 0) && (_torzNabResults == null || _torzNabResults.Count == 0))
                SetStatus("No Results found");
            else
                SetStatus("Search Complete - " + (_nzbResults.Count + _torzNabResults.Count) + " results found");
        }

        private void btnAddToRTorrnt_Click(object sender, EventArgs e)
        {
            RTorrentManager.AddTorrent((TorzNabResult)lstTorrentResults.SelectedItem);
        }


        private void ClearAll()
        {
            ClearSearchResults();


            lstIssues.Items.Clear();
            lstComics.Items.Clear();

            webDetails.DocumentText = "0";
            if (webDetails.Document != null)
            {
                webDetails.Document.OpenNew(true);
                webDetails.Document.Write("");
            }

            webDetails.Refresh();

            imgDetail.Image = null;

            lblComicInfo.Text = null;
            lblComicName.Text = null;

            imgPublisher.Image = null;

        }

        private void ClearSearchResults()
        {
            lstTorrentResults.Items.Clear();
            lstNZBResults.Items.Clear();
            txtTorrentFilter.Text = "";
            txtNzbResultsFilter.Text = "";
        }

        private void txtComicFilter_Leave(object sender, EventArgs e)
        {
            lstComics.DrawItem -= LstComics_DrawItem;
            BindData();
            lstComics.DrawItem += LstComics_DrawItem;
            lstComics.Refresh();
        }

        private void txtComicFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Return)

            {
                lstComics.DrawItem -= LstComics_DrawItem;
                BindData();
                lstComics.DrawItem += LstComics_DrawItem;
                lstComics.Refresh();
            }
        }

        private void txtNzbResultsFilter_Leave(object sender, EventArgs e)
        {
            FilterNzbs();
        }

        private void FilterNzbs()
        {
            lstNZBResults.Items.Clear();

            string[] values = txtNzbResultsFilter.Text.Split(' ');
            foreach (var nzbResult in _nzbResults)
            {
                bool found = true;
                foreach (var value in values)
                    if (!nzbResult.Description.ToLower().Contains(value.ToLower()))
                    {
                        found = false;
                        break;
                    }

                if (found)
                {
                    lstNZBResults.Items.Add(nzbResult);
                }
            }
        }

        private void txtNzbResultsFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char) Keys.Return)

            {
                FilterNzbs();
            }
        }

        private void FilterTors()
        {
            lstTorrentResults.Items.Clear();

            string[] values = txtTorrentFilter.Text.Split(' ');
            foreach (var result in _torzNabResults)
            {
                bool found = true;
                foreach (var value in values)
                    if (!result.Description.ToLower().Contains(value.ToLower()))
                    {
                        found = false;
                        break;
                    }

                if (found)
                {
                    lstTorrentResults.Items.Add(result);
                }
            }
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            FilterTors();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Return)

            {
                FilterTors();
            }
        }
    }
}