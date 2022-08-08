namespace Wallhaven_Random_Wallpaper
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Wallhaven_Random_Wallpaper.Models;

    public partial class Temperatures
    {
        [JsonProperty("data")]
        public Datum[]? Data { get; set; }

        [JsonProperty("meta")]
        public Meta? Meta { get; set; }
    }

}
