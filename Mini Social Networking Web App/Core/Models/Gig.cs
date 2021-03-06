﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
namespace Mini_Social_Networking_Web_App.Core.Models
{
    public class Gig
    {
        public int Id { get; private set; }

        public bool IsCanceled { get; private set; }
        
        public ApplicationUser Artist { get; set; }


        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }


        public string Venue { get; set; }

      
        public Genre Genre { get; set; }


        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances{ get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public Gig(string Art , byte Genre , DateTime dt, string ven, List<ApplicationUser> Followers)
        {
            Attendances = new Collection<Attendance>();
            ArtistId = Art;
            GenreId = Genre;
            DateTime = dt;
            Venue = ven;

            var notification = Notification.GigCreated(this);

           if( Followers != null)
           {
                foreach (var follower in Followers)
                {
                    follower.Notify(notification);
                }
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