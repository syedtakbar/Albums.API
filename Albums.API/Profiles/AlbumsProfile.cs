using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Entities;
using Albums.API.Models;
using AutoMapper;

namespace Albums.API.Profiles
{
    public class AlbumsProfile : Profile
    {
        public AlbumsProfile()
        {
            CreateMap<Album, AlbumDTO>()
                .ForMember(d => d.Artist, 
                    o=> o.MapFrom(s => 
                        $"{s.Artist.FirstName} {s.Artist.LastName}"));
        }
    }
}
