using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authorization.Models
{
    public interface IUsersPortalRepository
    {
        List<UserPortal> UsersPortal { get; }
    }

    public class UsersPortalRepository : IUsersPortalRepository
    {
        private List<UserPortal> data;

        public UsersPortalRepository()
        {
            data = new List<UserPortal>()
            {
                new UserPortal() { UserName = "Admin", Password = "123"  }
            };
        }

        List<UserPortal> IUsersPortalRepository.UsersPortal => data;
    }
}
