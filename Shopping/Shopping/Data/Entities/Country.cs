using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shopping.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name ="Pais")]
        [MaxLength(50, ErrorMessage ="el campo {0}  debe tener maximo  {1}  caracteres.")]
        [Required(ErrorMessage ="El campo {0} es oblgatorio.")]
        public string Name { get; set; }


        public ICollection<State> States { get; set; }

        [Display(Name ="Departamentos/Estados")]
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
