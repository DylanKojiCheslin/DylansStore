using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DylansStore.Models
{
    public class Login
    {
    
        [Required]
        public string UserName{get; set;}
        [Required, DataType(DataType.Password)]
        public string PassWord { get; set; }
    }

    public class Register
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password),
        Compare("Password", ErrorMessage="Passwords don't match")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

}