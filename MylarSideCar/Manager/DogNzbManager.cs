using MylarSideCar.Manager.Configs;
using MylarSideCar.Manager.NewzNab;
using MylarSideCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace MylarSideCar.Manager
{
    public class DogNzbManager
    {

        private NewzNabSource source = null;
        private const string DEFAULT_URL = "https://api.dognzb.cr";
        DogNzbConfig config = null;

        private DogNzbConfig GetConfig()
        {
            if (config == null)
            {
                config = ConfigManager.GetValue<DogNzbConfig>();
            }
            return config;
        }

        private NewzNabSource GetSource()
        {
            if (source == null)
            {
                source = new NewzNabSource(DEFAULT_URL, true, GetConfig().ApiKey);
            }
            return source;
        }

        public List<NewzNabSearchResult> SearchForIssue(Issue issue, Comic comic, bool year, bool issueNum)
        {
            NewzNabQuery query = new NewzNabQuery();
            query.RequestedFunction = Functions.Search;
            query.Groups.Add("alt.binaries.ebook");
            query.Groups.Add("alt.binaries.comics");
            query.Groups.Add("alt.binaries.comics.dcp");
            query.Groups.Add("alt.binaries.comics.repost");
            query.Groups.Add("alt.binaries.pictures.comics");
            query.Groups.Add("alt.binaries.pictures.comics.dcp");
            query.Groups.Add("alt.binaries.pictures.comics.repost");
            query.Groups.Add(" alt.binaries.pictures.comics.reposts");
            query.Groups.Add("alt.binaries.manga");
            query.Groups.Add("alt.binaries.mangas");
            query.Groups.Add("alt.binaries.pictures.comics.complete");
            query.Query = Regex.Replace(issue.ComicName, "[^a-zA-Z0-9_]+", " ");

            List<NewzNabSearchResult> rawData = GetSource().Search(query);

            List<NewzNabSearchResult> parsedResults = new List<NewzNabSearchResult>();


            foreach (var result in rawData)
            {
                if (!result.Category.ToLower().Contains("comic") &&
                    !result.Category.ToLower().Contains("book")) continue;
                if (!TitleParseingManager.TitleMatch(result.Title, issue, comic, year, issueNum)) continue;
               
                result.Provider = "DogNzb";
                parsedResults.Add(result);

            }

            return parsedResults;
        }
    }
}
