using System;
using Xunit;
using TaxaJuros.Api.Domain.Services;

namespace CalculoJuros.Tests
{
    public class TaxaJurosTest
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosTest()
        {
            _taxaJurosService = new TaxaJurosService();
        }
        
        [Fact]
        public void taxa_juros_should_be_success()
        {
            double valor = _taxaJurosService.PegarTaxaJuros();
            Assert.Equal(0.01, valor);
        }
        
        [Fact]
        public void taxa_juros_should_be_fail()
        {
            double valor = _taxaJurosService.PegarTaxaJuros();
            Assert.NotEqual(0.02, valor);
        }
    }
}