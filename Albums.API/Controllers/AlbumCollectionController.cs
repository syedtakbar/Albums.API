using Albums.API.Entities;
using Albums.API.Filters;
using Albums.API.Models;
using Albums.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.ModelBinders;

namespace Albums.API.Controllers
{
    [ApiController]
    [AlbumsResultFilter]
    [Route("api/albumcollections")]
    public class AlbumCollectionController : ControllerBase
    {
        private readonly IAlbumRepo _albumRepo;
        private readonly IMapper _mapper;

        public AlbumCollectionController(IAlbumRepo albumRepo, IMapper mapper)
        {
            _albumRepo = albumRepo ??
                         throw new ArgumentNullException(nameof(albumRepo));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({AlbumIds})", Name = "GetAlbumCollection")]
        public async Task<IActionResult> GetAlbumCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> AlbumIds)
        {
            var albumCollection = await _albumRepo.GetAlbumsAsync(AlbumIds);

            if (AlbumIds.Count() != albumCollection.Count()) return NotFound();

            return Ok(albumCollection);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbumCollection(IEnumerable<AlbumForCreationDTO> albumCollectionDto)
        {

            var newAlbumCollection = _mapper.Map<IEnumerable<Album>>(albumCollectionDto);

            foreach (var albumItem in newAlbumCollection)
            {
                _albumRepo.AddAlbum(albumItem);
            }
            
            await _albumRepo.SaveChangesAsync();

            var createdAlbumCollectiton = await _albumRepo.GetAlbumsAsync(newAlbumCollection.Select(a => a.Id));

            var AlbumIds = string.Join(",", createdAlbumCollectiton.Select(a => a.Id));

            return CreatedAtRoute("GetAlbumCollection", new {AlbumIds }, createdAlbumCollectiton);
        }

    }
}
