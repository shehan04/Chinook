using AutoMapper;
using Chinook.ClientModels;
using Chinook.Models;
using Chinook.Repositories.Interfaces;
using Chinook.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ITrackRepository _trackRepository;
        private IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper, ITrackRepository trackRepository)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _trackRepository = trackRepository;

        }

        public async Task<IEnumerable<ArtistVM>> GetArtistsBySearchText(string searchText)
        {
            IEnumerable<Artist> artists;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                artists = await _artistRepository.GetAsync(x=>x.Name.Contains(searchText));
            }
            else
                artists = await _artistRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ArtistVM>>(artists);
        }
        public async Task<ArtistSearchResultVM> GetArtistFullDetails(int  artistId, string currentUserId)
        {
            var artist = (await _artistRepository.GetAsync(x => x.ArtistId == artistId)).FirstOrDefault();
            var tracks = (await _trackRepository.GetAsync(a => a.Album.ArtistId == artist.ArtistId)).ToList()
            .Select(t => new PlaylistTrackVM()
            {
              AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
              TrackId = t.TrackId,
              TrackName = t.Name,
              IsFavorite = t.Playlists.Where(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites")).Any(),
            }).ToList();

            return new ArtistSearchResultVM()
            {
                ArtistVM = _mapper.Map<ArtistVM>(artist),
                TracksVM = tracks
            };


        }

    }
}
