using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Authentication.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Tiene que proporcionar un nombre de usuario")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Tiene que proporcionar una contraseña")]
        public string Password { get; set; }
    }
}
