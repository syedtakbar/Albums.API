using System;
using Albums.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Albums.API.Context
{
    public class AlbumContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        public AlbumContext(DbContextOptions<AlbumContext> options) 
            : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist()
                {
                    Id = Guid.Parse("6bc6a40b-6565-437f-8d08-b7985222f45d"),
                    FirstName = "John",
                    LastName = "Lenon"
                },
                new Artist()
                {
                    Id = Guid.Parse("5c4bee68-77c0-4b76-9fdf-5f1750d3ab6f"),
                    FirstName = "Paul",
                    LastName = "McCartney"
                },
                new Artist()
                {
                    Id = Guid.Parse("214419f4-f64f-4af8-9de1-33a31faee1c5"),
                    FirstName = "George",
                    LastName = "Harrison"
                },
                new Artist()
                {
                    Id = Guid.Parse("65cc0121-71e7-43c2-a934-974d2315c8f6"),
                    FirstName = "Ringo",
                    LastName = "Starr"
                }
            );

            modelBuilder.Entity<Album>().HasData(

                new Album()
                {
                    Id = Guid.Parse("a091bc10-43fd-423e-9838-3b62bd22d047"),
                    ArtistId = Guid.Parse("6bc6a40b-6565-437f-8d08-b7985222f45d"),
                    Title = "Mind Games",
                    Description = @"Mind Games is the fourth studio album by English  musician John Lennon. 
                                    It was recorded at Record Plant Studios in New York in summer 1973. 
                                    The album was released in the US on 29 October 1973 and in the UK on 16 November 1973. 
                                    It was Lennon's first self-produced recording without help from Phil Spector."
                },
                new Album()
                {
                    Id = Guid.Parse("dd331421-7d8d-493d-858b-44263ea0b7fa"),
                    ArtistId = Guid.Parse("6bc6a40b-6565-437f-8d08-b7985222f45d"),
                    Title = "Imagine",
                    Description = "Imagine is the second studio album by English musician John Lennon, released on 9 September 1971 by Apple Records"
                },
                new Album()
                {
                    Id = Guid.Parse("4dbc2635-ccb3-425a-9527-a4b3e7d89c17"),
                    ArtistId = Guid.Parse("5c4bee68-77c0-4b76-9fdf-5f1750d3ab6f"),
                    Title = "Ram",
                    Description = @"Ram is a studio album by Paul McCartney and his wife Linda McCartney, released in May 1971 by Apple Records. 
                                    It was recorded in New York with guitarists David Spinozza and Hugh McCracken, 
                                    and future Wings drummer Denny Seiwell"
                },
                new Album()
                {
                    Id = Guid.Parse("9a2f2363-0f57-41f7-b397-c9c7712c4815"),
                    ArtistId = Guid.Parse("214419f4-f64f-4af8-9de1-33a31faee1c5"),
                    Title = "All Things Must Pass",
                    Description = @"All Things Must Pass is the third studio album by English rock musician George Harrison. 
                                Released as a triple album in November 1970, it was Harrison's first solo work after the break-up of the Beatles in April that year."
                },
                new Album()
                {
                    Id = Guid.Parse("d79ef7b5-ceb4-4fe8-96f5-dca2b693c356"),
                    ArtistId = Guid.Parse("65cc0121-71e7-43c2-a934-974d2315c8f6"),
                    Title = "Sentimental Journey",
                    Description = @"Sentimental Journey is the debut album by English rock musician Ringo Starr. 
                                    Released in 1970 as The Beatles were breaking up, Starr was the third member of the group to issue a solo recording."
                }

            );
        }
    }
}