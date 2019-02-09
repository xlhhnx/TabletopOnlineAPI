using System;
using System.Collections.Generic;
using System.Text;

namespace TabletopOnlineAPI.Data.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }

        public List<Session> Sessions { get; set; }
    }
}
