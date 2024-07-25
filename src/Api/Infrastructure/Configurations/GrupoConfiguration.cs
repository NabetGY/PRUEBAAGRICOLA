using Api.Domain.Grupos;
using Api.Domain.Lotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Configurations;

public sealed class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
{
    public void Configure(EntityTypeBuilder<Grupo> builder)
    {
        builder.ToTable("Grupos");

        builder.HasKey(grupo => grupo.Id);

        builder.Property(grupo => grupo.Nombre)
            .HasMaxLength(100);

        builder.HasOne<Lote>()
            .WithMany()
            .HasForeignKey(grupo => grupo.Id_Lote);
    }
}
