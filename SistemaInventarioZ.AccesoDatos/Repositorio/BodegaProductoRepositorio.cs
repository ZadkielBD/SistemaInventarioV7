using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventarioZ.AccesoDatos.Data;
using SistemaInventarioZ.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioZ.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.AccesoDatos.Repositorio
{
    public class BodegaProductoRepositorio : Repositorio<BodegaProducto>, IBodegaProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(BodegaProducto bodegaProducto)
        {
            var bodegaproductoBD = _db.BodegasProductos.FirstOrDefault(b => b.Id == bodegaProducto.Id);
            if (bodegaproductoBD != null)
            {

                bodegaproductoBD.Cantidad = bodegaProducto.Cantidad;

                _db.SaveChanges();

            }
        }
    }
}
