using MylarSideCar.Core;
using MylarSideCar.Forms;
using MylarSideCar.Manager;
using MylarSideCar.Manager.Configs;
using MylarSideCar.Model;
using MylarSideCar.Model.ComicVine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace MylarSideCar
{
    public partial class Main : Form
    {
        static MylarManager titleManager = new MylarManager();
        List<Title> titles = null;
        static MylarManager mylarManager = new MylarManager();
        ComicMaster currentComic = new ComicMaster();
        ComicVineManager comicVineManager = new ComicVineManager();
        CvVolumeResponse currentVolume = null;
        List<NewzNabSearchResult> nzbResults = null;
        NzbSearchManager nzbSearchManager = new NzbSearchManager();
        SabnzbdManager sabnzbdManager = new SabnzbdManager();

        public Main()
        {
            InitializeComponent();
            FormatComicsList();
            FormatIssuesList();

        }

        private void GetData()
        {
            SetStatus("fetching data");


            titles = titleManager.getTitles();
          
            SetStatus("Ready ...");
        }

        void LoadData()
        {
            ConfigManager.Load();
            GetData();
            BindData();
        }

        private void BindData()
        {
            if (titles == null){
                SetStatus("No results from Mylar check config");
            }
            SetStatus("loading");

            lstComics.Items.Clear();

            foreach (Title title in titles)
            {
                if (txtComicFilter.Text == null || txtComicFilter.Text == "")
                {
                    lstComics.Items.Add(title);

                }
                else
                {
                    string[] values = txtComicFilter.Text.ToLower().Split(char.Parse(" "));
                    bool match = true;
                    foreach(string value in values)
                    {
                        if (!title.BindingName.ToLower().Contains(value))
                        {
                            match = false ;
                            break;
                        }
                    }
                    if(match)
                        lstComics.Items.Add(title);
                }
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

        private void SetStatus(String value)
        {
            statusLabel.Text = value;
        }

        private void CinfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config config = new Config();
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
            BindComic((Title)lstComics.Items[lstComics.SelectedIndex]);
 
            tabMain.SelectedIndex = 0;
            BindIssues();
            lstNZBResults.Items.Clear();
            SetStatus("Ready ...");

        }

        private void LstComics_DrawItem(object sender, DrawItemEventArgs e)
        {
           
            if (e.Index < 0)
            {
                return;
            }
            Title title = (Title)lstComics.Items[e.Index];

            if (title.Have != title.Total)
            {
                e.Graphics.FillRectangle(Brushes.LightPink, e.Bounds);
            }
            else
            {
                if (e.Index % 2 == 0)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                }
            }
            if (lstComics.SelectedIndex == e.Index)
            {
                e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
                e.Graphics.DrawString(((Title)lstComics.Items[e.Index]).BindingName , this.Font, Brushes.White, 0, e.Bounds.Y + 2);
            }
            else
            {
                e.Graphics.DrawString(((Title)lstComics.Items[e.Index]).BindingName, this.Font, Brushes.Black, 0, e.Bounds.Y + 2);
      
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
            if (e.Index < 0)
            {
                return;
            }
            string identifier = "?";
            Issue issue = (Issue)listIssues.Items[e.Index];
            if (issue.Status=="Downloaded")
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
                e.Graphics.DrawString("[ "+ identifier + " ] - " + issue.BindingName, this.Font, Brushes.White, 0, e.Bounds.Y + 2);
            }
            else
            {
                e.Graphics.DrawString("[ " + identifier + " ] - " + issue.BindingName, this.Font, Brushes.Black, 0, e.Bounds.Y + 2);
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
            currentComic = mylarManager.GetComic(title.ComicID);
            comicImage.Image = ImageCacheManager.GetImage(currentComic.Comics[0].ComicImageURL);


            currentVolume = comicVineManager.GetVolume(title.ComicID);
            webDescription.DocumentText = "0";
            webDescription.Document.OpenNew(true);
            webDescription.Document.Write(currentVolume.Volume.Description);
            webDescription.Refresh();

            CvPublisherResponse pub = comicVineManager.GetPublisher(currentVolume.Volume.Publisher.Id);
            imgPublisher.Image = ImageCacheManager.GetImage(pub.Publisher.Image.IconUrl);
            
        }

        private void BindIssues()
        {
            listIssues.DrawItem -= ListIssues_DrawItem;
            listIssues.Items.Clear();
            foreach(Issue issue in currentComic.Issues)
            {
                listIssues.Items.Add(issue);
            }
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
            nzbResults = nzbSearchManager.SearchForIssue((Issue)listIssues.SelectedItem, currentComic.Comics[0]);
            lstNZBResults.Items.Clear();
            foreach (var result in nzbResults)
            {
                lstNZBResults.Items.Add(result);
            }

            if (nzbResults == null || nzbResults.Count == 0)
            {
                SetStatus("No Results found");
            }
            else
            {
                SetStatus("Search Complete - " + nzbResults.Count + " results found");
            }
          
        }

        private void btnSendToSab_Click(object sender, EventArgs e)
        {
            NewzNabSearchResult result = (NewzNabSearchResult)lstNZBResults.SelectedItem;
            SabnzbdManager.UploadNzb(result, (Issue)listIssues.SelectedItem, currentComic.Comics[0]);
        }
    }
}
