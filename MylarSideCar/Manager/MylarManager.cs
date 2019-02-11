using MylarSideCar.Model;
using System.Collections.Generic;

using Newtonsoft.Json;
using RestSharp;
using MylarSideCar.Manager.Configs;

namespace MylarSideCar.Manager
{
    public class MylarManager
    {
        MylarConfig mylarConfig = null;
        RestClient client = null;

     
  
        private RestClient GetRestClient()
        {
            if(client == null)
            {
                MylarConfig config = GetConfig();
                client = new RestClient(mylarConfig.HostURL);
            }
            return client;
        }

        private MylarConfig GetConfig()
        {
            if(mylarConfig == null)
            {
                mylarConfig = ConfigManager.GetValue<MylarConfig>();
                client = new RestClient(mylarConfig.HostURL);
            }
            return mylarConfig;
        }


        public List<Title> getTitles()
        {
        


            var request = new RestRequest("/", Method.GET);
            request.AddParameter("apikey", GetConfig().APIkey);
            request.AddParameter("cmd", "getIndex");

            IRestResponse response = GetRestClient().Execute(request);
            var content = response.Content;

            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;


            List<Title> outlist = JsonConvert.DeserializeObject<List<Title>>(content, jsonSerializerSettings);
 
            return outlist;

 
        }


        public ComicMaster GetComic(string comicId)
        {

            var request = new RestRequest("/", Method.GET);
            request.AddParameter("apikey", GetConfig().APIkey);
            request.AddParameter("cmd", "getComic");
            request.AddParameter("id", comicId);

            IRestResponse response = GetRestClient().Execute(request);
            var content = response.Content;

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            ComicMaster c = JsonConvert.DeserializeObject<ComicMaster>(content, jsonSerializerSettings);

            return c;

        }

    }

}
