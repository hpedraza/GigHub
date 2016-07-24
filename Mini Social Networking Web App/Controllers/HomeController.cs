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
            List<FollowingAttendingGig> upcoming = new List<FollowingAttendingGig>();

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

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                foreach (var gig in upcomingGigs)
                {
                    var model = new FollowingAttendingGig();
                    IsAttendingOrFollowing(gig, userId, ref model);
                    upcoming.Add(model);

                }
            }

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcoming,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query
            };

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