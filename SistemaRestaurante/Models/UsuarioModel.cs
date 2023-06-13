using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace SistemaRestaurante.Models
{
    public class UsuarioModel
    {

        [Key] public int Id_Usario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Clave { get; set; }

    }
}
