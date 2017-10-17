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
    public class FeedbackServices
    {
        HttpClient client = new HttpClient();
        private readonly string Url = "http://192.168.0.12:52447/api/Feedback";

        public async Task<List<FeedbackColor>> GetFeedbacks()
        {
            var content = await client.GetStringAsync(Url);
            var feedbackColor = new List<FeedbackColor>();
            var feedbacks = JsonConvert.DeserializeObject<List<Feedback>>(content);
            foreach (var v in feedbacks)
                feedbackColor.Add(new FeedbackColor(v));

            return feedbackColor;
        }

        public async Task<HttpResponseMessage> DeleteFeedback(int id)
        {
            var response = await client.DeleteAsync(Url + "/" + id.ToString());
            return response;
        }
    }
}
