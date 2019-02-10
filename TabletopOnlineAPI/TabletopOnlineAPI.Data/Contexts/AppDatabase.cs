using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TabletopOnlineAPI.Data.Models;

namespace TabletopOnlineAPI.Data.Contexts
{
    public class AppDatabase : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Session> Sessions;

        public AppDatabase( DbContextOptions<AppDatabase> options )
            : base( options )
        { }
    }
}
