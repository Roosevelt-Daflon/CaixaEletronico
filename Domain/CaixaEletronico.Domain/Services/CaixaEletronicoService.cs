using CaixaEletronico.Domain.Entities;
using CaixaEletronico.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico.Domain.Services
{
    public class CaixaEletronicoService
    {
        private readonly IValorMonetarioRepository _valorMonetarioRepository;
        private const int QuantiadMaximaDeOpcoes = 3;

        public CaixaEletronicoService(IValorMonetarioRepository valorMonetarioRepository)
        {
            _valorMonetarioRepository = valorMonetarioRepository;
        }

        public List<List<(int, ValorMonetario)>> CalcularSaque(decimal valor)
        {
            var valoresMonetarios = _valorMonetarioRepository.GetAll();
            valoresMonetarios.Sort((a, b) => b.valor.Amount.CompareTo(a.valor.Amount));
            var resultados = new List<List<(int, ValorMonetario)>>();
            
            CalcularCombinacoes(valor, valoresMonetarios, new List<(int, ValorMonetario)>(), resultados);

            if (resultados.Count == 0)
                throw new System.ArgumentException("Não é possível sacar o valor informado");
            
            resultados = TratarResultado(resultados);
            
            
            
            return resultados;
        }

        private List<List<(int, ValorMonetario)>> TratarResultado(List<List<(int, ValorMonetario)>> resultados)
        {
            resultados = resultados.OrderBy(x => x.Sum(y => y.Item1)).Take(QuantiadMaximaDeOpcoes).ToList();
            foreach (var resultado in resultados.ToList())
                resultados[resultados.IndexOf(resultado)] =resultado.Where(y => y.Item1 != 0).ToList();

            return resultados;
        }

        private void CalcularCombinacoes(decimal valor, List<ValorMonetario> valoresMonetarios, List<(int, ValorMonetario)> combinacaoAtual, List<List<(int, ValorMonetario)>> resultado)
        {
            if (valor == 0)
            {
                resultado.Add(new List<(int, ValorMonetario)>(combinacaoAtual));
                return;
            }

            if (valor < 0 || !valoresMonetarios.Any())
                return;


            var valorMonetario = valoresMonetarios.First();
            var restantes = valoresMonetarios.Skip(1).ToList();

            for (int i = 0; i <= valor / valorMonetario.valor.Amount; i++)
            {
                combinacaoAtual.Add((i, valorMonetario));
                CalcularCombinacoes(valor - i * valorMonetario.valor.Amount, restantes, combinacaoAtual, resultado);
                combinacaoAtual.RemoveAt(combinacaoAtual.Count - 1);
            }
        }
    }
}