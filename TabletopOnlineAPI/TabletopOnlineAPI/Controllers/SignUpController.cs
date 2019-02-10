using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopOnlineAPI.Data.Models;
using TabletopOnlineAPI.Logic;

namespace TabletopOnlineAPI.Controllers
{
    [Route("[controller]")]
    public class SignUpController : Controller
    {
        Authentication _auth;
        UserManagement _userMgmt;

        public SignUpController( Authentication auth , UserManagement userMgmt )
        {
            _auth = auth;
            _userMgmt = userMgmt;
        }

        [HttpPost]
        [Route( "[action]" )]
        public IActionResult CheckUsernameAvaliability( [FromBody] string username )
        {
            if ( _userMgmt.UserExists( username ) )
                return BadRequest( "A user with that username already exists." );

            return Ok();
        }

        [HttpPost]
        [Route( "[action]" )]
        public IActionResult ValidatePassword( [FromBody] string password )
        {
            if ( !_userMgmt.ValidatePassword( password , out var errors ) )
                return BadRequest( string.Join( '\n' , errors ) );

            return Ok();
        }

        [HttpPut]
        [Route( "[action]" )]
        public IActionResult CreateUser( [FromBody] User user )
        {
            if ( !_userMgmt.TryCreateUser( user , out var errors ) )
                return BadRequest( string.Join( '\n' , errors ) );

            return Ok();
        }
    }
}
