using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace Albums.API.Entities
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        public Guid ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}