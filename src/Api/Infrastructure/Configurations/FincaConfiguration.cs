using Api.Domain.Fincas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Configurations;

public sealed class FincaConfiguration : IEntityTypeConfiguration<Finca>
{
    public void Configure(EntityTypeBuilder<Finca> builder)
    {
        builder.ToTable("Fincas");

        builder.HasKey(finca => finca.Id);

        builder.Property(finca => finca.Nombre)
            .HasMaxLength(100);

        builder.Property(finca => finca.Ubicacion)
            .HasMaxLength(200);

        builder.Property(finca => finca.Descripcion)
            .HasMaxLength(500);
    }
}
