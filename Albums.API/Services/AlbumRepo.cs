using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Context;
using Albums.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Albums.API.Services
{
    public class AlbumRepo : IAlbumRepo, IDisposable
    {
        private AlbumContext _context;

        public AlbumRepo(AlbumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
            return await _context.Albums
                .Include(a => a.Artist).ToListAsync();
        }

        public async Task<Album> GetAlbumAsync(Guid id)
        {
            return await _context.Albums
                .Include(a => a.Artist).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync(IEnumerable<Guid> AlbumIds)
        {
            return await _context.Albums.Where(a => AlbumIds.Contains(a.Id))
                .Include(a => a.Artist).ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public IEnumerable<Album> GetAlbums()
        {
            return  _context.Albums
                .Include(a => a.Artist).ToList();
        }

        public Album GetAlbum(Guid id)
        {
            return  _context.Albums
                .Include(a => a.Artist).FirstOrDefault(b => b.Id == id);
        }

        public void  AddAlbum(Album newAlbum)
        {
            if (newAlbum == null) throw new ArgumentNullException(nameof(newAlbum));

            _context.Add(newAlbum);

        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync() > 0);
        }

    }
}