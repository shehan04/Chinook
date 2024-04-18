namespace Chinook.Services.Interfaces
{
    public interface IUserPlaylistService 
    {
        Task UpdateTrackAsFavorite(string userId, long trackId);
        Task UpdateTrackAsUnFavorite(string userId, long trackId);

        Task AddTrackToSpecificPlayList(string userId, long trackId, string PlayListName);
    }
}
