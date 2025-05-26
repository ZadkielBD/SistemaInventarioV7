using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "El Nombre debe ser de Maximo 60 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripcion es Requerida")]
        [MaxLength(100, ErrorMessage = "La Descripcion debe ser de Maximo 100 Caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Estado es Requerido")]
        public bool Estado { get; set; }
    }
}
