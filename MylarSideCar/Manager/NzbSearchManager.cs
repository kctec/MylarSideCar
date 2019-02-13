using MylarSideCar.Manager.Configs;
using MylarSideCar.Model;
using System.Collections.Generic;

namespace MylarSideCar.Manager
{
    public class NzbSearchManager
    {
        public static List<NewzNabSearchResult> Search(  Comic comic)
        {
            return Search(null, comic);
        }

        public static List<NewzNabSearchResult> Search(Issue issue, Comic comic)
        {
            var results = new List<NewzNabSearchResult>();

            if (!ConfigManager.HasValue<NewzNabConfig>())
            {
                return null;
            }

            var newzNabConfig = ConfigManager.GetConfig<NewzNabConfig>();

            if (!string.IsNullOrEmpty(newzNabConfig.NewzNabURL_1) && newzNabConfig.NewzNabEnabled_1)
            {
                try
                {
                    results.AddRange(NewzNabManager.SearchForIssue(issue, comic, newzNabConfig.NewzNabURL_1,
                        newzNabConfig.NewzNabApiKey_1, newzNabConfig.NewzNabName_1));
                }
                catch
                {
                    //disable provider
                    newzNabConfig.NewzNabEnabled_1 = false;
                    ConfigManager.SetConfigValue(newzNabConfig);
                    ConfigManager.Save();
                }
            }
 
            if (!string.IsNullOrEmpty(newzNabConfig.NewzNabURL_2) && newzNabConfig.NewzNabEnabled_2)
            {
                try
                {
                    results.AddRange(NewzNabManager.SearchForIssue(issue, comic, newzNabConfig.NewzNabURL_2,
                        newzNabConfig.NewzNabApiKey_2, newzNabConfig.NewzNabName_2));
                }
                catch
                {
                    //disable provider
                    newzNabConfig.NewzNabEnabled_1 = false;
                    ConfigManager.SetConfigValue(newzNabConfig);
                    ConfigManager.Save();
                }
            }

            if (!string.IsNullOrEmpty(newzNabConfig.NewzNabURL_3) && newzNabConfig.NewzNabEnabled_3)
            {
                try
                {
                    results.AddRange(NewzNabManager.SearchForIssue(issue, comic, newzNabConfig.NewzNabURL_3,
                        newzNabConfig.NewzNabApiKey_3, newzNabConfig.NewzNabName_3));
                }
                catch
                {
                    //disable provider
                    newzNabConfig.NewzNabEnabled_3 = false;
                    ConfigManager.SetConfigValue(newzNabConfig);
                    ConfigManager.Save();
                }
            }

            if (!string.IsNullOrEmpty(newzNabConfig.NewzNabURL_4) && newzNabConfig.NewzNabEnabled_4)
            {
                try
                {
                    results.AddRange(NewzNabManager.SearchForIssue(issue, comic, newzNabConfig.NewzNabURL_4,
                        newzNabConfig.NewzNabApiKey_4, newzNabConfig.NewzNabName_4));
                }
                catch
                {
                    //disable provider
                    newzNabConfig.NewzNabEnabled_4 = false;
                    ConfigManager.SetConfigValue(newzNabConfig);
                    ConfigManager.Save();
                }
            }


            return results;
        }
    }
}
