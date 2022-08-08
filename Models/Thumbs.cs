using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallhaven_Random_Wallpaper.Models
{
    public partial class Thumbs
    {
        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("original")]
        public Uri Original { get; set; }

        [JsonProperty("small")]
        public Uri Small { get; set; }
    }
}
