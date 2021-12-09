using ControleBovideoSquad.Application.IServices.Vendas;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalidadeDeVendaController : ControllerBase
    {
        private readonly IFinalidadeDeVendaService _finalidadeDeVendaService;

        public FinalidadeDeVendaController(IFinalidadeDeVendaService finalidadeDeVendaService)
        {
            this._finalidadeDeVendaService = finalidadeDeVendaService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_finalidadeDeVendaService.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            return Ok(_finalidadeDeVendaService.Obter(id));
        }
    }
}
