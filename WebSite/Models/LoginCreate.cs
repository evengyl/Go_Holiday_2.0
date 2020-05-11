using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LoginCreate
    {
        [DisplayName("Pesudo")]
        [Required(ErrorMessage = "Login obligatoire")]
        public string Login { get; set; }

        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mot de passe obligatoire")]
        public string Password { get; set; }


        [Compare("Password")]
        [DisplayName("Confirmer le Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Les deux mots de passe ne corresponde pas.")]
        public string PasswordVerif { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Nom obligatoire")]
        public string Name { get; set; }

        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Prénom obligatoire")]
        public string LastName { get; set; }
    }
}
