using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Repositories
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        protected readonly ChinookContext _dbContext;
        public ArtistRepository(ChinookContext dbContext) : base(dbContext)
        {

        }
    }
}
