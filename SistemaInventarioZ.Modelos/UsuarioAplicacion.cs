using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.Modelos
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required(ErrorMessage ="El nombre es Requerido")]
        [MaxLength(80)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los Apellidos son Requeridos")]
        [MaxLength(80)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "La Direccion es Requerida")]
        [MaxLength(200)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La Ciudad es Requerido")]
        [MaxLength(60)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El País es Requerido")]
        [MaxLength(60)]
        public string Pais { get; set; }

        [NotMapped] // No se agrega a la tabla
        public string Role { get; set; }
    }
}
