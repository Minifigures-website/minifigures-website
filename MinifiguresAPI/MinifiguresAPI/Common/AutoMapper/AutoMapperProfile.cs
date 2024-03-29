﻿using AutoMapper;
using MinifiguresAPI.Models;
using MinifiguresAPI.Models.ModelsDto;

namespace MinifiguresAPI.Common.AutoMapper
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
