using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TabletopOnlineAPI.Data;
using TabletopOnlineAPI.Data.Attributes;
using TabletopOnlineAPI.Data.Contexts;
using TabletopOnlineAPI.Data.Models;

namespace TabletopOnlineAPI.Logic
{
    public class UserManagement
    {
        AppDatabase _appDb;
        Authentication _auth;

        public UserManagement( AppDatabase appDb , Authentication auth )
        {
            _appDb = appDb;
            _auth = auth;
        }

        public bool TryCreateUser( User user , out List<string> errors )
        {
            errors = new List<string>();
            if ( UserExists( user.Username ) )
                errors.Add( "A user with that username already exists." );

            var name = new MinLengthAttribute( Constants.MINIMUM_USERNAME_LENGTH );
            if ( !name.IsValid( user.Username ) )
                errors.Add( "The user name does not meet the minimum length requirement. It must be 6 characters long at minimum." );

            var disp = new MinLengthAttribute( Constants.MINIMUM_DISPLAY_LENGTH );
            if ( !disp.IsValid( user.DisplayName ) )
                errors.Add( "The display name does not meet the minimum length requirement. It must be 3 characters long at minimum." );

            var validEmail = ValidateEmail(user.Email);
            if ( user.Email != null && user.Email != string.Empty && !validEmail  )
                errors.Add( "The email entered is invalid." );

            var validPhone = ValidatePhoneNumber( user.PhoneNumber );
            if ( user.PhoneNumber != null && user.PhoneNumber != string.Empty && !validPhone )
                errors.Add( "The phone number entered is invalid." );

            if ( !validEmail && !validPhone )
                errors.Add( "User must register a valid email or phone number." );

            if ( !ValidatePassword( user.Password , out var passwordErrors ) )
                errors.AddRange( passwordErrors );

            if ( !errors.Any() )
            {
                _appDb.Users.Add( user );
                _auth.UpdatePassword( user , user.Password );
                _appDb.SaveChanges();
            }

            return !errors.Any();
        }

        public bool TryGetUser( User user , out List<string> errors )
        {
            errors = new List<string>();
            
            // TODO : Try to get the user
            
            errors.Add( "Not implemented." );
            return !errors.Any();
        }

        public bool TryUpdateUser( User user , out List<string> errors )
        {
            errors = new List<string>();

            // TODO : Try to update the user
            
            errors.Add( "Not implemented." );
            return !errors.Any();
        }

        public bool TryDeleteUser( User user , out List<string> errors )
        {
            errors = new List<string>();

            // TODO : Try to delete the user

            errors.Add( "Not implemented." );
            return !errors.Any();
        }

        public bool UserExists( string username )
        {
            return _appDb.Users.Any( u => u.Username == username );
        }

        public bool ValidatePassword( string password , out List<string> errors )
        {
            errors = new List<string>();

            var len = new MinLengthAttribute( Constants.MINIMUM_PASSWORD_LENGTH );
            if ( !len.IsValid(password) )
                errors.Add( "The password does not meet the minimum length requirement. It must be 8 characters long at minimum." );

            var spec = new RequireSpecialCharactersAttribute();
            if ( !spec.IsValid( password ) )
                errors.Add( "The password does not have at least 1 special character." );

            var num = new RequireNumberCharactersAttribute();
            if ( !num.IsValid( password ) )
                errors.Add( "The password does not have at least 1 number character." );
            
            var up = new RequireUpperCaseCharactersAttribute();
            if ( !up.IsValid( password ) )
                errors.Add( "The password does not have at least 1 upper case character." );
            
            var low = new RequireLowerCaseCharactersAttribute();
            if ( !low.IsValid( password ) )
                errors.Add( "The password does not have at least 1 lower case character." );

            return !errors.Any();
        }

        public bool ValidateEmail( string email )
        {
            var attr = new EmailAddressAttribute();
            return attr.IsValid( email );
        }

        public bool ValidatePhoneNumber( string phoneNumber )
        {
            var attr = new PhoneAttribute();
            return attr.IsValid( phoneNumber );
        }
    }
}
