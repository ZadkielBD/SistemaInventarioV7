﻿using SistemaInventarioZ.AccesoDatos.Data;
using SistemaInventarioZ.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioZ.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.AccesoDatos.Repositorio
{
    public class OrdenDetalleRepositorio : Repositorio<OrdenDetalle>, IOrdenDetalleRepositorio
    {
        private readonly ApplicationDbContext _db;

        public OrdenDetalleRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(OrdenDetalle ordenDetalle)
        {
            _db.Update(ordenDetalle);
        }
    }
}
