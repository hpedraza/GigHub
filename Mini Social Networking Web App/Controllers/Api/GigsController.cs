﻿using Microsoft.AspNet.Identity;
using Mini_Social_Networking_Web_App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Mini_Social_Networking_Web_App.Persistance;

namespace Mini_Social_Networking_Web_App.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs
                .Include(x => x.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.Cancel();

            _context.SaveChanges();

            return Ok();
        }
    }
}
