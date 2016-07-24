using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Social_Networking_Web_App.ViewModels
{
    public class GigDetailsViewModel
    {
        public string Artist { get; set; }
        public string ArtistId { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public Boolean IsFollowing { get; set; }
        public Boolean IsAttendding { get; set; }
        public Boolean IsAuthenticated { get; set; }
 

        public GigDetailsViewModel() { }

        public GigDetailsViewModel(string ArtistName, string Destination, DateTime SetDate , string id)
        {
            Artist = ArtistName;
            Venue = Destination;
            Date = SetDate;
            ArtistId = id;
        }


    }
}