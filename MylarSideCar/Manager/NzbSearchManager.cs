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
        readonly WsFinderManager wsManager = new WsFinderManager();
        readonly NzbGeekManager nzbGeek = new NzbGeekManager();
        readonly OmgManager omgManager = new OmgManager();
        readonly DogNzbManager dogManager = new DogNzbManager();

        public List<NewzNabSearchResult> SearchForIssue(Issue issue, Comic comic)
        {
            List<NewzNabSearchResult> results = new List<NewzNabSearchResult>();

           // if (ConfigManager.HasValue<WsFinderConfig>())
                //results.AddRange(wsManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<NzbGeekConfig>())
                results.AddRange(nzbGeek.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<OmgConfig>())
                results.AddRange(omgManager.SearchForIssue(issue, comic, true, true));

            if (ConfigManager.HasValue<DogNzbConfig>())
                results.AddRange(dogManager.SearchForIssue(issue, comic, true, true));

            return results;
        }
    }
}
