using MylarSideCar.Manager;
using MylarSideCar.Manager.Configs;
using System;
 
using System.Windows.Forms;

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

            }





        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigManager.Save();

            if (!string.IsNullOrEmpty(txtAPIkey.Text))
            {
                var sabConfig = ConfigManager.GetConfig<SabConfig>();
                sabConfig.ApIkey = txtAPIkey.Text;
                sabConfig.HostUrl = txtHost.Text;
                sabConfig.UserName = txtUserName.Text;
                sabConfig.Password = txtPassword.Text;
                sabConfig.Root = txtSabRoot.Text;
                sabConfig.Https = chkSabSsl.Checked;
                if (txtSabPort.Text != null)
                {
                    if (!string.IsNullOrEmpty(txtSabPort.Text))
                        sabConfig.Port = int.Parse(txtSabPort.Text);
                }

                ConfigManager.SetValue(sabConfig);
            }
            if (!string.IsNullOrEmpty(txtMylarApiKey.Text))
            {
                var mylarConfig = ConfigManager.GetConfig<MylarConfig>();
                mylarConfig.APIkey = txtMylarApiKey.Text;
                mylarConfig.HostURL = txtMylarHost.Text;
                mylarConfig.UserName = txtMylarUserName.Text;
                mylarConfig.Password = txtMylarPassword.Text;

                ConfigManager.SetValue(mylarConfig);
            }
             


            ConfigManager.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
