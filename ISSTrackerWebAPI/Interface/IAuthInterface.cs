using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSTrackerWebAPI.Interface
{
    interface IAuthInterface
    {
        bool Authendicate(string userId, string password);
    }

}
