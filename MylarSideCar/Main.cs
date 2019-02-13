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
            statusLabel.Text = value;
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
            listIssues.DrawMode = DrawMode.OwnerDrawFixed;
            listIssues.ItemHeight += 5;
            listIssues.DrawItem += ListIssues_DrawItem;
            listIssues.SelectedIndexChanged += ListIssues_SelectedIndexChanged;
        }

        private void ListIssues_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var identifier = "?";
            var issue = (Issue) listIssues.Items[e.Index];
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

            if (listIssues.SelectedIndex == e.Index)
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
            listIssues.Refresh();
            lstNZBResults.Items.Clear();
            SetStatus("Ready ...");
        }

        private void BindComic(Title title)
        {
            _currentComic = MylarManager.GetComic(title.ComicID);
            comicImage.Image = ImageCacheManager.GetImage(_currentComic.Comics[0].ComicImageURL);
            lblComicName.Text = _currentComic.Comics[0].ComicName; 

            _currentVolume = ComicVineManager.GetVolume(title.ComicID);
            lblComicName.Text += @"  (" + _currentVolume.Volume.StartYear + @")";

            webComicDescription.DocumentText = "0";
            webComicDescription.Document.OpenNew(true);
            webComicDescription.Document.Write(_currentVolume.Volume.Description);
            webComicDescription.Refresh();

            var pub = ComicVineManager.GetPublisher(_currentVolume.Volume.Publisher.Id);
            imgPublisher.Image = ImageCacheManager.GetImage(pub.Publisher.Image.IconUrl);

        }

        private void BindIssues()
        {
            listIssues.DrawItem -= ListIssues_DrawItem;
            listIssues.Items.Clear();
            foreach (var issue in _currentComic.Issues) listIssues.Items.Add(issue);
            listIssues.DrawItem += ListIssues_DrawItem;
            listIssues.Refresh();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            listIssues.ClearSelected();
            lstComics.ClearSelected();
            lstComics.Items.Clear();
            listIssues.Items.Clear();
            lstNZBResults.Items.Clear();
            lstTorrentResults.Items.Clear();
            LoadData();
        }


        private void btnSearchIssue_Click(object sender, EventArgs e)
        {
            SetStatus("Searching ...");
            _nzbResults = NzbSearchManager.SearchForIssue((Issue) listIssues.SelectedItem, _currentComic.Comics[0]);
            lstNZBResults.Items.Clear();
            foreach (var result in _nzbResults) lstNZBResults.Items.Add(result);
            _torzNabResults =
                TorzNabSearchManager.SearchForIssue((Issue) listIssues.SelectedItem, _currentComic.Comics[0]);
            if (_nzbResults == null || _nzbResults.Count == 0)
                SetStatus("No Results found");
            else
                SetStatus("Search Complete - " + _nzbResults.Count + " results found");
        }

        private void btnSendToSab_Click(object sender, EventArgs e)
        {
            var result = (NewzNabSearchResult) lstNZBResults.SelectedItem;
            SabnzbdManager.UploadNzb(result, (Issue) listIssues.SelectedItem, _currentComic.Comics[0]);
        }
    }
}