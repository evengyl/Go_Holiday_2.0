using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Models.ModelsView.Forms
{
    public class UserSignUp
    {
        [Required(ErrorMessage = "Email obligatoire")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Prénom obligatoire")]
        [MaxLength(50, ErrorMessage = "Le Prénom ne dois pas dépasser 50 caractères")]
        [MinLength(2, ErrorMessage = "Le Prénom ne dois pas contenir moins de 2 caractères")]
        [DisplayName("Prénom")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Nom obligatoire")]
        [MaxLength(50, ErrorMessage = "Le Nom ne dois pas dépasser 50 caractères")]
        [MinLength(2, ErrorMessage = "Le Nom ne dois pas contenir moins de 2 caractères")]
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Mot de passe obligatoire")]
        [MaxLength(20, ErrorMessage = "Le mot de passe ne dois pas dépasser 20 caractères")]
        [MinLength(6, ErrorMessage = "Le mot de passe ne dois pas contenir moins de 6 caractères")]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password")]
        [Required(ErrorMessage = "Les deux mots de passe ne corresponde pas.")]
        [DisplayName("Confirmer le Mot de passe")]
        [DataType(DataType.Password)]
        public string PasswordVerify { get; set; }
    }
}
