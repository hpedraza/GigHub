using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mini_Social_Networking_Web_App.Persistance.EntityConfiguration
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            Property(g => g.ArtistId)
            .IsRequired();

            Property(g => g.DateTime)
                .IsRequired();

            Property(g => g.GenreId)
                .IsRequired();

            Property(g => g.Venue)
                    .IsRequired()
                    .HasMaxLength(255);
            
            HasMany(g => g.Attendances)
                .WithRequired(a => a.Gig)
                .WillCascadeOnDelete(false);

        }

    }
}