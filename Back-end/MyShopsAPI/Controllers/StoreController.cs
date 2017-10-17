using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopsAPI.Models;
using Microsoft.EntityFrameworkCore;
using MyShopsAPI.Persistence;
using MyShopsAPI.Controllers.Resources;
using AutoMapper;

namespace MyShopsAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Store")]
    public class StoreController : Controller
    {
        private readonly ShopDbContext shopDbContext;
        private readonly IMapper mapper;

        public StoreController(ShopDbContext shopDbContext, IMapper mapper)
        {
            this.shopDbContext = shopDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Store>> GetStores()
        {
            var stores = await shopDbContext.Shops.ToListAsync();
            return stores;
        }

        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] StoreSaveResources storeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var store = mapper.Map<StoreSaveResources, Store>(storeResource);
            store.MondayOpen = "11am";
            store.TuesdayOpen= "11am";
            store.WednesdayOpen = "11am";
            store.ThursdayOpen = "11am";
            store.FridayOpen = "11am";
            store.SaturdayOpen = "11am"; 
            store.SundayOpen = "11am";
            store.MondayClose = "8pm";
            store.TuesdayClose = "8pm";
            store.WednesdayClose = "8pm";
            store.ThursdayClose = "8pm"; 
            store.FridayClose = "8pm";
            store.SaturdayClose = "8pm";
            store.SundayClose = "8pm";

            await shopDbContext.Shops.AddAsync(store);
            await shopDbContext.SaveChangesAsync();

            store = await shopDbContext.Shops.FindAsync(store.Id);
            var result = mapper.Map<Store, StoreSaveResources>(store);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var store = await shopDbContext.Shops.FindAsync(id);
            if (store == null)
                return NotFound();

            shopDbContext.Shops.Remove(store);
            await shopDbContext.SaveChangesAsync();
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore([FromBody] StoreSaveResources storeResource , int id)
        {
            var store = await shopDbContext.Shops.FindAsync(id);
            if (store == null)
                return NotFound();

            mapper.Map<StoreSaveResources, Store>(storeResource, store);
            store.MondayOpen = "11am";
            store.TuesdayOpen = "11am";
            store.WednesdayOpen = "11am";
            store.ThursdayOpen = "11am";
            store.FridayOpen = "11am";
            store.SaturdayOpen = "11am";
            store.SundayOpen = "11am";
            store.MondayClose = "8pm";
            store.TuesdayClose = "8pm";
            store.WednesdayClose = "8pm";
            store.ThursdayClose = "8pm";
            store.FridayClose = "8pm";
            store.SaturdayClose = "8pm";
            store.SundayClose = "8pm";

            await shopDbContext.SaveChangesAsync();

            store = await shopDbContext.Shops.FindAsync(id);
            var result = mapper.Map<Store, StoreSaveResources>(store);
            return Ok(result);
        }
    }
}