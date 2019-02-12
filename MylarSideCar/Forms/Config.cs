using MylarSideCar.Manager;
using MylarSideCar.Manager.Configs;
using System;
 
using System.Windows.Forms;

namespace MylarSideCar.Forms
{
    public partial class Config : Form
    {
        private SabConfig _sabConfig = new SabConfig();
        private MylarConfig  _mylarConfig = new MylarConfig();
        private WsFinderConfig _wsFinderConfig = new WsFinderConfig();
        private NzbGeekConfig _nzbGeekConfig = new NzbGeekConfig();
        private OmgConfig _omgConfig = new OmgConfig();
        private DogNzbConfig _dogNzbConfig = new DogNzbConfig();
        private ComicVineConfig _comicVineConfig = new ComicVineConfig();


        public Config()
        {
            InitializeComponent();

            BindData();
        }

        private void BindData()
        {
            if (ConfigManager.HasValue<SabConfig>())
            {
                _sabConfig = ConfigManager.GetValue<SabConfig>();
                txtAPIkey.Text = _sabConfig.ApIkey;
                txtHost.Text = _sabConfig.HostUrl;
                txtUserName.Text = _sabConfig.UserName;
                txtPassword.Text = _sabConfig.Password;
                txtSabRoot.Text = _sabConfig.Root;
                chkSabSsl.Checked = _sabConfig.Https;
   
                txtSabPort.Text = _sabConfig.Port.ToString();
            }
            if (ConfigManager.HasValue<MylarConfig>())
            {
                _mylarConfig = ConfigManager.GetValue<MylarConfig>();
                txtMylarApiKey.Text = _mylarConfig.APIkey;
                txtMylarHost.Text = _mylarConfig.HostURL;
                txtMylarUserName.Text = _mylarConfig.UserName;
                txtMylarPassword.Text = _mylarConfig.Password;
            }

            if (ConfigManager.HasValue<DogNzbConfig>())
            {
                _dogNzbConfig = ConfigManager.GetValue<DogNzbConfig>();
                txtDogNzbApiKey.Text = _dogNzbConfig.ApiKey;
            }

            if (ConfigManager.HasValue<NzbGeekConfig>())
            {
                _nzbGeekConfig = ConfigManager.GetValue<NzbGeekConfig>();
                txtNzbGeekApiKey.Text = _nzbGeekConfig.ApiKey;
            }

            if (ConfigManager.HasValue<OmgConfig>())
            {
                _omgConfig = ConfigManager.GetValue<OmgConfig>();
                txtOmgwtfnzbsApiKey.Text = _omgConfig.ApiKey;
            }

            if (ConfigManager.HasValue<WsFinderConfig>())
            {
                _wsFinderConfig = ConfigManager.GetValue<WsFinderConfig>();
                txtWsFinderApiKey.Text = _dogNzbConfig.ApiKey;
            }

            if (ConfigManager.HasValue<ComicVineConfig>())
            {
                _comicVineConfig = ConfigManager.GetValue<ComicVineConfig>();
                txtComicVineApiKey.Text = _comicVineConfig.ApiKey;
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigManager.Save();

            if (txtAPIkey.Text != null)
            {
                _sabConfig.ApIkey = txtAPIkey.Text;
                _sabConfig.HostUrl = txtHost.Text;
                _sabConfig.UserName = txtUserName.Text;
                _sabConfig.Password = txtPassword.Text;
                _sabConfig.Root = txtSabRoot.Text;
                _sabConfig.Https = chkSabSsl.Checked;
                _sabConfig.Port = int.Parse(txtSabPort.Text);
                ConfigManager.SetValue(_sabConfig);
            }

            if (txtMylarApiKey.Text != null)
            {
                _mylarConfig.APIkey = txtMylarApiKey.Text;
                _mylarConfig.HostURL = txtMylarHost.Text;
                _mylarConfig.UserName = txtMylarUserName.Text;
                _mylarConfig.Password = txtMylarPassword.Text;

                ConfigManager.SetValue(_mylarConfig);
            }
            if (txtNzbGeekApiKey.Text != null)
            {
                _nzbGeekConfig.ApiKey = txtNzbGeekApiKey.Text;
                ConfigManager.SetValue(_nzbGeekConfig);
            }
            if (txtOmgwtfnzbsApiKey.Text != null)
            {
                _omgConfig.ApiKey = txtOmgwtfnzbsApiKey.Text;
                ConfigManager.SetValue(_omgConfig);
            }
            if (txtDogNzbApiKey.Text != null)
            {
                _dogNzbConfig.ApiKey = txtDogNzbApiKey.Text;
                ConfigManager.SetValue(_dogNzbConfig);
            }
            if (txtWsFinderApiKey.Text != null)
            {
                _wsFinderConfig.ApiKey = txtWsFinderApiKey.Text;
                ConfigManager.SetValue(_wsFinderConfig);
            }
            if (txtComicVineApiKey.Text != null)
            {
                _comicVineConfig.ApiKey = txtComicVineApiKey.Text;
                ConfigManager.SetValue(_comicVineConfig);
            }


            ConfigManager.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkSabSsl_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
