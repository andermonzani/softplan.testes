using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxaJuros.Api.Domain.Services;

namespace TaxaJuros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }
        
        // GET api/taxajuros
        [HttpGet]
        public ActionResult<double> Get()
        {
            return _taxaJurosService.PegarTaxaJuros();
        }
    }
}