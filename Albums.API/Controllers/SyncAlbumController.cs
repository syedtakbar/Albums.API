using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Services;
using Albums.API.Filters;

namespace Albums.API.Controllers
{
    [ApiController]
    [Route("api/syncalbums")]
    public class SyncAlbumController : ControllerBase
    {
        private readonly IAlbumRepo _albumRepo;

        public SyncAlbumController(IAlbumRepo albumRepo)
        {
            _albumRepo = albumRepo ??
                         throw new ArgumentNullException(nameof(albumRepo));
        }

        [HttpGet]
        [AlbumsResultFilter]
        public  IActionResult GetAlbums()
        {
            var albums = _albumRepo.GetAlbums();
            return Ok(albums);
        }

        [HttpGet]
        [Route("{id}")]
        [AlbumResultFilter]
        public IActionResult GetAlbum(Guid id)
        {
            var album = _albumRepo.GetAlbum(id);
            if (album == null) return NotFound();

            return Ok(album);
        }
    }
}
