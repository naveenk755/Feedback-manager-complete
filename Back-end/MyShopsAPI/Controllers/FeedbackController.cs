using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopsAPI.Models;
using MyShopsAPI.Persistence;
using AutoMapper;
using MyShopsAPI.Controllers.Resources;

namespace MyShopsAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Feedback")]
    public class FeedbackController : Controller
    {
        private readonly ShopDbContext shopDbContext;
        private readonly IMapper mapper;

        public FeedbackController(ShopDbContext shopDbContext, IMapper mapper)
        {
            this.shopDbContext = shopDbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody]FeedbackResource feedbackResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var feedback = mapper.Map<FeedbackResource, Feedback>(feedbackResource);
            feedback.FeedbackDate = DateTime.Now;

            await shopDbContext.FeedBacks.AddAsync(feedback);
            await shopDbContext.SaveChangesAsync();

            feedback = await shopDbContext.FeedBacks.FindAsync(feedback.Id);
            var result = mapper.Map<Feedback, FeedbackResource>(feedback);
            return Ok(result);
        }

        [HttpGet]
        public List<FeedbackResource> GetFeedbacks()
        {
            var feedbacks = shopDbContext.FeedBacks.ToList();
            var feedbackResources = mapper.Map<List<Feedback>, List<FeedbackResource>>(feedbacks);
            return feedbackResources;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await shopDbContext.FeedBacks.FindAsync(id);

            if (feedback == null)
                return NotFound();

            shopDbContext.FeedBacks.Remove(feedback);
            await shopDbContext.SaveChangesAsync();
            return Ok(id);
        }
    }
}