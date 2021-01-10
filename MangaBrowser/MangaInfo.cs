using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MangaBrowser
{
    public class MangaInfo
    {
        // All Details of the Manga from file: details.json
        [JsonProperty("title")]
        public string title { get; set; } = "Unknown";

        [JsonProperty("titleRomaji")]
        public string titleRomaji { get; set; } = "";

        [JsonProperty("author")]
        public string author { get; set; } = "Unknown";

        [JsonProperty("artist")]
        public string artist { get; set; } = "Unknown";

        [JsonProperty("description")]
        public string description { get; set; } = "Unknown";

        [JsonProperty("genre")]
        public string[] genre { get; set; } =  { "Unknown" };

        [JsonProperty("status")]
        public string status { get; set; } = "0";

    }
}
