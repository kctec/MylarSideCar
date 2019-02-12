using MylarSideCar.Manager.Configs;
using MylarSideCar.Model.ComicVine;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Windows.Forms;

namespace MylarSideCar.Manager
{
    public class TorzNabManager
    {
        

        private static RestClient GetRestClient(string URI)
        {
            return new RestClient(URI);
        }
 
   


    }
}
