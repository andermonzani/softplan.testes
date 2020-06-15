using CalculoJuros.Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculoJuros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _calculaJurosService;
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService, ITaxaJurosService taxaJurosService)
        {
            _calculaJurosService = calculaJurosService;
            _taxaJurosService = taxaJurosService;
        }
        
        // GET api/calculajuros
        [HttpGet]
        public async Task<ActionResult<decimal>> CalcularJuros([FromQuery(Name= "valorInicial")] decimal valorInicial, [FromQuery(Name= "meses")] int meses)
        {
            var taxaJuros = await _taxaJurosService.PegarTaxaJuros();
            var valorJuros = _calculaJurosService.CalcularJuros(valorInicial, meses, taxaJuros);

            return valorJuros; 
        }
    }
}