using Mini_Social_Networking_Web_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Social_Networking_Web_App.Core.ViewModels
{
    public class FollowingAttendingGig
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowingArtist { get; set; }

        public FollowingAttendingGig()
        {

        }

        public FollowingAttendingGig(Gig g)
        {
            Gig = g;
        }
    }
    

}