using Mini_Social_Networking_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Mini_Social_Networking_Web_App.DTO;
using AutoMapper;

namespace Mini_Social_Networking_Web_App.Controllers.Api
{

    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<NotificationDTO> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<Gig, GigDTO>();
                cfg.CreateMap<Notification, NotificationDTO>();
            });
     
            IMapper mapper = config.CreateMapper();


            return notifications.Select(mapper.Map<Notification,NotificationDTO>);
        }
    }
}
