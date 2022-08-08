using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wallhaven_Random_Wallpaper.Models;

namespace Wallhaven_Random_Wallpaper.Methods
{
    internal class TemperaturesOperations
    {
        public string query { get; set; }
        public TemperaturesOperations(string query)
        {
            this.query = query;
        }
        public async Task<Datum> GetRandomObjectAsync() {
            var result = GetObjectsAsync(query).Result;

            if (result != null)
            {
                int resultcount = result.Data.Length;
                return result.Data[new Random().Next(resultcount)];
            }
            return null;
        }
        public async Task<Temperatures?> GetObjectsAsync(string query)
        {
            HttpClient client = new HttpClient();
            
                HttpResponseMessage response = await client.GetAsync(query);//todo: fix these 
            if (response != null)
            {
                string json =  await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Temperatures>(json);
            }

            return null;
        }
        public Datum GetRandomObject()
        {
            var result = GetObjects(query);

            if (result != null)
            {
                int resultcount = result.Data.Length;
                return result.Data[new Random().Next(resultcount)];
            }
            return null;
        }
        public Temperatures? GetObjects(string query)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(query).Result;//todo: fix these 
            if (response != null)
            {
                string json =  response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Temperatures>(json);
            }

            return null;
        }
    }
}
