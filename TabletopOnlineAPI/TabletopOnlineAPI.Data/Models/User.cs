using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TabletopOnlineAPI.Data.Attributes;

namespace TabletopOnlineAPI.Data.Models
{
    public class User
    {
        [Required]
        [MinLength(Constants.MINIMUM_USERNAME_LENGTH)]
        public string Username { get; set; }
        
        [Required]
        [MinLength(Constants.MINIMUM_PASSWORD_LENGTH)]
        [RequireSpecialCharacters]
        [RequireNumberCharacters]
        [RequireUpperCaseCharacters]
        [RequireLowerCaseCharacters]
        public string Password { get; set; }
        
        [Required]
        public string DisplayName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        
        [Required]
        public bool Active { get; set; }

        [Required]
        public bool Admin { get; set; }

        public List<Session> Sessions { get; set; }
    }
}
