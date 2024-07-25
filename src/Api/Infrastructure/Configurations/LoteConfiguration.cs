using Api.Domain.Fincas;
using Api.Domain.Lotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Configurations;

public sealed class LoteConfiguration : IEntityTypeConfiguration<Lote>
{
    public void Configure(EntityTypeBuilder<Lote> builder)
    {
        builder.ToTable("Lotes");

        builder.HasKey(lote => lote.Id);

        builder.Property(lote => lote.Nombre)
            .HasMaxLength(100);

        builder.Property(lote => lote.Etapa)
            .HasMaxLength(100);

        builder.HasOne<Finca>()
            .WithMany()
            .HasForeignKey(lote => lote.Id_Finca);

        
    }
}
