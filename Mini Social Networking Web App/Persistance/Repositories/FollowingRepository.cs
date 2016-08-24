using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Mini_Social_Networking_Web_App.Core.Repositories;
using Mini_Social_Networking_Web_App.Persistance;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Persistance.Repositories
{


    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Followings> GetFollowers(string userId)
        {
            return _context.Followings
                .Where(x => x.FollowerId == userId)
                .ToList();
        }

        public List<ApplicationUser> GetUsersFollowers(string userId)
        {
            return _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Followers)
                .ToList();
        }

        public List<ApplicationUser> GetUsersFolloweeIds(string userId)
        {
            return _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Followers)
                .ToList();
        }

        public ILookup<string, Followings> CreateUserFollowingsLookUp(string userId)
        {
            return _context.Followings
                    .Where(x => x.FollowerId == userId)
                    .ToList()
                    .ToLookup(x => x.FolloweeId); 
        }

        public Followings GetFollowing(string followeeId, string followerId)
        {
            return _context.Followings
                .Where(F => F.FolloweeId == followeeId && F.FollowerId == followerId)
                .SingleOrDefault();
        }
    }
}