
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mini_Social_Networking_Web_App.Models
{
    public class Gig
    {
        public int Id { get; private set; }

        public bool IsCanceled { get; private set; }
        
        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; private set; }

      
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances{ get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public Gig(string Art , byte Genre , DateTime dt, string ven)
        {
            Attendances = new Collection<Attendance>();
            ArtistId = Art;
            GenreId = Genre;
            DateTime = dt;
            Venue = ven;

            var notification = Notification.GigCreated(this);

            foreach (var follower in this.Artist.Followers.Select(f => f.Follower))
            {
                follower.Notify(notification);
            }
        }


        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCanceled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void UpdateGig(string venue , DateTime dt, byte genre)
        {
            var notification = Notification.GigUpdated(this,dt,venue);

            Venue = venue;
            DateTime = dt;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
            
        }
    }


}