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
        // builder.HasData(
        //     new ValorMonetario
        //     {
        //         Id = 1,
        //         valor = new Valor(100),
        //         Quantidade = new Quantidade(10), // Seed the value directly
        //         TipoMoeda = new TipoMoeda("BRL")
        //     },
        //     new ValorMonetario
        //     {
        //         Id = 2,
        //         valor = new Valor(50),
        //         Quantidade = new Quantidade(10),
        //         TipoMoeda = new TipoMoeda("BRL")
        //     },
        //     new ValorMonetario
        //     {
        //         Id = 4,
        //         valor = new Valor(20),
        //         Quantidade = new Quantidade(10),
        //         TipoMoeda = new TipoMoeda("BRL")
        //     },
        //     new ValorMonetario
        //     {
        //         Id = 5,
        //         valor = new Valor(10),
        //         Quantidade = new Quantidade(10),
        //         TipoMoeda = new TipoMoeda("BRL")
        //     },
        //     new ValorMonetario
        //     {
        //         Id = 6,
        //         valor = new Valor(5),
        //         Quantidade = new Quantidade(10),
        //         TipoMoeda = new TipoMoeda("BRL")
        //     },
        //     new ValorMonetario
        //     {
        //         Id = 7,
        //         valor = new Valor(2),
        //         Quantidade = new Quantidade(10),
        //         TipoMoeda = new TipoMoeda("BRL")
        //     }
        // );
    }
}