using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Persistance.EntityConfiguration
{
    public class ApplicationUserConfiguaration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguaration() 
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);


            HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

            HasMany(u => u.Followers)
                 .WithRequired(f => f.Followee)
                 .WillCascadeOnDelete(false);
        }
    }
}