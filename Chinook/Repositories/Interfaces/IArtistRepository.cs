using Chinook.Models;

namespace Chinook.Repositories.Interfaces
{
    public interface IArtistRepository:IRepositoryBase<Artist>
    {
        Task<IEnumerable<Artist>> GetArtistsBySearchText(string searchText);
    }
}
