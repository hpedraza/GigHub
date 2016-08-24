using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Persistance.EntityConfiguration
{
    public class NotificationConfiguaration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguaration()
        {

        }
    }
}