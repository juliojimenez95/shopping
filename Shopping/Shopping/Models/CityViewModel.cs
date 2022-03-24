﻿using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Departamento/Estado")]
        [MaxLength(50, ErrorMessage = "el campo {0}  debe tener maximo  {1}  caracteres.")]
        [Required(ErrorMessage = "El campo {0} es oblgatorio.")]
        public string Name { get; set; }

        public int StateId { get; set; }
    }
}
