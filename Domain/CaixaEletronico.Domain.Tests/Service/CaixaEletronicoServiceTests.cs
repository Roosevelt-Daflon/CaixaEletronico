using System;
using System.Collections.Generic;
using CaixaEletronico.Domain.Entities;
using CaixaEletronico.Domain.Repositories;
using CaixaEletronico.Domain.Services;
using CaixaEletronico.Domain.ValueObjects;
using Moq;
using Xunit;

namespace CaixaEletronico.Tests.Services
{
    public class CaixaEletronicoServiceTests
    {
        [Fact]
        public void CalcularSaque_ValorValido_DeveRetornarAteTresOpcoes()
        {
            // Arrange
            var mockRepository = new Mock<IValorMonetarioRepository>();
            mockRepository.Setup(repo => repo.GetAll()).Returns(GetFakeValoresMonetarios());

            var service = new CaixaEletronicoService(mockRepository.Object);
            decimal valorSaque = 150;

            // Act
            var resultado = service.CalcularSaque(valorSaque);

            // Assert
            Assert.True(resultado.Count <= 3);
            Assert.Contains(resultado, opcao => opcao.Count == 2 && opcao[0].Item1 == 1 && opcao[0].Item2.valor.Amount == 100 && opcao[1].Item1 == 1 && opcao[1].Item2.valor.Amount == 50);
        }

        [Fact]
        public void CalcularSaque_ValorInvalido_DeveLancarExcecao()
        {
            // Arrange
            var mockRepository = new Mock<IValorMonetarioRepository>();
            mockRepository.Setup(repo => repo.GetAll()).Returns(GetFakeValoresMonetarios());

            var service = new CaixaEletronicoService(mockRepository.Object);
            decimal valorSaque = 3;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.CalcularSaque(valorSaque));
        }

        private List<ValorMonetario> GetFakeValoresMonetarios()
        {
            return new List<ValorMonetario>
            {
                new (){ Id = 1, valor = new Valor(200), TipoMoeda = new TipoMoeda("BRL"), Quantidade = new Quantidade(10) },
                new (){ Id = 2, valor = new Valor(100), TipoMoeda = new TipoMoeda("BRL"), Quantidade = new Quantidade(10) },
                new (){ Id = 3, valor = new Valor(50), TipoMoeda = new TipoMoeda("BRL"), Quantidade = new Quantidade(10) },
                new (){ Id = 4, valor = new Valor(20), TipoMoeda = new TipoMoeda("BRL"), Quantidade = new Quantidade(10) },
                new (){ Id = 5, valor = new Valor(10), TipoMoeda = new TipoMoeda("BRL"), Quantidade = new Quantidade(10) },
                new (){ Id = 6, valor = new Valor(5), TipoMoeda = new TipoMoeda("BRL"), Quantidade = new Quantidade(10) },
                new (){ Id = 7, valor = new Valor(2), TipoMoeda = new TipoMoeda("BRL"), Quantidade = new Quantidade(10) },
            };
        }
    }
}