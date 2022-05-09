using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shopping.Data.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name = "Departamento/Estado")]
        [MaxLength(50, ErrorMessage = "el campo {0}  debe tener maximo  {1}  caracteres.")]
        [Required(ErrorMessage = "El campo {0} es oblgatorio.")]
        public string Name { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
        [Display(Name = "Departamentos/Estados")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
