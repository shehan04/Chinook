using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories
{

    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        protected readonly ChinookContext _dbContext;
        public ArtistRepository(ChinookContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable< Artist>> GetArtistsBySearchText(string searchText)
        {
            return await _dbContext.Artists.Where(x => x.Name.Contains(searchText))?.ToListAsync();
        }
    }
}
