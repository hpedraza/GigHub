using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mini_Social_Networking_Web_App.Core.Models
{
    public class UserNotification
    {

        public string UserId { get; private set; }

        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

        protected UserNotification()
        {
        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new ArgumentException("user");

            if (notification == null)
                throw new ArgumentException("notification");

            Notification = notification;
            User = user;
        }

        public void MarkAsRead()
        {
            this.IsRead = true;
        }

    }
}