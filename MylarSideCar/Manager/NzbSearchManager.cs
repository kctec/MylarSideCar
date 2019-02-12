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

            if (ConfigManager.HasValue<WsFinderConfig>())
                results.AddRange(WsFinderManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<NzbGeekConfig>())
                results.AddRange(NzbGeekManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<OmgConfig>())
                results.AddRange(OmgManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<DogNzbConfig>())
                results.AddRange(DogNzbManager.SearchForIssue(issue, comic, true, true));

            return results;
        }
    }
}
