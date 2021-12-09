using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/rebanho")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {
        private readonly IRebanhoService _rebanhoService;

        public RebanhoController(IRebanhoService rebanhoService)
        {
            _rebanhoService = rebanhoService; 
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var rebanhos = _rebanhoService.ObterTodos();

            if (rebanhos == null)
                return NotFound("Animais não encontrados");

            return Ok(rebanhos);
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var rebanho = _rebanhoService.ObterPorId(id);

            if (rebanho == null)
                return NotFound("animais não encontrados");

            return Ok(rebanho);
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] RebanhoDto rebanhoDto)
        {
            var response = this._rebanhoService.Salvar(rebanhoDto);

            if (response.Errors != null)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }

        [HttpGet("{inscricaoEstadual}/Propriedade")]
        public IActionResult ObterPorInscricaoPropriedade(string inscricaoEstadual)
        {
            var response = this._rebanhoService.ObterPorInscricaoPropriedade(inscricaoEstadual);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpGet("{cpf}/Produtor")]
        public IActionResult ObterPorCpfProdutor(string cpf)
        {
            var response = this._rebanhoService.ObterPorCpfProdutor(cpf);

            if(response == null) return NotFound();

            return Ok(response);
        }
    }
}
