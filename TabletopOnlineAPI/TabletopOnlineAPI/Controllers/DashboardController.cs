using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopOnlineAPI.Controllers
{
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok( "The test worked!" );
        }
    }
}
