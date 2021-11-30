using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animal;
using Microsoft.AspNetCore.Http;
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

        [HttpDelete]
        public IActionResult Cancelar(int id)
        {
            var response = _registroVacinaService.Cancelar(id);
            if (response.Errors.Any()) 
                return BadRequest(response.Errors);

            return Ok();
        }
        [HttpPost]
        public IActionResult Incluir(RegistroVacinaDto registroVacina)
        {
            var response = _registroVacinaService.Incluir(registroVacina);

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok();
        }
        [HttpGet("{inscricaoEstadual}")]
        public IActionResult ObterPorPropriedade(string inscricaoEstadual)
        {
            return Ok(_registroVacinaService.ObterPorPropriedade(inscricaoEstadual));
        }
    }
}
