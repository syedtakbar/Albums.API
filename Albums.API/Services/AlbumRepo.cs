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
            //await _context.Database.ExecuteSqlRawAsync("WAITFOR DELAY '00:00:02';");
            return await _context.Albums
                .Include(a => a.Artist).ToListAsync();
        }

        public async Task<Album> GetAlbumAsync(Guid id)
        {
            return await _context.Albums
                .Include(a => a.Artist).FirstOrDefaultAsync(b => b.Id == id);
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
            //_context.Database.ExecuteSqlRaw("WAITFOR DELAY '00:00:02';");
            return  _context.Albums
                .Include(a => a.Artist).ToList();
        }

        public Album GetAlbum(Guid id)
        {
            return  _context.Albums
                .Include(a => a.Artist).FirstOrDefault(b => b.Id == id);
        }
    }
}