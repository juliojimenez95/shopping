using System.ComponentModel.DataAnnotations;

namespace Shopping.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name ="Pais")]
        [MaxLength(50, ErrorMessage ="el campo {0}  debe tener maximo  {1}  caracteres.")]
        [Required(ErrorMessage ="El campo {0} es oblgatorio.")]
        public string Name { get; set; }
    }
}
