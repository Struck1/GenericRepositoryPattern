using AutoMapper;
using MusicMarket.API.DTOs;
using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Music, MusicDTO>();
            CreateMap<Artist, ArtistDTO>();

            CreateMap<MusicDTO, Music>();
            CreateMap<ArtistDTO, Artist>();

            CreateMap<SaveMusicDTO, Music>();
            CreateMap<SaveArtistDTO, Artist>();


        }
    }
}
