namespace MylarSideCar
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cinfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPanelComics = new System.Windows.Forms.TableLayoutPanel();
            this.lstComics = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtComicFilter = new System.Windows.Forms.ToolStripTextBox();
            this.btnFilterComics = new System.Windows.Forms.ToolStripButton();
            this.btnSearchComic = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshData = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMissing = new System.Windows.Forms.ToolStripButton();
            this.btnDownloaded = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearchIssue = new System.Windows.Forms.ToolStripButton();
            this.listIssues = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabComic = new System.Windows.Forms.TabPage();
            this.imgPublisher = new System.Windows.Forms.PictureBox();
            this.txtComicTitle = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webDescription = new System.Windows.Forms.WebBrowser();
            this.comicImage = new System.Windows.Forms.PictureBox();
            this.tabIssue = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webIssueDescription = new System.Windows.Forms.WebBrowser();
            this.imgImage = new System.Windows.Forms.PictureBox();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.searchTable = new System.Windows.Forms.TableLayoutPanel();
            this.lstTorrentResults = new System.Windows.Forms.ListBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendToSab = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lstNZBResults = new System.Windows.Forms.ListBox();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPanelComics.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabComic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPublisher)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comicImage)).BeginInit();
            this.tabIssue.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.searchTable.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 629);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1630, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(48, 17);
            this.statusLabel.Text = "ready ...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1630, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cinfToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.settingsToolStripMenuItem.Text = "&Tools";
            // 
            // cinfToolStripMenuItem
            // 
            this.cinfToolStripMenuItem.Name = "cinfToolStripMenuItem";
            this.cinfToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cinfToolStripMenuItem.Text = "&Configuration";
            this.cinfToolStripMenuItem.Click += new System.EventHandler(this.CinfToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabPanelComics);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1630, 605);
            this.splitContainer1.SplitterDistance = 438;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabPanelComics
            // 
            this.tabPanelComics.ColumnCount = 1;
            this.tabPanelComics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tabPanelComics.Controls.Add(this.lstComics, 0, 1);
            this.tabPanelComics.Controls.Add(this.toolStrip1, 0, 0);
            this.tabPanelComics.Controls.Add(this.toolStrip2, 0, 2);
            this.tabPanelComics.Controls.Add(this.listIssues, 0, 3);
            this.tabPanelComics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanelComics.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tabPanelComics.Location = new System.Drawing.Point(0, 0);
            this.tabPanelComics.Name = "tabPanelComics";
            this.tabPanelComics.RowCount = 4;
            this.tabPanelComics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabPanelComics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabPanelComics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabPanelComics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabPanelComics.Size = new System.Drawing.Size(438, 605);
            this.tabPanelComics.TabIndex = 0;
            // 
            // lstComics
            // 
            this.lstComics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstComics.DisplayMember = "BindingName";
            this.lstComics.FormattingEnabled = true;
            this.lstComics.Location = new System.Drawing.Point(3, 33);
            this.lstComics.Name = "lstComics";
            this.lstComics.Size = new System.Drawing.Size(432, 264);
            this.lstComics.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.txtComicFilter,
            this.btnFilterComics,
            this.btnSearchComic,
            this.btnRefreshData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(438, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel1.Text = "&Comics";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtComicFilter
            // 
            this.txtComicFilter.Name = "txtComicFilter";
            this.txtComicFilter.Size = new System.Drawing.Size(200, 25);
            // 
            // btnFilterComics
            // 
            this.btnFilterComics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFilterComics.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterComics.Image")));
            this.btnFilterComics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilterComics.Name = "btnFilterComics";
            this.btnFilterComics.Size = new System.Drawing.Size(23, 22);
            this.btnFilterComics.Text = "&Filter";
            this.btnFilterComics.ToolTipText = "Filter Resullts";
            this.btnFilterComics.Click += new System.EventHandler(this.BtnFilterComics_Click);
            // 
            // btnSearchComic
            // 
            this.btnSearchComic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchComic.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchComic.Image")));
            this.btnSearchComic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchComic.Name = "btnSearchComic";
            this.btnSearchComic.Size = new System.Drawing.Size(23, 22);
            this.btnSearchComic.Text = "btnComicSearch";
            this.btnSearchComic.ToolTipText = "Search For Pack";
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshData.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshData.Image")));
            this.btnRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshData.Text = "toolStripButton2";
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.btnMissing,
            this.btnDownloaded,
            this.toolStripSeparator1,
            this.btnSearchIssue});
            this.toolStrip2.Location = new System.Drawing.Point(0, 302);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(438, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel2.Text = "Issues";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMissing
            // 
            this.btnMissing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMissing.Image = ((System.Drawing.Image)(resources.GetObject("btnMissing.Image")));
            this.btnMissing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMissing.Name = "btnMissing";
            this.btnMissing.Size = new System.Drawing.Size(23, 22);
            this.btnMissing.Text = "btnWanted";
            this.btnMissing.ToolTipText = "Missing";
            // 
            // btnDownloaded
            // 
            this.btnDownloaded.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDownloaded.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloaded.Image")));
            this.btnDownloaded.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDownloaded.Name = "btnDownloaded";
            this.btnDownloaded.Size = new System.Drawing.Size(23, 22);
            this.btnDownloaded.Text = "toolStripButton2";
            this.btnDownloaded.ToolTipText = "Downloaded Issues";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSearchIssue
            // 
            this.btnSearchIssue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchIssue.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchIssue.Image")));
            this.btnSearchIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchIssue.Name = "btnSearchIssue";
            this.btnSearchIssue.Size = new System.Drawing.Size(23, 22);
            this.btnSearchIssue.Text = "toolStripButton2";
            this.btnSearchIssue.ToolTipText = "Seach For Issue";
            this.btnSearchIssue.Click += new System.EventHandler(this.btnSearchIssue_Click);
            // 
            // listIssues
            // 
            this.listIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listIssues.FormattingEnabled = true;
            this.listIssues.Location = new System.Drawing.Point(3, 335);
            this.listIssues.Name = "listIssues";
            this.listIssues.Size = new System.Drawing.Size(432, 267);
            this.listIssues.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.searchTable);
            this.splitContainer2.Size = new System.Drawing.Size(1188, 605);
            this.splitContainer2.SplitterDistance = 788;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabComic);
            this.tabMain.Controls.Add(this.tabIssue);
            this.tabMain.Controls.Add(this.tabSearch);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(788, 605);
            this.tabMain.TabIndex = 0;
            // 
            // tabComic
            // 
            this.tabComic.Controls.Add(this.imgPublisher);
            this.tabComic.Controls.Add(this.txtComicTitle);
            this.tabComic.Controls.Add(this.groupBox3);
            this.tabComic.Controls.Add(this.comicImage);
            this.tabComic.Location = new System.Drawing.Point(4, 22);
            this.tabComic.Name = "tabComic";
            this.tabComic.Padding = new System.Windows.Forms.Padding(3);
            this.tabComic.Size = new System.Drawing.Size(780, 579);
            this.tabComic.TabIndex = 0;
            this.tabComic.Text = "comic";
            this.tabComic.UseVisualStyleBackColor = true;
            // 
            // imgPublisher
            // 
            this.imgPublisher.Location = new System.Drawing.Point(6, 1);
            this.imgPublisher.Name = "imgPublisher";
            this.imgPublisher.Size = new System.Drawing.Size(36, 36);
            this.imgPublisher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPublisher.TabIndex = 8;
            this.imgPublisher.TabStop = false;
            // 
            // txtComicTitle
            // 
            this.txtComicTitle.Location = new System.Drawing.Point(50, 3);
            this.txtComicTitle.Name = "txtComicTitle";
            this.txtComicTitle.Size = new System.Drawing.Size(522, 20);
            this.txtComicTitle.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webDescription);
            this.groupBox3.Location = new System.Drawing.Point(364, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 542);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Description:";
            // 
            // webDescription
            // 
            this.webDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webDescription.Location = new System.Drawing.Point(3, 16);
            this.webDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.webDescription.Name = "webDescription";
            this.webDescription.Size = new System.Drawing.Size(404, 523);
            this.webDescription.TabIndex = 0;
            // 
            // comicImage
            // 
            this.comicImage.Location = new System.Drawing.Point(6, 41);
            this.comicImage.Name = "comicImage";
            this.comicImage.Size = new System.Drawing.Size(352, 531);
            this.comicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.comicImage.TabIndex = 5;
            this.comicImage.TabStop = false;
            // 
            // tabIssue
            // 
            this.tabIssue.Controls.Add(this.groupBox1);
            this.tabIssue.Controls.Add(this.imgImage);
            this.tabIssue.Location = new System.Drawing.Point(4, 22);
            this.tabIssue.Name = "tabIssue";
            this.tabIssue.Padding = new System.Windows.Forms.Padding(3);
            this.tabIssue.Size = new System.Drawing.Size(780, 579);
            this.tabIssue.TabIndex = 1;
            this.tabIssue.Text = "Issue";
            this.tabIssue.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webIssueDescription);
            this.groupBox1.Location = new System.Drawing.Point(361, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 531);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description:";
            // 
            // webIssueDescription
            // 
            this.webIssueDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webIssueDescription.Location = new System.Drawing.Point(3, 16);
            this.webIssueDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.webIssueDescription.Name = "webIssueDescription";
            this.webIssueDescription.Size = new System.Drawing.Size(313, 512);
            this.webIssueDescription.TabIndex = 0;
            // 
            // imgImage
            // 
            this.imgImage.Location = new System.Drawing.Point(3, 24);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(352, 531);
            this.imgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgImage.TabIndex = 7;
            this.imgImage.TabStop = false;
            // 
            // tabSearch
            // 
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(780, 579);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // searchTable
            // 
            this.searchTable.ColumnCount = 1;
            this.searchTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.searchTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.searchTable.Controls.Add(this.lstTorrentResults, 0, 3);
            this.searchTable.Controls.Add(this.toolStrip3, 0, 0);
            this.searchTable.Controls.Add(this.toolStrip4, 0, 2);
            this.searchTable.Controls.Add(this.lstNZBResults, 0, 1);
            this.searchTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTable.Location = new System.Drawing.Point(0, 0);
            this.searchTable.Name = "searchTable";
            this.searchTable.RowCount = 4;
            this.searchTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.searchTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.searchTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.searchTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.searchTable.Size = new System.Drawing.Size(396, 605);
            this.searchTable.TabIndex = 8;
            // 
            // lstTorrentResults
            // 
            this.lstTorrentResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTorrentResults.DisplayMember = "BindingName";
            this.lstTorrentResults.FormattingEnabled = true;
            this.lstTorrentResults.Location = new System.Drawing.Point(3, 335);
            this.lstTorrentResults.Name = "lstTorrentResults";
            this.lstTorrentResults.Size = new System.Drawing.Size(390, 264);
            this.lstTorrentResults.TabIndex = 8;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripSeparator4,
            this.btnSendToSab});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(396, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel3.Text = "NZB";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSendToSab
            // 
            this.btnSendToSab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSendToSab.Image = ((System.Drawing.Image)(resources.GetObject("btnSendToSab.Image")));
            this.btnSendToSab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendToSab.Name = "btnSendToSab";
            this.btnSendToSab.Size = new System.Drawing.Size(23, 22);
            this.btnSendToSab.Text = "SendToSab";
            this.btnSendToSab.ToolTipText = "Send To Sab";
            this.btnSendToSab.Click += new System.EventHandler(this.btnSendToSab_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripSeparator5});
            this.toolStrip4.Location = new System.Drawing.Point(0, 302);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(396, 25);
            this.toolStrip4.TabIndex = 1;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel4.Text = "Torrents";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // lstNZBResults
            // 
            this.lstNZBResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNZBResults.DisplayMember = "BindingName";
            this.lstNZBResults.FormattingEnabled = true;
            this.lstNZBResults.Location = new System.Drawing.Point(3, 33);
            this.lstNZBResults.Name = "lstNZBResults";
            this.lstNZBResults.Size = new System.Drawing.Size(390, 264);
            this.lstNZBResults.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1630, 651);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Mylar - Side Car Utility";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPanelComics.ResumeLayout(false);
            this.tabPanelComics.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabComic.ResumeLayout(false);
            this.tabComic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPublisher)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comicImage)).EndInit();
            this.tabIssue.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.searchTable.ResumeLayout(false);
            this.searchTable.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cinfToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tabPanelComics;
        private System.Windows.Forms.ListBox lstComics;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtComicFilter;
        private System.Windows.Forms.ToolStripButton btnFilterComics;
        private System.Windows.Forms.ToolStripButton btnSearchComic;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnMissing;
        private System.Windows.Forms.ToolStripButton btnDownloaded;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSearchIssue;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabComic;
        private System.Windows.Forms.TabPage tabIssue;
        private System.Windows.Forms.TableLayoutPanel searchTable;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox comicImage;
        private System.Windows.Forms.ListBox listIssues;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSendToSab;
        private System.Windows.Forms.ListBox lstTorrentResults;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ListBox lstNZBResults;
        private System.Windows.Forms.ToolStripButton btnRefreshData;
        private System.Windows.Forms.WebBrowser webDescription;
        private System.Windows.Forms.PictureBox imgPublisher;
        private System.Windows.Forms.TextBox txtComicTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webIssueDescription;
        private System.Windows.Forms.PictureBox imgImage;
    }
}

