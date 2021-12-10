using ControleBovideoSquad.Application.IServices.Vacinacao;
using ControleBovideoSquad.CrossCutting.Dto.Vacinacao;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroVacinaController : ControllerBase
    {
        private readonly IRegistroVacinaService _registroVacinaService;

        public RegistroVacinaController(IRegistroVacinaService registroVacinaService)
        {
            this._registroVacinaService = registroVacinaService;
        }

        [HttpDelete("{id}")]
        public IActionResult Cancelar(int id)
        {
            var response = _registroVacinaService.Cancelar(id);

            if (response.Errors != null)
                return StatusCode((int)response.StatusCode, response.Errors);

            return Ok();
        }

        [HttpPost]
        public IActionResult Salvar(RegistroVacinaDto registroVacina)
        {
            var response = _registroVacinaService.Salvar(registroVacina);

            if (response.Errors != null)
                return StatusCode((int)response.StatusCode, response.Errors);

            return StatusCode((int)response.StatusCode, response.Errors);
        }

        [HttpGet("{inscricaoEstadual}")]
        public IActionResult ObterPorInscricaoPropriedade(string inscricaoEstadual)
        {
            var result = _registroVacinaService.ObterPorInscricaoPropriedade(inscricaoEstadual);

            if (result.Errors != null)
                return StatusCode((int)result.StatusCode, result.Errors);

            return StatusCode((int)result.StatusCode, result.Data);
        }
    }
}
