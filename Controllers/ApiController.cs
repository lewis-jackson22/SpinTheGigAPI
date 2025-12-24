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
                .Include(e => e.MainArtist)
                .Include(e => e.SupportingArtist)
                .Include(e => e.Venue)
                .Include(e => e.PreGigPub)
                .Include(e => e.PreGigBeverage)
                .Include(e => e.MidGigBeverage)
                .ToListAsync();

            return Ok(episodes);
        }
    }
}
