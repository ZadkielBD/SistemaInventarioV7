using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Requerido.")]
        [MaxLength(60, ErrorMessage = "El Nombre no puede tener mas de 60 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerido")]
        [MaxLength(100, ErrorMessage = "La Descripcion debe ser maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Estado es requerido")]
        public bool Estado { get; set; }


    }
}
