using CaixaEletronico.Domain.Entities;
using CaixaEletronico.Domain.Repositories;
using CaixaEletronico.Infra.Context;

namespace CaixaEletronico.Infra.Repositories;

public class ValorMonetarioRepository : IValorMonetarioRepository
{
    private readonly CaixaEletronicoContext _context;
    
    public ValorMonetarioRepository(CaixaEletronicoContext context)
    {
        _context = context;
    }
    
    public List<ValorMonetario> GetAll() => _context.ValoresMonetarios.ToList();
}