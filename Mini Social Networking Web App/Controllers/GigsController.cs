using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Mini_Social_Networking_Web_App.Persistance;
using Mini_Social_Networking_Web_App.Core.ViewModels;
using Mini_Social_Networking_Web_App.Core.Models;
using Mini_Social_Networking_Web_App.Core.Repositories;

namespace Mini_Social_Networking_Web_App.Controllers
{
    public class GigsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        
        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _unitOfWork.Gigs.GetUsersUpcomingGigs(userId);

            return View(gigs);
        }


        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var vm = new GigsViewModel
            {
                UpcomingGigs = _unitOfWork.Gigs.GetGigsUserAttending(userId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending",
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(userId).ToLookup(a => a.GigId),
                Followings = _unitOfWork.Followings.GetFollowers(userId).ToLookup(x => x.FolloweeId)
            };

            return View("Gigs",vm);
        }




        [HttpPost]
        public ActionResult Search(GigsViewModel vm)
        {
            return RedirectToAction("Index", "Home", new { query = vm.SearchTerm });
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel( _unitOfWork.Genres.GetAllGenres(), "Add a Gig");
            return View("GigForm" , viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitOfWork.Gigs.GetGigWithAssociatedArtist(id);

            if (gig == null)
                return HttpNotFound();

            if (gig.Artist.Id != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new GigFormViewModel(gig.Id , 
                _unitOfWork.Genres.GetAllGenres() , 
                gig.DateTime.ToString("d MMM yyyy"), 
                gig.DateTime.ToString("HH:MM"),
                gig.GenreId, 
                gig.Venue,
                "Edit Gig");

            return View("GigForm",viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Details(int gigId)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAssociatedArtist(gigId);

            var Details = new GigDetailsViewModel(gig.Artist.Name,gig.Venue, gig.DateTime , gig.ArtistId);

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                Details.IsAuthenticated = true;

                Details.IsAttendding =
                    _unitOfWork.Attendances.GetAttendance(gig.Id, userId) != null;
               
                Details.IsFollowing = 
                    _unitOfWork.Followings.GetFollowing(gig.Artist.Id, userId) != null;
            }

            return View(Details);


        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.SetGenresList(_unitOfWork.Genres.GetAllGenres());
                return View("GigForm", vm);
            }

            string userId = User.Identity.GetUserId();
            var Followers = _unitOfWork.Followings.GetUsersFollowers(userId); 

            var gig = new Gig(userId, vm.Genre , vm.GetDateTime() , vm.Venue, Followers);
            _unitOfWork.Gigs.AddGig(gig);
            _unitOfWork.Complete();

            return RedirectToAction("Mine","Gigs");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.SetGenresList(_unitOfWork.Genres.GetAllGenres());
                return View("GigForm", vm);
            }

            var gig = _unitOfWork.Gigs.GetGigWithAttendees(vm.Id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.UpdateGig(vm.Venue, vm.GetDateTime() , vm.Genre);

            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Gigs");

        }

    }
}