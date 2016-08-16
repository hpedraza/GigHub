using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Models;

namespace Mini_Social_Networking_Web_App.Repositories
{
    public class FollowingRepository
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
    }
}