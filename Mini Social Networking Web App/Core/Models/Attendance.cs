using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mini_Social_Networking_Web_App.Core.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }

        public ApplicationUser Attendee { get; set; }

        public int GigId { get; set; }


        public string AttendeeId { get; set; }

        public Attendance(){}

        public Attendance(int gigId , string attendeeId)
        {
            AttendeeId = attendeeId;
            GigId = gigId;
        }
    }
}