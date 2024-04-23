using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Repositories
{
    public class PlaylistRepository : RepositoryBase<Playlist>, IPlaylistRepository
    {
       // protected readonly ChinookContext _dbContext;
        public PlaylistRepository(ChinookContext dbContext) : base(dbContext)
        {

        }

        public async Task<long> GetNextSeqence()
        {
            var lastPlaylist = await _dbContext.Playlists.OrderByDescending(x => x.PlaylistId).FirstOrDefaultAsync();
            return lastPlaylist != null ? lastPlaylist.PlaylistId + 1 : 1;
        }
    }
}
