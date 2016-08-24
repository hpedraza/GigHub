using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mini_Social_Networking_Web_App.Core.Models
{
    public class Followings
    {
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }


        public string FollowerId { get; set; }

        public string FolloweeId { get; set; }

        public Followings()
        {

        }

        public Followings(string followerId, string followeeId)
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
        }

    }
}