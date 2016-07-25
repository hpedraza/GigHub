using Mini_Social_Networking_Web_App.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Mini_Social_Networking_Web_App.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace Mini_Social_Networking_Web_App.Controllers
{


    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null)
        {

            var upcomingGigs = _context.Gigs
                .Include(global => global.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);


            if(!String.IsNullOrWhiteSpace(query))
            {
                upcomingGigs = upcomingGigs
                    .Where(g => 
                            g.Artist.Name.Contains(query) ||
                            g.Genre.Name.Contains(query) ||
                            g.Venue.Contains(query));
            }

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs.ToList(),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs"
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var attendances = _context.Attendances.Where(x => x.AttendeeId == userId && x.Gig.DateTime > DateTime.Now).ToList().ToLookup(a => a.GigId);
                var followings = _context.Followings.Where(x => x.FollowerId == userId).ToList().ToLookup(x => x.FolloweeId);

               viewModel.Attendances = attendances;
               viewModel.Followings = followings;
            }


            return View("Gigs" , viewModel);
        }

        private void IsAttendingOrFollowing(Gig gig, string userId, ref FollowingAttendingGig model)
        {
            model.Gig = gig;

            // Check too see if user is attending Gig
            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gig.Id))
            {
                model.IsAttending = true;
            }

            else
            {
                model.IsAttending = false;
            }

            //check to see if user is following artist
            if (_context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == gig.Artist.Id))
            {
                model.IsFollowingArtist = true;
            }

            else
            {
                model.IsFollowingArtist = false;
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}