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
        public IActionResult ObterTodos()
        {
            var vendas = _vendaService.ObterTodos();

            if (vendas == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(vendas);
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterPorId(int id)
        {
            var venda = _vendaService.ObterPorId(id);

            if (venda == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(venda);
        }

        [HttpGet("produtor/{cpfComMascara}")]
        public IActionResult ObterPorCpfProdutor(string cpfComMascara)
        {
            var cpf = Formatar.FormatarString(cpfComMascara);
            var venda = _vendaService.ObterPorCpfProdutor(cpf);

            if (venda == null)
                return NotFound("as vendas não foram encontradas");

            return Ok(venda);
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] VendaDto vendaDto)
        {
            var response = _vendaService.Salvar(vendaDto);

            if (response.Errors != null)
                return StatusCode((int) response.StatusCode, response.Errors);

            return Ok(response.Data);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Cancelar(int id)
        {
            var response = _vendaService.Cancelar(id);

            if (response.Errors != null) 
                return StatusCode((int) response.StatusCode, response.Errors);

            return Ok(response.Data);
        }
    }
}
