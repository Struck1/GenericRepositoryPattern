﻿using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarket.Data
{
    public class MusicMarketDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public MusicMarketDbContext(DbContextOptions<MusicMarketDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new ArtistConfiguration());

            modelBuilder
                .ApplyConfiguration(new MusicConfiguration());
        }
    }
}
