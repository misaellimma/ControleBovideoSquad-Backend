using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Propriedade;
using ControleBovideoSquad.CrossCutting.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropriedadeController : ControllerBase
    {
        private readonly IPropriedadeService propriedadeService;

        public PropriedadeController(IPropriedadeService propriedadeService)
        {
            this.propriedadeService = propriedadeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var propriedadees = propriedadeService.ObterTodos();

            return Ok(propriedadees);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var propriedade = propriedadeService.ObterPorId(id);

            if (propriedade == null)
                return NotFound("Propriedade não localizado!");

            return Ok(propriedade);
        }

        [HttpGet("inscricao/{inscricao}")]
        public IActionResult GetCpf(string inscricao)
        {
            if (inscricao == null)
                return NotFound("Inscricao Estadual vazia!");

            var propriedade = propriedadeService.ObterPorInscricaoEstadual(inscricao);

            if (propriedade.Data == null)
                return StatusCode((int)propriedade.StatusCode, Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Não existe a Inscricao Estadual na base de dados!"));

            return StatusCode((int)propriedade.StatusCode, propriedade.Data);
        }

        [HttpGet("validainscricao/{inscricao}")]
        public IActionResult ValidaCpf(string inscricao)
        {
            if (inscricao == null)
                return NotFound("Inscricao Estadual vazia!");

            var propriedade = propriedadeService.ObterPorInscricaoEstadual(inscricao);

            if (propriedade.Data != null)
                return StatusCode((int)propriedade.StatusCode, Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Inscricao Estadual já cadastrada!"));

            return StatusCode((int)propriedade.StatusCode, propriedade.Data);
        }
    }
}
