using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Models
{
    public class RegisterModel
    {
        [Required]
        [DisplayName("First Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter your email address correctly.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Passwords must match.")]
        public string RePassword { get; set; }
    }
}