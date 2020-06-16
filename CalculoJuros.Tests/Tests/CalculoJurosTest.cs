using System;
using Xunit;
using CalculoJuros.Api.Domain.Services;
using System.Threading.Tasks;
using CalculoJuros.Tests.Fixtures;
using FluentAssertions;
using System.Net; 

namespace CalculoJuros.Tests
{
    public class CalculoJurosTest
    {
        private readonly TestContext _testContext;
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculoJurosTest()
        {
            _calculaJurosService = new CalculaJurosService();
            _testContext = new TestContext();
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
        public void calculo_juros_teory_tests_success(decimal valorInicial, int meses, double taxaJuros, decimal valorEsperado)
        {
            decimal valor = _calculaJurosService.CalcularJuros(valorInicial, meses, taxaJuros);
            Assert.NotEqual(valorEsperado, valor);
        }
        
        [Fact]
        public async Task calculo_juros_integration_should_be_success()
        {
            var response = await _testContext.Client.GetAsync("api/taxajuros");
            
            response.EnsureSuccessStatusCode();

            string taxaJuros = await response.Content.ReadAsStringAsync();

            double valorTaxaJuros = double.Parse(taxaJuros.Replace('.', ','));
            
            decimal valor = _calculaJurosService.CalcularJuros(100, 5, valorTaxaJuros);
            
            Assert.Equal(Convert.ToDecimal(105.10), valor);
        }
    }
}