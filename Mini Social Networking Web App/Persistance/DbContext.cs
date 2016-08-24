using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Mini_Social_Networking_Web_App.Core.Models;
using Mini_Social_Networking_Web_App.Persistance.EntityConfiguration;

namespace Mini_Social_Networking_Web_App.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Followings> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add( new ApplicationUserConfiguaration() );

            modelBuilder.Configurations.Add( new GigConfiguration() );

            modelBuilder.Configurations.Add( new FollowingsConfiguration() );

            modelBuilder.Configurations.Add( new AttendanceConfiguaration() );

            modelBuilder.Configurations.Add( new GenreConfiguaration() );

            modelBuilder.Configurations.Add( new UserNotificationConfiguaration() );

            modelBuilder.Configurations.Add( new NotificationConfiguaration() );


            base.OnModelCreating(modelBuilder);
        }
    }
}