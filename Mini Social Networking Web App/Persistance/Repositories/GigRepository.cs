using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Repositories;
using Mini_Social_Networking_Web_App.Persistance;
using Mini_Social_Networking_Web_App.Core.Models;
using System.Data.Entity;

namespace Mini_Social_Networking_Web_App.Persistance.Repositories
{

    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gig> GetAllUpcomingGigs()
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);
        }

        public Gig GetGigWithAttendees( int id)
        {
            return _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public List<Gig> GetUsersUpcomingGigs(string userId)
        {
            return _context.Gigs
                .Where(g => g.ArtistId == userId &&
                       g.IsCanceled != true &&
                       g.DateTime > DateTime.Now)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGigWithAssociatedArtist(int gigId)
        {
            return _context.Gigs
                .Include(x => x.Artist)
                .Single(g => g.Id == gigId);
        }

        public void AddGig(Gig gig)
        {
            _context.Gigs.Add(gig);
        }


    }
}