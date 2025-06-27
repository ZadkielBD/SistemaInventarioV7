using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.Modelos.ViewModels
{
    public class KardexInventarioVM
    {
        public Producto Producto { get; set; }

        public IEnumerable<KardexInventario> KardexInventarioLista { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }
    }
}
