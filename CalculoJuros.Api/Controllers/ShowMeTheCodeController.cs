using CalculoJuros.Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController: ControllerBase
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;

        public ShowMeTheCodeController(IShowMeTheCodeService showMeTheCodeService)
        {
            _showMeTheCodeService = showMeTheCodeService;
        }
        
        // GET api/showmethecode
        [HttpGet]
        public ActionResult<string> Get()
        {
            return _showMeTheCodeService.PegarUrl();
        }
    }
}