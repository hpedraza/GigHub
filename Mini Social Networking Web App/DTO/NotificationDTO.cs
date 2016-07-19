using Mini_Social_Networking_Web_App.Models;
using System;


namespace Mini_Social_Networking_Web_App.DTO
{
    public class NotificationDTO
    {
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get;  set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get;set; }
        public GigDTO Gig { get;  set; }
    }
}