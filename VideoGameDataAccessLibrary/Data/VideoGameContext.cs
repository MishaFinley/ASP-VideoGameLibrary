using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameDataAccessLibrary.Models;

namespace VideoGameDataAccessLibrary.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<VideoGame> VideoGames { get; set; }

    }
}


