using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Repositories;
using Mini_Social_Networking_Web_App.Persistance;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Persistance.Repositories
{

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(x => x.AttendeeId == userId && x.Gig.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(int gigId , string userId)
        {
            return _context.Attendances.Where(a => a.GigId == gigId && a.AttendeeId == userId).SingleOrDefault();
        }

    }
}