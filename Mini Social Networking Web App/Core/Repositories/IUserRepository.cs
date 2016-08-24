using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Social_Networking_Web_App.Core.Models;

namespace Mini_Social_Networking_Web_App.Core.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string userId);        
    }
}
