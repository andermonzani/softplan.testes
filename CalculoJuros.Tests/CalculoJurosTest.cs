using System;
using System.ComponentModel;
using Xunit;
using CalculoJuros.Api.Domain.Services;

namespace CalculoJuros.Tests
{
    public class CalculoJurosTest
    {
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculoJurosTest()
        {
            _calculaJurosService = new CalculaJurosService();
        }
        
        [Fact]
        public void calculo_juros_should_be_success()
        {
            decimal valor = _calculaJurosService.CalcularJuros(100, 5, 0.01);
            Assert.Equal(Convert.ToDecimal(105.10), valor);
        }
        
        [Fact]
        public void calculo_juros_should_be_fail()
        {
            decimal valor = _calculaJurosService.CalcularJuros(100, 5, 0.01);
            Assert.NotEqual(Convert.ToDecimal(105.00), valor);
        }
        
        [Theory]
        [InlineData(10000, 12, 0.05, 1060.08)]
        [InlineData(30000, 24, 4, 76898.92)]
        [InlineData(5000, 36, 1.99, 10163.14)]
        public void calculo_juros_tests(decimal valorInicial, int meses, double taxaJuros, decimal valorEsperado)
        {
            decimal valor = _calculaJurosService.CalcularJuros(valorInicial, meses, taxaJuros);
            Assert.NotEqual(valorEsperado, valor);
        }
    }
}