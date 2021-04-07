using System;

namespace Albums.API.Models
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}