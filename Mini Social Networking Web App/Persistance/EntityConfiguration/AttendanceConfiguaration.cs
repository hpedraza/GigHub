using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Mini_Social_Networking_Web_App.Persistance.EntityConfiguration
{
    public class AttendanceConfiguaration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguaration()
        {

            HasKey(a => new { a.GigId, a.AttendeeId });

           Property(a => a.GigId)
                .HasColumnOrder(1);

           Property(a => a.AttendeeId)
                .HasColumnOrder(2);
        }
    }
}