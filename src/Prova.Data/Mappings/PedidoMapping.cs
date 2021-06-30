using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.Bussiness.Models;

namespace Prova.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeProduto)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.DataVencimento)
                .IsRequired();

            builder.ToTable("Pedidos");
        }
    }
}