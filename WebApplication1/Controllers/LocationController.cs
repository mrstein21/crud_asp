using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LocationController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> AddPlaces(Places places) {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appDbContext.Places.Add(places);
            await _appDbContext.SaveChangesAsync();
            return Ok(places);

        }

        [HttpGet]
        public async Task<ActionResult> GetListPlaces() {
            var places = await _appDbContext.Places.ToListAsync();
            return Ok(places);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetPlace([FromRoute]int id) {
            var place = await _appDbContext.Places.FindAsync(id);
            if(place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeletePlaces([FromRoute] int id) {

            var place = await _appDbContext.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            _appDbContext.Places.Remove(place);
            await _appDbContext.SaveChangesAsync();
            return Ok(place);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdatePlace([FromRoute] int id, [FromBody] Places place) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var findPlace = await _appDbContext.Places.FindAsync(id);
             if (findPlace == null) { 
               return NotFound();
            }

            findPlace.Longitude = place.Longitude;
            findPlace.Latitude = place.Latitude;
            findPlace.Description = place.Description;
            findPlace.Name = place.Name;
            findPlace.Location = place.Location;

            await _appDbContext.SaveChangesAsync();
            return Ok(findPlace);

        }

    }
}
