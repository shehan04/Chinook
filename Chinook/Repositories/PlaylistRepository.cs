using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Repositories
{
    public class PlaylistRepository : RepositoryBase<Playlist>, IPlaylistRepository
    {
        protected readonly ChinookContext _dbContext;
        public PlaylistRepository(ChinookContext dbContext) : base(dbContext)
        {

        }
    }
}
