using System.ComponentModel.DataAnnotations;

namespace api.eavila.curso.Models
{
    public class PersonaModel
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(2)]
        public string Nombre { get; set; }

        public string Apellido  { get; set; }

        public int Edad { get; set; }

        public string Email { get; set; }

        public string Telefono{ get; set; }
    }
}
