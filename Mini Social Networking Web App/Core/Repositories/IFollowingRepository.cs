using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Core.Repositories
{
    public interface IFollowingRepository
    {
        IEnumerable<Followings> GetFollowers(string userId);
        List<ApplicationUser> GetUsersFollowers(string userId);
        Followings GetFollowing(string followeeId, string followerId);
        ILookup<string, Followings> CreateUserFollowingsLookUp(string userId);
        List<ApplicationUser> GetUsersFolloweeIds(string userId);
    }
}