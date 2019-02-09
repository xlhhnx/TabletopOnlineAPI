using System;
using System.Collections.Generic;
using System.Text;

namespace TabletopOnlineAPI.Data.Models
{
    public class Session
    {
        public Guid SessionId { get; set; }
        public User User { get; set; }

        // Hide constructor
        internal Session()
        { }

        public static Session NewSession(User user)
        {
            return new Session()
            {
                SessionId = Guid.NewGuid() ,
                User = user
            };
        }
    }
}
