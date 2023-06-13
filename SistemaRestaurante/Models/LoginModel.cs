using System.ComponentModel.DataAnnotations;
namespace SistemaRestaurante.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Clave { get; set; }


    }
}
