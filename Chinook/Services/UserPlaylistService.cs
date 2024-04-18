using Chinook.ClientModels;
using Chinook.Constants;
using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Chinook.Services.Interfaces;

namespace Chinook.Services
{
    public class UserPlaylistService : IUserPlaylistService
    {
        private readonly IUserPlaylistRepository _userPlaylistRepository;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly ITrackRepository _trackRepository;

        public UserPlaylistService(IUserPlaylistRepository userPlaylistRepository, IPlaylistRepository playlistRepository, ITrackRepository trackRepository)
        {
            _userPlaylistRepository = userPlaylistRepository;
            _playlistRepository = playlistRepository;
            _trackRepository = trackRepository;
        }

        public async Task UpdateTrackAsFavorite(string userId, long trackId)
        {
            var track = (await _trackRepository.GetAsync(t => t.TrackId == trackId)).First();
            var playList = (await _playlistRepository.GetAsync(x => x.Name == ApplicationConstants.FavoritePlayListDefaultName))?.FirstOrDefault();
            var userPlayList = (await _userPlaylistRepository.GetAsync(u => u.UserId == userId && u.Playlist.Name == ApplicationConstants.FavoritePlayListDefaultName)).FirstOrDefault() ?? null;

            if (playList == null)
            {
                playList = new Models.Playlist()
                {
                    Name = ApplicationConstants.FavoritePlayListDefaultName,

                };

            }
            if (userPlayList == null)
            {
                var newUserPlayList = new Models.UserPlaylist()
                {
                    PlaylistId = playList.PlaylistId,
                    UserId = userId,
                    Playlist = playList
                };
            }
            playList.Tracks.Add(track);
            playList.UserPlaylists.Add(userPlayList);
            await _playlistRepository.UpdateAsync(playList);
        }
    }
}
