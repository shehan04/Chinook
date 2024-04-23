using Chinook.Models;

namespace Chinook.Repositories.Interfaces
{
    public interface IPlaylistRepository : IRepositoryBase<Playlist>
    {
        Task<long> GetNextSeqence();
    }
}
