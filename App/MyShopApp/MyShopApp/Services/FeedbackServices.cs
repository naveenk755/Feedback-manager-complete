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
    public class FeedbackServices
    {
        HttpClient client = new HttpClient();
        private readonly string Url = "http://192.168.0.12:52447/api/Feedback";
        
        public async Task<HttpResponseMessage> AddFeedback(FeedbackResource feedback)
        {
            var content = JsonConvert.SerializeObject(feedback);
            var vr=await client.PostAsync(Url, new StringContent(content,Encoding.UTF8,"application/json"));
            return vr;
        }
    }
}
