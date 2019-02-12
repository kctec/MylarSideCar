using MylarSideCar.Manager.Configs;
using MylarSideCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Manager
{
    public class NzbSearchManager
    {

        public static List<NewzNabSearchResult> SearchForIssue(Issue issue, Comic comic)
        {
            var results = new List<NewzNabSearchResult>();

            if (!ConfigManager.HasValue<NewzNabConfig>())
            {
                return null;
            }

            var newzNabConfig = ConfigManager.GetValue<NewzNabConfig>();

            if (!string.IsNullOrEmpty(newzNabConfig.NewzNabURL_1) && newzNabConfig.NewzNabEnabled_1)
            {
                try
                {
                    results.AddRange(NewzNabManager.SearchForIssue(issue, comic
                }
                catch
                {
                    //disable provider
                    newzNabConfig.NewzNabEnabled_1 = false;
                    ConfigManager.SetValue(newzNabConfig);
                    ConfigManager.Save();
                }
            }

                results.AddRange(WsFinderManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<NzbGeekConfig>())
                results.AddRange(NewzNabManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<OmgConfig>())
                results.AddRange(OmgManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<DogNzbConfig>())
                results.AddRange(DogNzbManager.SearchForIssue(issue, comic, true, true));

            return results;
        }
    }
}
