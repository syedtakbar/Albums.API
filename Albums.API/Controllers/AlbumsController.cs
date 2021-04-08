using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Entities;
using Albums.API.Filters;
using Albums.API.Models;
using Albums.API.Services;
using AutoMapper;

namespace Albums.API.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepo _albumRepo;
        private readonly IMapper _mapper;

        public AlbumsController(IAlbumRepo albumRepo, IMapper mapper)
        {
            _albumRepo = albumRepo ?? 
                         throw new ArgumentNullException(nameof(albumRepo));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [AlbumsResultFilter]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await _albumRepo.GetAlbumsAsync();
            return Ok(albums);
        }

        [HttpGet]
        [AlbumsResultFilter]
        [Route("GetAlbumTest")]
        public async Task<IActionResult> GetAlbumsTest()
        {
            var albums = await _albumRepo.GetAlbumsAsync();
            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}", Name = "GetAlbum")]
        [AlbumResultFilter]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var album = await _albumRepo.GetAlbumAsync(id);
            if (album == null) return NotFound();

            return Ok(album);
        }

        [HttpPost]
        [AlbumResultFilter]
        public async Task<IActionResult> CreateAlbum(AlbumForCreationDTO albumForCreationDto)
        {

            var newAlbum = _mapper.Map<Album>(albumForCreationDto);
            _albumRepo.AddAlbum(newAlbum);

            await _albumRepo.SaveChangesAsync();

            await _albumRepo.GetAlbumAsync(newAlbum.Id);

            return CreatedAtRoute("GetAlbum", new { id = newAlbum.Id}, newAlbum);
        }
    }
}
