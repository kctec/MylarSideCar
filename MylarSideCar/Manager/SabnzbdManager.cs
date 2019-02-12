using System.Text;
using System.Windows.Forms.VisualStyles;
using MylarSideCar.Manager.Sabnzbd;
using MylarSideCar.Model;

namespace MylarSideCar.Manager
{
 
    public class SabnzbdManager
    {
 
        public static void UploadNzb(NewzNabSearchResult result, Issue issue, Comic comic)
        {
            if (!ConfigManager.HasValue<SabConfig>())
            {
                return;
            }

            var sabConfig = ConfigManager.GetConfig<SabConfig>();

            var host = new StringBuilder();
            

            host.Append(sabConfig.HostUrl);
      

            var client = new SabnzbdClient(sabConfig.HostUrl,ushort.Parse( sabConfig.Port.ToString()),sabConfig.ApIkey,sabConfig.Root,sabConfig.Https);

            client.AddQueue(result.NZBUrl, comic.ComicName_Filesafe.Replace(" ","_") + "_" + issue.Issue_Number, "comics");

        }
         
    }
}

