using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.CrossCutting.Util;
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

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var venda = _vendaService.ObterVendaPorId(id);

            if (venda == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(venda);
        }

        [HttpGet("produtor/{cpfComMascara}")]
        public IActionResult GetByProdutor(string cpfComMascara)
        {
            var cpf = Formatar.FormatarString(cpfComMascara);
            var venda = _vendaService.ObterVendaPorProdutor(cpf);

            if (venda == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(venda);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VendaDto vendaDto)
        {
            var response = _vendaService.SalvarVenda(vendaDto);

            if (response.Errors != null)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Cancel(int id)
        {
            var response = _vendaService.CancelarVenda(id);
            return Ok(response);
        }
    }
}
