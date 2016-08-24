using Microsoft.AspNet.Identity;
using Mini_Social_Networking_Web_App.Core.Models;
using Mini_Social_Networking_Web_App.Core.Repositories;
using Mini_Social_Networking_Web_App.Core.ViewModels;
using Mini_Social_Networking_Web_App.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mini_Social_Networking_Web_App.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FolloweesController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var FolloweeIds =  _unitOfWork.Followings.GetUsersFolloweeIds(userId)
                .Select(u => u.Id)
                .ToList();

            IList<FollowingViewModel> viewModel = new List<FollowingViewModel>();

            for (int i = 0; i < FolloweeIds.Count; i++)
            {
                string id = FolloweeIds[i];
                var userName = _unitOfWork.Users.GetUser(id);

                if (userName != null)
                {
                    viewModel.Add(new FollowingViewModel
                    {
                        UserName = userName.Name,
                        Id = id
                    });
                }


            }

            return View(viewModel);
        }
    }
}