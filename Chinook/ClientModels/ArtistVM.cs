namespace Chinook.ClientModels
{
    public class ArtistVM
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int NumberOfAlbums {  get; set; }

    }

    public class ArtistDTO
    {
        public string ArtistName { get; set;}
    }

    public class ArtistSearchResultVM
    {
        public ArtistVM ArtistVM { get; set;}
        public List<PlaylistTrackVM> TracksVM { get; set; } = new();
    }
}
