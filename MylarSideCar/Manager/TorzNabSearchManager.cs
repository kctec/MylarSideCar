using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MylarSideCar.Manager.Configs;
using MylarSideCar.Model;

namespace MylarSideCar.Manager
{
    public class TorzNabSearchManager
    {

        public static List<TorzNabResult> Search( Comic comic)
        {
            return Search(null, comic);
        }
   

    public static List<TorzNabResult> Search(Issue issue, Comic comic)
        {
            var results = new List<TorzNabResult>();

            if (!ConfigManager.HasValue<TorzNabConfig>())
            {
                return null;
            }

            var torzNabConfig = ConfigManager.GetConfig<TorzNabConfig>();

            if (!string.IsNullOrEmpty(torzNabConfig.TorzNabURL_1) && torzNabConfig.TorzNabEnabled_1)
            {
                try
                {
                    results.AddRange(TorzNabManager.SearchIssue(issue, comic, torzNabConfig.TorzNabURL_1,
                        torzNabConfig.TorzNabApiKey_1 ));
                }
                catch(Exception e)
                {
                    //disable provider
                    //torzNabConfig.TorzNabEnabled_1 = false;
                    ConfigManager.SetConfigValue(torzNabConfig);
                    ConfigManager.Save();
                }
            }

           

            return results;
        }
    }
}
