using System.Collections.Generic;
using System.Text.RegularExpressions;
using MylarSideCar.Manager.Configs;
using MylarSideCar.Manager.NewzNab;
using MylarSideCar.Model;

namespace MylarSideCar.Manager
{
    public class OmgManager
    {
        private const string DefaultUrl = "https://api.nzbgeek.info";

        private static NewzNabSource _source;

        private static OmgConfig _config;

        private static OmgConfig GetConfig()
        {
            return _config ?? (_config = ConfigManager.GetValue<OmgConfig>());
        }

        private static NewzNabSource GetSource()
        {
            return _source ?? (_source = new NewzNabSource(DefaultUrl, true, GetConfig().ApiKey));
        }

        public static List<NewzNabSearchResult> SearchForIssue(Issue issue, Comic comic, bool year, bool issueNum)
        {
            var query = new NewzNabQuery {RequestedFunction = Functions.Search};
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

            var rawData = GetSource().Search(query);

            var parsedResults = new List<NewzNabSearchResult>();

            foreach (var result in rawData)
            {
                if (!result.Category.ToLower().Contains("comic") &&
                    !result.Category.ToLower().Contains("book")) continue;
                if (!TitleParsingManager.TitleMatch(result.Title, issue, comic, year, issueNum)) continue;
                result.Provider = "omgwtfnzbs";
                parsedResults.Add(result);
            }

            return parsedResults;
        }
    }
}