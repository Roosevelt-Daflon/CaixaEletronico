using CaixaEletronico.Domain.Entities;
using CaixaEletronico.Domain.ValueObjects;
using CaixaEletronico.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CaixaEletronico.Infra.Context;

public class CaixaEletronicoContext : DbContext
{
    public DbSet<ValorMonetario> ValoresMonetarios { get; set; }

    public bool HealthCheck;
    
    public CaixaEletronicoContext(DbContextOptions<CaixaEletronicoContext> options) : base(options)
    {
        HealthCheck = Database.CanConnect();
        Console.WriteLine(HealthCheck);
    }
    
    public CaixaEletronicoContext()
    {
        
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.ApplyConfiguration(new ValorMonetarioConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}