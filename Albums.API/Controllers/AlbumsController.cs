using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Filters;
using Albums.API.Services;

namespace Albums.API.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepo _albumRepo;

        public AlbumsController(IAlbumRepo albumRepo)
        {
            _albumRepo = albumRepo ?? 
                         throw new ArgumentNullException(nameof(albumRepo));
        }

        [HttpGet]
        [AlbumsResultFilter]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await _albumRepo.GetAlbumsAsync();
            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}")]
        [AlbumResultFilter]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var album = await _albumRepo.GetAlbumAsync(id);
            if (album == null) return NotFound();

            return Ok(album);
        }
    }
}
