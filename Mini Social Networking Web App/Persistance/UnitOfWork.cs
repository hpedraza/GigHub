
using Mini_Social_Networking_Web_App.Core.Repositories;
using Mini_Social_Networking_Web_App.Persistance.Repositories;
using Mini_Social_Networking_Web_App.Persistance;

namespace Mini_Social_Networking_Web_App.Persistance
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }
        public IFollowingRepository Followings { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IUserRepository Users { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Gigs = new GigRepository(db);
            Attendances = new AttendanceRepository(db);
            Followings = new FollowingRepository(db);
            Genres = new GenreRepository(db);
            Users = new UserRepository(db);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}