using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopOnlineAPI.Logic;
using TabletopOnlineAPI.Models;

namespace TabletopOnlineAPI.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        protected Authentication _auth;

        public LoginController(Authentication auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult TryLogin( [FromBody] UserCredentials ucred )
        {
            if ( _auth.Authenticate( ucred ) )
                return Ok();
            else
                return Unauthorized();
        }
    }
}
