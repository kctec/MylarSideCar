using System.Collections.Generic;

namespace MylarSideCar.Model.ComicVine
{
    public class CvVolumeSearchResponse : CvResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "results")]
        public List<CvVolume> Volumes { get; set; }
    }
}