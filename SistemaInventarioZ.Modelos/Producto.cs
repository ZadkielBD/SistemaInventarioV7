using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Numero de Serie es Requerido.")]
        [MaxLength(60, ErrorMessage = "El Numero de Serie no puede tener mas de 60 caracteres.")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerido")]
        [MaxLength(100, ErrorMessage = "La Descripcion debe ser maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Precio es requerido")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El Costo es requerido")]
        public double Costo { get; set; }

        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "El Estado es requerido")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "La Categoria es requerida")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "La Marca es requerida")]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        public int? PadreId { get; set; }

        public virtual Producto Padre { get; set; }
    }
}
