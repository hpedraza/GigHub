using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mini_Social_Networking_Web_App.Models;
using Mini_Social_Networking_Web_App.DTO;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
namespace Mini_Social_Networking_Web_App.Controllers.Api
{ 
    [Authorize]
    public class MarkNotificationsAsReadController : ApiController
    {
        private ApplicationDbContext _context;

        public MarkNotificationsAsReadController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead(IEnumerable<NotificationDTO> notifications)
        {
            var userId = User.Identity.GetUserId();
        
            foreach(var dto in notifications) {
              _context.UserNotifications
                    .Where(un => un.UserId == userId && un.Notification.Id == dto.Id)
                    .Single()
                    .MarkAsRead();
                }

            _context.SaveChanges();

            return Ok();
        }


    }
}
