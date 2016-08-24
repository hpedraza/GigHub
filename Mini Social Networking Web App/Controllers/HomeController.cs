using Mini_Social_Networking_Web_App.Core.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Mini_Social_Networking_Web_App.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using Mini_Social_Networking_Web_App.Core.Repositories;
using Mini_Social_Networking_Web_App.Persistance;
using Mini_Social_Networking_Web_App.Persistance.Repositories;

namespace Mini_Social_Networking_Web_App.Controllers
{


    public class HomeController : Controller
    {

        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork UnitOfWork)
        {

            _unitOfWork = UnitOfWork;
        }

        public ActionResult Index(string query = null)
        {

            var upcomingGigs = _unitOfWork.Gigs.GetAllUpcomingGigs();
                

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

                var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId).ToLookup(a => a.GigId);

                var followings = _unitOfWork.Followings.CreateUserFollowingsLookUp(userId);

                viewModel.Attendances = attendances;
                viewModel.Followings = followings;
            }


            return View("Gigs" , viewModel);
        }

        private void IsAttendingOrFollowing(Gig gig, string userId, ref FollowingAttendingGig model)
        {
            model.Gig = gig;

            // Check too see if user is attending Gig
            if (_unitOfWork.Attendances.GetAttendance(gig.Id , userId) != null )
            {
                model.IsAttending = true;
            }

            else
            {
                model.IsAttending = false;
            }

            //check to see if user is following artist
            if ( _unitOfWork.Followings.GetFollowing(gig.Artist.Id , userId) != null )
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