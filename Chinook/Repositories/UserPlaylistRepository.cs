using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Repositories
{
    public class UserPlaylistRepository : RepositoryBase<UserPlaylist>, IUserPlaylistRepository
    {
        protected readonly ChinookContext _dbContext;
        public UserPlaylistRepository(ChinookContext dbContext) : base(dbContext)
        {

        }
    }
}
