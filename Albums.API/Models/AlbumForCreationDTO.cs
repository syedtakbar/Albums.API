using System;

namespace Albums.API.Models
{
    public class AlbumForCreationDTO
    {
        public Guid ArtistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}