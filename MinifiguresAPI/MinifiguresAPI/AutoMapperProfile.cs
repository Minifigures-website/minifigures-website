using AutoMapper;
using MinifiguresAPI.Models;

namespace MinifiguresAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<BoardGameCreateDto, BoardGame>();
            CreateMap<BoardGame, BoardGameCreateDto>();

            CreateMap<BoardGameUpdateDto, BoardGame>();
            CreateMap<BoardGame, BoardGameUpdateDto>();
        }
    }
}
