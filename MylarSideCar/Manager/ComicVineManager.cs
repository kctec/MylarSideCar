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
        ComicVineConfig comicVineConfig = null;
        RestClient client = null;



        private RestClient GetRestClient()
        {
            if (client == null)
            {
                client = new RestClient("http://www.comicvine.com/api");
            }
            return client;
        }

        private ComicVineConfig GetConfig()
        {
            if (comicVineConfig == null)
            {
                comicVineConfig = ConfigManager.GetValue<ComicVineConfig>();
               
            }
            return comicVineConfig;
        }

        public CvVolumeResponse GetVolume(string comicId)
        {
            string content = null;
            string filename = "volume_4050-" + comicId + ".json";

            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\cvCache\\";
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

                IRestResponse response = GetRestClient().Execute(request);
                content = response.Content;
                System.IO.File.WriteAllText(path, content);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        

            CvVolumeResponse v = JsonConvert.DeserializeObject<CvVolumeResponse>(content, jsonSerializerSettings);

            return v;

        }

        public CvPublisherResponse GetPublisher(string publisherId)
        {
            string content = null;
            string filename = "publisher_40_10-" + publisherId + ".json";

            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\cvCache\\";
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

                IRestResponse response = GetRestClient().Execute(request);
                 content = response.Content;
                System.IO.File.WriteAllText(path, content);
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            CvPublisherResponse v = JsonConvert.DeserializeObject<CvPublisherResponse>(content, jsonSerializerSettings);

            return v;

        }


    }
}
