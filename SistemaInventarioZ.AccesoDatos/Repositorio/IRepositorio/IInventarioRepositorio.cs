using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventarioZ.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.AccesoDatos.Repositorio.IRepositorio
{
    public interface IInventarioRepositorio : IRepositorio<Inventario>
    {
        void Actualizar(Inventario inventario);

        IEnumerable<SelectListItem> ObtenerTodosDropDownLista(string obj);

    }
}
