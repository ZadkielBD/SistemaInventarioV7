using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaInventarioZ.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioZ.AccesoDatos.Configuracion
{
    public class CarroCompraConfiguracion : IEntityTypeConfiguration<CarroCompra>
    {
        public void Configure(EntityTypeBuilder<CarroCompra> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.UsuarioApliacionId).IsRequired();
            builder.Property(x => x.ProductoId).IsRequired();
            builder.Property(x => x.Cantidad).IsRequired();

            /* Relaciones */

            builder.HasOne(x => x.UsuarioAplicacion).WithMany()
                .HasForeignKey( x =>x.UsuarioApliacionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Producto).WithMany()
               .HasForeignKey(x => x.ProductoId)
               .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
