using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TabletopOnlineAPI.Data.Models;

namespace TabletopOnlineAPI.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Session> Sessions;

        public DatabaseContext( DbContextOptions<DatabaseContext> options )
            : base( options )
        { }
    }
}
