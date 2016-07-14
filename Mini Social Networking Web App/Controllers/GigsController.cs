using Microsoft.AspNet.Identity;
using Mini_Social_Networking_Web_App.Models;
using Mini_Social_Networking_Web_App.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;

namespace Mini_Social_Networking_Web_App.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GigsController()
        {
            // worrt about Dependency Injection, repository pattern later 
            
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var FolloweeIds = _context.Followings.Where(u => u.FollowerId == userId).Select(u => u.FolloweeId).ToList();
            IList<FollowingViewModel> viewModel = new List<FollowingViewModel>();

            for(int i = 0; i < FolloweeIds.Count; i++)
            {
                string id = FolloweeIds[i];
                var userName = _context.Users.Where( u=>u.Id == id ).Select(u => u.Name).Single<string>();

                if (userName != null)
                {
                    viewModel.Add(new FollowingViewModel {
                        UserName = userName,
                        Id = id
                          
                    });
                }


            }

            return View(viewModel);

        }



        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist).
                Include(g => g.Genre)
                .ToList();

            var vm = new GigsViewModel
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending"
            };

            return View("Gigs",vm);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFromViewModel
            {
                Genres = _context.Genres.ToList()
            };
        
        
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFromViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Genres = _context.Genres.ToList();
                return View("Create", vm);
            }
                

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                GenreId = vm.Genre,
                DateTime = vm.GetDateTime(),
                Venue = vm.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");

        }

    }
}