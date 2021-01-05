using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarket.Data.Configuration
{
    class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Artists");
        }
    }
}
