using Chinook.ClientModels;
using Chinook.DTO;
using Chinook.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlaylistController : ControllerBase
    {

        private readonly IUserPlaylistService _userPlaylistService;
        private readonly ILogger<ArtistController> _logger;
        public UserPlaylistController(IUserPlaylistService userPlaylistService, ILogger<ArtistController> logger)
        {
            _userPlaylistService = userPlaylistService;
            _logger = logger;

        }
        [HttpPut("UpdateTrackAsFavorite")]
        public async Task<ActionResult<ArtistSearchResultVM>> UpdateTrackAsFavorite(UpdateTrackDTO updateTrack)
        {
            try
            {
                await _userPlaylistService.UpdateTrackAsFavorite(updateTrack.UserId, updateTrack.TrackId);
                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
