using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TabletopOnlineAPI.Data.Contexts;
using TabletopOnlineAPI.Data.Models;
using TabletopOnlineAPI.Models;

namespace TabletopOnlineAPI.Logic
{
    public class Authentication
    {
        private const int SALT_LENGTH = 16;
        private const int HASH_LENGTH = 24;
        private const int HASH_ITERATIONS = 10000;

        protected DatabaseContext _dbContext;

        public Authentication( DatabaseContext dbContext )
        {
            _dbContext = dbContext;
        }

        public bool Authenticate( UserCredentials ucred )
        {
            var user = _dbContext.Users.Where( u => u.Username == ucred.Username ).FirstOrDefault();
            var passwordHash = Convert.FromBase64String( user.Password );
            var salt = new byte[ SALT_LENGTH ];
            Array.Copy( passwordHash , 0 , salt , 0 , SALT_LENGTH );
            var hash = KeyDerivation.Pbkdf2( ucred.Password , salt , KeyDerivationPrf.HMACSHA256 , HASH_ITERATIONS , HASH_LENGTH );

            return passwordHash.TakeLast( HASH_LENGTH ).ToArray() == hash;
        }

        public bool Authenticate( User user , Guid sessionId ) =>
            _dbContext.Sessions.Where( s => s.User == user && s.SessionId == sessionId ).Any();

        public void SavePassword( User user , string password )
        {
            var salt = new byte[ SALT_LENGTH ];
            new RNGCryptoServiceProvider().GetBytes( salt );
            var hash = KeyDerivation.Pbkdf2( password , salt , KeyDerivationPrf.HMACSHA256 , HASH_ITERATIONS , HASH_LENGTH );
            var store = new byte[ SALT_LENGTH + HASH_LENGTH ];
            Array.Copy( salt , 0 , store , 0 , SALT_LENGTH );
            Array.Copy( hash , 0 , store , SALT_LENGTH , HASH_LENGTH );
            var passwordHash = Convert.ToBase64String( store );

            user.Password = passwordHash;
            _dbContext.SaveChanges();
        }
    }
}
