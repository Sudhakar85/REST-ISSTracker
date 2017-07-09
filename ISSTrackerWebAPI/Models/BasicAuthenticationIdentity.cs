using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ISSTrackerWebAPI.Models
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {

        public BasicAuthenticationIdentity(string strUserName, string strWord) : base(strUserName = "Test")
        {
            word = strWord;
            UserName = strUserName;

        }
        public string word { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }



    }
}