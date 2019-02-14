using MylarSideCar.Manager;
using MylarSideCar.Manager.Configs;
using System;
 
using System.Windows.Forms;
using NewzNabConfig = MylarSideCar.Manager.Configs.NewzNabConfig;

namespace MylarSideCar.Forms
{
    public partial class Config : Form
    {
 
        public Config()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {


            if (ConfigManager.HasValue<ComicVineConfig>())
            {
                var comicVineConfig = ConfigManager.GetConfig<ComicVineConfig>();
                txtComicVineApiKey.Text = comicVineConfig.ApiKey;

            }

            if (ConfigManager.HasValue<RTorrentConfig>())
            {
                var rTorrentConfig = ConfigManager.GetConfig<RTorrentConfig>();
                txtRTorrentHost.Text = rTorrentConfig.Host;
                txtRTorrentPassword.Text = rTorrentConfig.Password;
                txtRTorrentUrlBase.Text = rTorrentConfig.UrlBase;
                txtRTorrentUserName.Text = rTorrentConfig.Username;
                chkRTorrentHttps.Checked = rTorrentConfig.UseSsl;
                txtRTorrentPort.Text = rTorrentConfig.Port;

            }

            if (ConfigManager.HasValue<SabConfig>())
            {
                var sabConfig = ConfigManager.GetConfig<SabConfig>();
                txtAPIkey.Text = sabConfig.ApIkey;
                txtHost.Text = sabConfig.HostUrl;
                txtUserName.Text = sabConfig.UserName;
                txtPassword.Text = sabConfig.Password;
                txtSabRoot.Text = sabConfig.Root;
                chkSabSsl.Checked = sabConfig.Https;
   
                txtSabPort.Text = sabConfig.Port.ToString();
            }
            if (ConfigManager.HasValue<MylarConfig>())
            {
                var mylarConfig = ConfigManager.GetConfig<MylarConfig>();
                txtMylarApiKey.Text = mylarConfig.APIkey;
                txtMylarHost.Text = mylarConfig.HostURL;
                txtMylarUserName.Text = mylarConfig.UserName;
                txtMylarPassword.Text = mylarConfig.Password;
            }

            if (ConfigManager.HasValue<NewzNabConfig>())
            {
                var newzNabConfig = ConfigManager.GetConfig<NewzNabConfig>();
                txtNewzName1.Text = newzNabConfig.NewzNabName_1;
                txtNewzHost1.Text = newzNabConfig.NewzNabURL_1;
                txtNewzApi1.Text = newzNabConfig.NewzNabApiKey_1;
                chkNewzNabEnabled1.Checked = newzNabConfig.NewzNabEnabled_1;
 
                txtNewzName2.Text = newzNabConfig.NewzNabName_2;
                txtNewzHost2.Text = newzNabConfig.NewzNabURL_2;
                txtNewzApi2.Text = newzNabConfig.NewzNabApiKey_2;
                chkNewzNabEnabled2.Checked = newzNabConfig.NewzNabEnabled_2;
 
                txtNewzName3.Text = newzNabConfig.NewzNabName_3;
                txtNewzHost3.Text = newzNabConfig.NewzNabURL_3;
                txtNewzApi3.Text = newzNabConfig.NewzNabApiKey_3;
                chkNewzNabEnabled3.Checked = newzNabConfig.NewzNabEnabled_3;
 
                txtNewzName4.Text = newzNabConfig.NewzNabName_4;
                txtNewzHost4.Text = newzNabConfig.NewzNabURL_4;
                txtNewzApi4.Text = newzNabConfig.NewzNabApiKey_4;
                chkNewzNabEnabled4.Checked = newzNabConfig.NewzNabEnabled_4;

            }

            if (ConfigManager.HasValue<TorzNabConfig>())
            {
                var torzNabConfig = ConfigManager.GetConfig<TorzNabConfig>();
                txtTorzNabName1.Text = torzNabConfig.TorzNabName_1;
                txtTorzNabHost1.Text = torzNabConfig.TorzNabURL_1;
                txtTorzNabApiKey1.Text = torzNabConfig.TorzNabApiKey_1;
                chkTorzNabEnabled1.Checked = torzNabConfig.TorzNabEnabled_1;

                txtTorzNabName2.Text = torzNabConfig.TorzNabName_2;
                txtTorzNabHost2.Text = torzNabConfig.TorzNabURL_2;
                txtTorzNabApiKey2.Text = torzNabConfig.TorzNabApiKey_2;
                chkTorzNabEnabled2.Checked = torzNabConfig.TorzNabEnabled_2;

                txtTorzNabName3.Text = torzNabConfig.TorzNabName_3;
                txtTorzNabHost3.Text = torzNabConfig.TorzNabURL_3;
                txtTorzNabApiKey3.Text = torzNabConfig.TorzNabApiKey_3;
                chkTorzNabEnabled3.Checked = torzNabConfig.TorzNabEnabled_3;

                txtTorzNabName4.Text = torzNabConfig.TorzNabName_4;
                txtTorzNabHost4.Text = torzNabConfig.TorzNabURL_4;
                txtTorzNabApiKey4.Text = torzNabConfig.TorzNabApiKey_4;
                chkTorzNabEnabled4.Checked = torzNabConfig.TorzNabEnabled_4;

                txtLinkSubFind.Text = torzNabConfig.LinkSubFind;
                txtLinkSubReplace.Text = torzNabConfig.LinkSubReplace;
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtRTorrentHost.Text))
            {
                var rTorrentConfig = ConfigManager.GetConfig<RTorrentConfig>();
                rTorrentConfig.Password = txtRTorrentPassword.Text;
                rTorrentConfig.Host = txtRTorrentHost.Text;
                rTorrentConfig.Port = txtRTorrentPort.Text;
                rTorrentConfig.UrlBase = txtRTorrentUrlBase.Text;
                rTorrentConfig.UseSsl = chkRTorrentHttps.Checked;
                rTorrentConfig.Username = txtRTorrentUserName.Text;
                ConfigManager.SetConfigValue(rTorrentConfig);
            }

            if (!string.IsNullOrEmpty(txtComicVineApiKey.Text))
            {
                var comicVineConfig = new ComicVineConfig()
                {
                    ApiKey = txtComicVineApiKey.Text
                };

                ConfigManager.SetConfigValue(comicVineConfig);

            }


            if (!string.IsNullOrEmpty(txtAPIkey.Text))
            {
                var sabConfig = new SabConfig
                {
                    ApIkey = txtAPIkey.Text,
                    HostUrl = txtHost.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    Root = txtSabRoot.Text,
                    Https = chkSabSsl.Checked
                };
                if (txtSabPort.Text != null)
                {
                    if (!string.IsNullOrEmpty(txtSabPort.Text))
                        sabConfig.Port = int.Parse(txtSabPort.Text);
                }

                ConfigManager.SetConfigValue(sabConfig);
            }
            if (!string.IsNullOrEmpty(txtMylarApiKey.Text))
            {
                var mylarConfig = new MylarConfig
                {
                    APIkey = txtMylarApiKey.Text,
                    HostURL = txtMylarHost.Text,
                    UserName = txtMylarUserName.Text,
                    Password = txtMylarPassword.Text
                };

                ConfigManager.SetConfigValue(mylarConfig);
            }

            if (!string.IsNullOrEmpty(txtTorzNabHost1.Text) || !string.IsNullOrEmpty(txtTorzNabHost2.Text) ||
                !string.IsNullOrEmpty(txtTorzNabHost3.Text) || !string.IsNullOrEmpty(txtTorzNabHost4.Text))
            {
                var torzNabConfig = new TorzNabConfig
                {
                    TorzNabName_1 = txtTorzNabName1.Text,
                    TorzNabApiKey_1 = txtTorzNabApiKey1.Text,
                    TorzNabURL_1 = txtTorzNabHost1.Text,
                    TorzNabEnabled_1 = chkTorzNabEnabled1.Checked,
                    TorzNabName_2 = txtTorzNabName2.Text,
                    TorzNabApiKey_2 = txtTorzNabApiKey2.Text,
                    TorzNabURL_2 = txtTorzNabHost2.Text,
                    TorzNabEnabled_2 = chkTorzNabEnabled2.Checked,
                    TorzNabName_3 = txtTorzNabName3.Text,
                    TorzNabApiKey_3 = txtTorzNabApiKey3.Text,
                    TorzNabURL_3 = txtTorzNabHost3.Text,
                    TorzNabEnabled_3 = chkTorzNabEnabled3.Checked,
                    TorzNabName_4 = txtTorzNabName4.Text,
                    TorzNabApiKey_4 = txtTorzNabApiKey4.Text,
                    TorzNabURL_4 = txtTorzNabHost4.Text,
                    TorzNabEnabled_4 = chkTorzNabEnabled4.Checked,
                    LinkSubFind = txtLinkSubFind.Text,
                    LinkSubReplace = txtLinkSubReplace.Text

                };




                ConfigManager.SetConfigValue(torzNabConfig);
            }

            if (!string.IsNullOrEmpty(txtNewzHost1.Text) || !string.IsNullOrEmpty(txtNewzHost2.Text) ||
                !string.IsNullOrEmpty(txtNewzHost3.Text) || !string.IsNullOrEmpty(txtNewzHost4.Text))
            {
                var newzNabConfig = new NewzNabConfig
                {
                    NewzNabName_1 = txtNewzName1.Text,
                    NewzNabApiKey_1 = txtNewzApi1.Text,
                    NewzNabURL_1 = txtNewzHost1.Text,
                    NewzNabEnabled_1 = chkNewzNabEnabled1.Checked,
                    NewzNabName_2 = txtNewzName2.Text,
                    NewzNabApiKey_2 = txtNewzApi2.Text,
                    NewzNabURL_2 = txtNewzHost2.Text,
                    NewzNabEnabled_2 = chkNewzNabEnabled2.Checked,
                    NewzNabName_3 = txtNewzName3.Text,
                    NewzNabApiKey_3 = txtNewzApi3.Text,
                    NewzNabURL_3 = txtNewzHost3.Text,
                    NewzNabEnabled_3 = chkNewzNabEnabled3.Checked,
                    NewzNabName_4 = txtNewzName4.Text,
                    NewzNabApiKey_4 = txtNewzApi4.Text,
                    NewzNabURL_4 = txtNewzHost4.Text,
                    NewzNabEnabled_4 = chkNewzNabEnabled4.Checked
                };
 
                ConfigManager.SetConfigValue(newzNabConfig);

            }


            ConfigManager.Save();

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
