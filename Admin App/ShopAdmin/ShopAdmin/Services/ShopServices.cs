using Newtonsoft.Json;
using ShopAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdmin.Services
{
    public class ShopServices
    {
        HttpClient client = new HttpClient();
        private readonly string Url = "http://192.168.0.12:52447/api/Store";

        public async Task<List<Shop>> GetShops()
        {
            var content = await client.GetStringAsync(Url);
            var shops = JsonConvert.DeserializeObject<List<Shop>>(content);
            return shops;
        }

        public async Task<HttpResponseMessage> UpdateShop(int id, SaveShop saveShop)
        {
            var content = JsonConvert.SerializeObject(saveShop);
            var response= await client.PutAsync(Url+"/"+id.ToString(), new StringContent(content,Encoding.UTF8,"application/json"));
            return response;
        }

        public async Task<HttpResponseMessage> DeleteShop(int id)
        {
            var response = await client.DeleteAsync(Url + "/" + id.ToString());
            return response;
        }

        public async Task<HttpResponseMessage> CreateShop(SaveShop saveShop)
        {
            var content = JsonConvert.SerializeObject(saveShop);
            var response = await client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            return response;
        }
    }
}
