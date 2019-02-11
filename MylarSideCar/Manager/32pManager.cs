using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Manager
{
    public class ThirtyTwoPagesSessionManager
    {
        private const string BASE_32P_URI = "https://32pag.es/user.php?action=notify";

        //RestClient client = new RestClient(BASE_32P_URI);
        WebClient client = null;

        public void OpenSession()
        {
            client = client = CloudflareEvader.CreateBypassedWebClient(BASE_32P_URI);
            // var request = new RestRequest("/", Method.GET);
         

            
        }
    }
}
