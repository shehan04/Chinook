using AutoMapper;
using Chinook.ClientModels;
using Chinook.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chinook
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artist, ArtistVM>()
                 .ForMember(x => x.ArtistName, o => o.MapFrom(x => x.Name))
                 .ForMember(x => x.NumberOfAlbums, o => o.MapFrom(x => x.Albums.Count()));


        }
    }
}
