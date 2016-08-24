using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Repositories;
using Mini_Social_Networking_Web_App.Persistance;
using Mini_Social_Networking_Web_App.Core.Models;
namespace Mini_Social_Networking_Web_App.Persistance.Repositories
{


    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }
    }
}