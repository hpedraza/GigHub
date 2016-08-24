using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;
using Mini_Social_Networking_Web_App.Core.Repositories;

namespace Mini_Social_Networking_Web_App.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        public ApplicationUser GetUser(string userId)
        {
            return _context.Users.Where(u => u.Id == userId).SingleOrDefault();
        }
    }
}