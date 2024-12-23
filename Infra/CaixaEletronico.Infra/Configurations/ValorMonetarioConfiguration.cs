using CaixaEletronico.Domain.Entities;
using CaixaEletronico.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaixaEletronico.Infra.Configurations;

public class ValorMonetarioConfiguration : IEntityTypeConfiguration<ValorMonetario>
{
    public void Configure(EntityTypeBuilder<ValorMonetario> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("ValoresMonetarios");
        builder.OwnsOne(x => x.valor).Property(p => p.Amount).HasColumnName("Valor");
        builder.OwnsOne(x => x.Quantidade).Property(q => q.Amount).HasColumnName("Quantidade");
        builder.OwnsOne(x => x.TipoMoeda).Property(t => t.Moeda).HasColumnName("TipoMoeda");
        
    }
}