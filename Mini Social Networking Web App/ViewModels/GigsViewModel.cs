using Mini_Social_Networking_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Social_Networking_Web_App.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<FollowingAttendingGig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}