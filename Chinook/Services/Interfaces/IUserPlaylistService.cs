using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Services.Interfaces
{
    public interface IUserPlaylistService 
    {
        Task UpdateTrackAsFavorite(string userId, long trackId);
    }
}
