using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mini_Social_Networking_Web_App.Persistance.EntityConfiguration
{
    public class UserNotificationConfiguaration : EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguaration()
        {
            HasKey(un => new { un.UserId, un.NotificationId });

            Property(un => un.UserId)
                .HasColumnOrder(1);

            Property(un => un.UserId)
                .HasColumnOrder(2);

            HasRequired(u => u.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);
        
        }
    }
}