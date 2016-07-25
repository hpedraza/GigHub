using Mini_Social_Networking_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mini_Social_Networking_Web_App.DTO;

namespace Mini_Social_Networking_Web_App.Controllers
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();
            try
            {
                var remove = _context.Attendances.Single(x => x.AttendeeId == userId && x.GigId == id);
               _context.Attendances.Remove(remove);
            }
            catch
            {
               return NotFound();
            }

            _context.SaveChanges();
            return Ok(id);
        }
        [HttpPost]
         public IHttpActionResult Attend(AttendanceDTO dto)
         {
             var userId = User.Identity.GetUserId();

             if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
             {
                 return BadRequest("Attendance already exists.");
             }
             var attendance = new Attendance
             {
                 GigId = dto.GigId,
                 AttendeeId = userId
             };
             _context.Attendances.Add(attendance);
             _context.SaveChanges();

             return Ok();

         }
    }
}
