using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Todo
    {
        [HiddenInput]
        public int id { get; set; }

        [Required(ErrorMessage = "Un titre est obligatoire")]
        public string Titre { get; set; }


        [Required(ErrorMessage = "Une description est obligatoire")]
        public string Description { get; set; }


        [Required(ErrorMessage = "La date aussi")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool Done { get; set; }
    }
}
