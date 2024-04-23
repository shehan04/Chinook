using Chinook.Constants;
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

        #region Add/Update
        public async Task UpdateTrackAsFavorite(string userId, long trackId)
        {
            await AddingTrackToPlayList(userId, trackId, ApplicationConstants.FavoritePlayListDefaultName);
        }

        public async Task UpdateTrackAsUnFavorite(string userId, long trackId)
        {
            var track = (await _trackRepository.GetAsync(t => t.TrackId == trackId)).First();
            var playList = (await _playlistRepository.GetAsync(x => x.Name == ApplicationConstants.FavoritePlayListDefaultName))?.FirstOrDefault();
            playList.Tracks.Remove(track);
            await _playlistRepository.UpdateAsync(playList);
        }

        public async Task AddTrackToSpecificPlayList(string userId, long trackId, string PlayListName)
        {
            await AddingTrackToPlayList(userId, trackId, PlayListName);
        }
        #endregion

        #region Private Methods
        private async Task AddingTrackToPlayList(string userId, long trackId, string playListName)
        {
            bool isNewPlayList = false;
            var track = (await _trackRepository.GetAsync(t => t.TrackId == trackId)).First();
            var playList = (await _playlistRepository.GetAsync(x => x.Name == playListName))?.FirstOrDefault();
            var userPlayList = (await _userPlaylistRepository.GetAsync(u => u.UserId == userId && u.Playlist.Name == playListName)).FirstOrDefault() ?? null;

            if (playList == null)
            {
                isNewPlayList = true;
                var nextSequence = await _playlistRepository.GetNextSeqence();
                playList = new Models.Playlist()
                {
                    PlaylistId = nextSequence,
                    Name = playListName,

                };

            }
            if (userPlayList == null)
            {
                userPlayList = new Models.UserPlaylist()
                {
                    PlaylistId = playList.PlaylistId,
                    UserId = userId,
                    Playlist = playList
                };
            }
            playList.Tracks.Add(track);
            playList.UserPlaylists.Add(userPlayList);
            if (isNewPlayList)
                await _playlistRepository.AddAsync(playList);
            else
                await _playlistRepository.UpdateAsync(playList);
        }
        #endregion
    }
}
