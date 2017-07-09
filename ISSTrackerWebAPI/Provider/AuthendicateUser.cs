using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISSTrackerWebAPI.Interface;

namespace ISSTrackerWebAPI.Provider
{
    public class AuthendicateUser : Interface.IAuthInterface
    {
        // check the user id and passwor in DB
        public bool Authendicate(string userId, string password)
        {
            if (userId == "test" && password == "pass")
                return true;
            else

                return false;

        }
    }
}