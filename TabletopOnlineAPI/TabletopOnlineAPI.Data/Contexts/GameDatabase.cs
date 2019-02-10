using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TabletopOnlineAPI.Data.Contexts
{
    public class GameDatabase : DbContext
    {
        public GameDatabase( DbContextOptions<GameDatabase> options )
            : base( options )
        { }
    }
}
