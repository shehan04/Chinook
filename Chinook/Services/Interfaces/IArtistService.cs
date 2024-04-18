using Chinook.ClientModels;
using Chinook.Models;

namespace Chinook.Services.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistVM>> GetArtistsBySearchText(string searchText);
        Task<ArtistSearchResultVM> GetArtistFullDetails(int artistId, string currentUserId);
    }
}
