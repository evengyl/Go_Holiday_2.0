using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LoginConnect
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        [DisplayName("Pseudo")]
        [Required(ErrorMessage = "Login obligatoire")]
        public string Login { get; set; }


        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Mot de passe obligatoire")]
        public string Password { get; set; }
    }
}
