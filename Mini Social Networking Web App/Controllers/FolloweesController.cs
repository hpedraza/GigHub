using Microsoft.AspNet.Identity;
using Mini_Social_Networking_Web_App.Models;
using Mini_Social_Networking_Web_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mini_Social_Networking_Web_App.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context;
        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var FolloweeIds = _context.Followings.Where(u => u.FollowerId == userId).Select(u => u.FolloweeId).ToList();
            IList<FollowingViewModel> viewModel = new List<FollowingViewModel>();

            for (int i = 0; i < FolloweeIds.Count; i++)
            {
                string id = FolloweeIds[i];
                var userName = _context.Users.Where(u => u.Id == id).Select(u => u.Name).Single<string>();

                if (userName != null)
                {
                    viewModel.Add(new FollowingViewModel
                    {
                        UserName = userName,
                        Id = id

                    });
                }


            }

            return View(viewModel);
        }
    }
}