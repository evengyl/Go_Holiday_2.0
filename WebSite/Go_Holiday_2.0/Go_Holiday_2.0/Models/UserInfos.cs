using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Models
{
    public class UserInfos
    {
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [DisplayName("Prénom")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [DisplayName("Adresse Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DisplayName("Rue")]
        [DataType(DataType.Text)]
        public string Rue { get; set; }


        [DisplayName("Ville")]
        [DataType(DataType.Text)]
        public string Ville { get; set; }


        [DisplayName("Pays")]
        [DataType(DataType.Text)]
        public string Pays { get; set; }


        [DisplayName("Numéro de boite")]
        [DataType(DataType.Text)]
        public string Numero { get; set; }


        [DisplayName("Code Postal")]
        [DataType(DataType.Text)]
        public int CodePostal { get; set; }


        [DisplayName("Gsm / portable")]
        [DataType(DataType.Text)]
        public string Gsm { get; set; }


        [DisplayName("Numéro de téléphone fixe")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }

        /* n'est pas repris dans le model pour l'affichage du edit profil */
        public string TypeUser { get; set; }

        public BackgroundProfil BackgroundProfil { get; set; }
    }
}
