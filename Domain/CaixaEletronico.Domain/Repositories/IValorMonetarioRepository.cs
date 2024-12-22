using CaixaEletronico.Domain.Entities;

namespace CaixaEletronico.Domain.Repositories;

public interface IValorMonetarioRepository
{
    public List<ValorMonetario> GetAll();
}