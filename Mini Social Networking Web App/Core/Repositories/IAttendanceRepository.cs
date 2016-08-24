using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int gigId, string userId);
    }

}