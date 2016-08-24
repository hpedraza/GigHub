using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Mini_Social_Networking_Web_App.Core.Repositories
{

        public interface IUnitOfWork
        {
            IGigRepository Gigs { get; }
            IAttendanceRepository Attendances { get; }
            IFollowingRepository Followings { get; }
            IGenreRepository Genres { get; }
            IUserRepository Users { get; }
            void Complete();
        }
  
}