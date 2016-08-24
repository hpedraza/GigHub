using Mini_Social_Networking_Web_App.Controllers;
using Mini_Social_Networking_Web_App.Core.ViewModels;
using Mini_Social_Networking_Web_App.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Mini_Social_Networking_Web_App.Core.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }


        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update = 
                    (c => c.Update(this));

                Expression<Func<GigsController, ActionResult>> create =
                        (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name; 
            }
        }

/////////////////////////////////////
//------ Functions
//
//
        public DateTime GetDateTime()
        {     
            return DateTime.Parse(
                string.Format("{0} {1}", Date, Time)
                );
        }


        public void SetGenresList(IEnumerable<Genre> genres)
        {
            Genres = genres;
        }

//////////////////////////////////////
//------ Constructors
//
//
        public GigFormViewModel() { }

        public GigFormViewModel(int gigId , IEnumerable<Genre> genres, string Date, string Time, byte GenreId, string venue, string heading)
        {
            Id = gigId;
            Genres = genres;
            this.Date = Date;
            this.Time = Time;
            Genre = GenreId;
            Venue = venue;
            Heading = heading;
        }

        public GigFormViewModel(IEnumerable<Genre> genres , string header)
        {
            Genres = genres;
            Heading = header;
        }

    }
}