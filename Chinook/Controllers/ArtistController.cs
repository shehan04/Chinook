using Chinook.ClientModels;
using Chinook.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly ILogger<ArtistController> _logger;
        public ArtistController(IArtistService artistService, ILogger<ArtistController> logger)
        {
            _artistService = artistService;
            _logger = logger;

        }
        [HttpGet("GetArtistsAll")]
        public async Task<ActionResult<ArtistSearchResultVM>> GetArtistsAll()
        {
            try
            {
                var artist = await _artistService.GetArtistsBySearchText(string.Empty);
                return Ok(artist);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetArtistsBySearchText/{searchText}")]
        public async Task<ActionResult<ArtistSearchResultVM>> GetArtistsBySearchText(string? searchText)
        {
            try
            {
                var artist = await _artistService.GetArtistsBySearchText(searchText);
                return Ok(artist);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetArtistFullDetails/{artistId}/{userId}")]
        public async Task<ActionResult<ArtistSearchResultVM>> GetArtistFullDetails(int artistId, string userId)
        {
            try
            {
                var artist = await _artistService.GetArtistFullDetails(artistId, userId);
                return Ok(artist);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

    }
}
