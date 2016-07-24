using Microsoft.AspNet.Identity;
using Mini_Social_Networking_Web_App.DTO;
using Mini_Social_Networking_Web_App.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Data;
namespace Mini_Social_Networking_Web_App.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private ApplicationDbContext _context;
        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public Boolean ToggleFollow(FolloweeDTO dto)
        {
            var userId = User.Identity.GetUserId();

            if ( dto.Follow == true)
            {
                if (_context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == dto.ArtistId))
                {
                    return true;
                }

                _context.Followings.Add(new Followings(userId, dto.ArtistId));
                _context.SaveChanges();

                return true;
            }
            
            // Unfollow (delete following) 
            else
            {
                try
                {
                    _context.Followings
                        .Remove(
                            _context.Followings
                            .Single(a => a.FollowerId == userId && a.FolloweeId == dto.ArtistId));

                    _context.SaveChanges();
                    
                }
                catch 
                {
                    return true;
                }

                return false;
            }


        }

    }
}
