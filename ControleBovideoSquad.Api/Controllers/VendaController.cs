using ControleBovideoSquad.Application.IServices.Vendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vendas = _vendaService.ObterVendas();

            if (vendas == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(vendas);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var venda = _vendaService.ObterVendaPorId(id);

            if (venda == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(venda);
        }

        [HttpGet]
        [Route("produtor/{cpf}")]
        public IActionResult GetByProdutor(string cpf)
        {
            var venda = _vendaService.ObterVendaPorProdutor(cpf);

            if (venda == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(venda);
        }
    }
}
