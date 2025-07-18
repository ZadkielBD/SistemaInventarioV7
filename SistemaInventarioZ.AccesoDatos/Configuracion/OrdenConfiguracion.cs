﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaInventarioZ.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.AccesoDatos.Configuracion
{
    public class OrdenConfiguracion : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.UsuarioAplicacionId).IsRequired();
            builder.Property(x => x.FechaOrden).IsRequired();
            builder.Property(x => x.FechaPago).IsRequired();
            builder.Property(x => x.TotalOrden).IsRequired();
            builder.Property(x => x.EstadoOrden).IsRequired();
            builder.Property(x => x.EstadoPago).IsRequired();
            builder.Property(x => x.NombresCliente).IsRequired();
            builder.Property(x => x.NumeroEnvio).IsRequired(false);
            builder.Property(x => x.Carrier).IsRequired(false);
            builder.Property(x => x.TransaccionId).IsRequired(false);
            builder.Property(x => x.Telefono).IsRequired(false);
            builder.Property(x => x.Direccion).IsRequired(false);
            builder.Property(x => x.Ciudad).IsRequired(false);
            builder.Property(x => x.Pais).IsRequired(false);

            /* Relaciones */

            builder.HasOne(x => x.UsuaioAplicacion).WithMany()
                .HasForeignKey( x =>x.UsuarioAplicacionId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
