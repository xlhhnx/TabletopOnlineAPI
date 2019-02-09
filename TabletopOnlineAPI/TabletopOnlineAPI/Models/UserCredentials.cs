using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopOnlineAPI.Models
{
    public class UserCredentials
    {
        public string Username { get; protected set; }
        public string Password { get; protected set; }

        public UserCredentials( string username , string password )
        {
            Username = username;
            Password = password;
        }
    }
}
