using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallhaven_Random_Wallpaper.Models
{
    public partial class Meta
    {
        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("last_page")]
        public long LastPage { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("query")]
        public object Query { get; set; }

        [JsonProperty("seed")]
        public object Seed { get; set; }
    }
}
