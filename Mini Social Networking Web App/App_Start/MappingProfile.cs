using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Data.Entity;
using Mini_Social_Networking_Web_App.Core.Models;
using Mini_Social_Networking_Web_App.Core.DTO;

namespace Mini_Social_Networking_Web_App.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<Gig, GigDTO>();
                cfg.CreateMap<Notification, NotificationDTO>();
            });
        }
    }
}