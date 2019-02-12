using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SabSharp;
using Vars;

namespace MylarSideCar.Manager.Sabnzbd
{
    public class SabnzbdClient : SabClient
    {
        private readonly string _host;
        private readonly ushort _port;
        private readonly string _apikey;
        private readonly string _root;
        private readonly bool _ssl;

        public SabnzbdClient(string host, ushort port, string apikey, string root, bool ssl) : base(host, port, apikey)
        {
            _host = host;
            _port = port;
            _apikey = apikey;
            _root = root;
            _ssl = ssl;
        }

        public SabnzbdClient(string host, ushort port, string apikey) : base(host, port, apikey)
        {

        }

        private string SendSabApiRequest(string getparams)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "SabSharp");

            if (_port > 0)
            {
                if (!_ssl)
                {
                    return httpClient.GetStringAsync(string.Format("http://{0}:{1}/{4}/api?output=json&apikey={2}&{3}",
                        _host, _port, _apikey, getparams,_root)).Result;
                }
                return httpClient.GetStringAsync(string.Format("https://{0}:{1}/{4}/api?output=json&apikey={2}&{3}",
                    _host, _port, _apikey, getparams, _root)).Result;

            }
            if (!_ssl)
            {
                return httpClient.GetStringAsync(string.Format("http://{0}/{3}/api?output=json&apikey={1}&{2}",
                    _host , _apikey, getparams, _root)).Result;
            }

            string uri = string.Format("https://{0}/{3}/api?output=json&apikey={1}&{2}",
                _host, _apikey,  getparams, _root);
            return httpClient.GetStringAsync(uri).Result;

        }


        public new SabAddResponse AddQueue(string nzbUri, string nzbName = "", string category = "*", string script = "Default", short priority = -100, short postProcessParams = -1)
        {
            return SabAddResponse.FromJson(SendSabApiRequest(
                $"mode=addurl&name={HttpUtility.UrlEncode(nzbUri)}&nzbname={nzbName}&cat={category}&script={script}" +
                $"&priority={priority}&pp={postProcessParams}"));
        }

      
 
    }
}
