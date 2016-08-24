using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Core.Repositories
{
    public interface IGigRepository
    {
        Gig GetGigWithAttendees(int id);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        List<Gig> GetUsersUpcomingGigs(string userId);
        Gig GetGigWithAssociatedArtist(int gigId);
        IEnumerable<Gig> GetAllUpcomingGigs();
        void AddGig(Gig gig);
    }
}