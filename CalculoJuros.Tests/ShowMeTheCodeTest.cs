using System;
using Xunit;
using CalculoJuros.Api.Domain.Services;

namespace CalculoJuros.Tests
{
    public class ShowMeTheCodeTest
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;

        public ShowMeTheCodeTest()
        {
            _showMeTheCodeService = new ShowMeTheCodeService();
        }
        
        [Fact]
        public void show_me_the_code_should_be_success()
        {
            string valor = _showMeTheCodeService.PegarUrl();
            Assert.Equal("https://github.com/andermonzani/softplan.testes", valor);
        }
        
        [Fact]
        public void show_me_the_code_should_be_fail()
        {
            string valor = _showMeTheCodeService.PegarUrl();
            Assert.NotEqual("https://github.com/andermonzani/softplan.testes1", valor);
        }
    }
}