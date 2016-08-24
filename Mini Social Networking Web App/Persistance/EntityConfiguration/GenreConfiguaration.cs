using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mini_Social_Networking_Web_App.Persistance.EntityConfiguration
{
    public class GenreConfiguaration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguaration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}