using MylarSideCar.Manager.Configs;
using MylarSideCar.Model.ComicVine;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Windows.Forms;

namespace MylarSideCar.Manager
{
    public class ComicVineManager
    {
        private static ComicVineConfig _comicVineConfig;
        private static RestClient _client;

        private static RestClient GetRestClient()
        {
            return _client ?? (_client = new RestClient("http://www.comicvine.com/api"));
        }

        private static ComicVineConfig GetConfig()
        {
            return _comicVineConfig ?? (_comicVineConfig = ConfigManager.GetConfig<ComicVineConfig>());
        }

        public static CvVolumeResponse GetVolume(string comicId)
        {
            string content;
            var filename = "volume_4050-" + comicId + ".json";

            var path = Path.GetDirectoryName(Application.ExecutablePath) + "\\cvCache\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + filename;
            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }
            else
            {
                var request = new RestRequest("/volume/4050-" + comicId, Method.GET);
                request.AddParameter("api_key", GetConfig().ApiKey);
                request.AddParameter("format", "json");

                var response = GetRestClient().Execute(request);
                content = response.Content;
                File.WriteAllText(path, content);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        

            return JsonConvert.DeserializeObject<CvVolumeResponse>(content, jsonSerializerSettings);

        }

        public static CvPublisherResponse GetPublisher(string publisherId)
        {
            string content;
            var filename = "publisher_40_10-" + publisherId + ".json";

            var path = Path.GetDirectoryName(Application.ExecutablePath) + "\\cvCache\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + filename;
            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }
            else
            {
                var request = new RestRequest("/publisher/4010-" + publisherId, Method.GET);
                request.AddParameter("api_key", GetConfig().ApiKey);
                request.AddParameter("format", "json");

                var response = GetRestClient().Execute(request);
                 content = response.Content;
                File.WriteAllText(path, content);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return JsonConvert.DeserializeObject<CvPublisherResponse>(content, jsonSerializerSettings);

     
        }

        public static CvIssueResponse GetIssue(string issueId)
        {
            string content;
            var filename = "issue_4000-" + issueId + ".json";

            var path = Path.GetDirectoryName(Application.ExecutablePath) + "\\cvCache\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + filename;
            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }
            else
            {
                var request = new RestRequest("/issue/4000-" + issueId, Method.GET);
                request.AddParameter("api_key", GetConfig().ApiKey);
                request.AddParameter("format", "json");

                var response = GetRestClient().Execute(request);
                content = response.Content;
                File.WriteAllText(path, content);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return JsonConvert.DeserializeObject<CvIssueResponse>(content, jsonSerializerSettings);


        }


    }
}
