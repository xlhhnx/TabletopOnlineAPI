﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TabletopOnlineAPI.Data.Attributes
{
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property , AllowMultiple = false , Inherited = false )]
    public class RequireLowerCaseCharactersAttribute : ValidationAttribute
    {
        private int _numberRequired;

        public RequireLowerCaseCharactersAttribute( int numberRequired = 1 )
        {
            _numberRequired = numberRequired;
        }

        public override bool IsValid( object value )
        {
            if ( !(value is string) )
                return false;
            
            var number = 0;
            var val = value as string;

            foreach ( var c in val )
            {
                if ( char.IsLower( c ) )
                    number++;
            }

            return number >= _numberRequired;
        }
    }
}
