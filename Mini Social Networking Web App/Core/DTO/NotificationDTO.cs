using Mini_Social_Networking_Web_App.Core.Models;
using System;


namespace Mini_Social_Networking_Web_App.Core.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get;  set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get;set; }
        public GigDTO Gig { get;  set; }
    }
}