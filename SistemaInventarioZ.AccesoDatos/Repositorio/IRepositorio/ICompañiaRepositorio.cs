﻿using SistemaInventarioZ.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.AccesoDatos.Repositorio.IRepositorio
{
    public interface ICompañiaRepositorio : IRepositorio<Compañia>
    {
        void Actualizar(Compañia compañia);

    }
}