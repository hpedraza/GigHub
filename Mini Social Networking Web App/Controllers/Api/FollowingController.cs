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
        public IHttpActionResult MakeFollowing(FolloweeDTO dto)
        {
            try
            {
                var userId = User.Identity.GetUserId();

                if (_context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == dto.ArtistId))
                {
                    return BadRequest("Following already exists.");
                }


                _context.Followings.Add(new Followings(userId, dto.ArtistId));
                _context.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                var exc = ex;
                return BadRequest(exc.ToString());
               
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowing(string ArtistId)
        {
            var userId = User.Identity.GetUserId();
            try
            {
                _context.Followings
                    .Remove(
                        _context.Followings
                        .Single(a => a.FollowerId == userId && a.FolloweeId == ArtistId));

                _context.SaveChanges();

            }
            catch
            {
                return BadRequest("Following does not exist in database."); ;
            }

            return Ok();
        }

    }
}
