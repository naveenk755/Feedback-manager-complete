using MyShopApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyShopApp.Services
{
    public class ShopServices
    {
        HttpClient client = new HttpClient();
        private readonly string Url = "http://192.168.0.12:52447/api/Store";

        public async Task<List<Shops>> GetShops()
        {
            var content = await client.GetStringAsync(Url);
            var shops = JsonConvert.DeserializeObject<List<Shops>>(content);
            return shops;
        }
    }
}
