using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mini_Social_Networking_Web_App.Persistance.EntityConfiguration
{
    public class FollowingsConfiguration : EntityTypeConfiguration<Followings>
    {
        public FollowingsConfiguration()
        {
            HasKey(f => new { f.FollowerId, f.FolloweeId });

            Property(f => f.FolloweeId)
                .HasColumnOrder(1);

            
            Property(f => f.FolloweeId)
                .HasColumnOrder(2);
        }
    }
}