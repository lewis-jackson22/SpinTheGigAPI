using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpinTheGig.Data;
using SpinTheGig.Models;

namespace SpinTheGig.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ApiController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet("Episodes")]
        public async Task<ActionResult<IEnumerable<Episode>>> GetEpisodes()
        {
            // Get all episodes with the related Artist and Venue
            var episodes = await _appDbContext.Episodes
                .Include(e => e.Artist)
                .Include(e => e.Venue)
                .ToListAsync();

            return Ok(episodes);
        }
    }
}
