using Albums.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albums.API.Services
{
    public interface IAlbumRepo
    {
        IEnumerable<Album> GetAlbums();

        Album GetAlbum(Guid id);

        Task<IEnumerable<Album>> GetAlbumsAsync();

        Task<IEnumerable<Album>> GetAlbumsAsync(IEnumerable<Guid> AlbumIds);

        Task<Album> GetAlbumAsync(Guid id);

        void AddAlbum(Album newAlbum);

        Task<bool> SaveChangesAsync();
    }
}
