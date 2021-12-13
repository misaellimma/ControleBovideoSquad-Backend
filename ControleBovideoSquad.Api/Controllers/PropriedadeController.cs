using ControleBovideoSquad.Application.IServices.Propriedades;
using ControleBovideoSquad.CrossCutting.Dto.Propriedades;
using ControleBovideoSquad.CrossCutting.Enums;
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
            var propriedade = propriedadeService.ObterPorInscricaoEstadual(inscricao);

            return StatusCode(
                (int)propriedade.StatusCode,
                propriedade.Data != null ? propriedade.Data : propriedade.Errors
                );
        }

        [HttpGet("Produtor/{id}")]
        public IActionResult ObterPorIdProdutor(int id)
        {
            var result = propriedadeService.ObterPorIdProdutor(id);
            if (!result.Any()) return NotFound();

            return Ok(result);
        }


        [HttpGet("validainscricao/{inscricao}")]
        public IActionResult ValidaCpf(string inscricao)
        {
            var propriedade = propriedadeService.ValidaPorInscricaoEstadual(inscricao);

            return StatusCode(
                (int)propriedade.StatusCode,
                propriedade.Errors != null ? propriedade.Errors : propriedade.Data
                );
        }

        [HttpPost]
        public ActionResult Post([FromBody] PropriedadeDto propriedadeDto)
        {
            var produtor = propriedadeService.Incluir(propriedadeDto);

            if (produtor.Errors != null)
                return StatusCode((int)EStatusCode.NOT_FOUND, produtor.Errors);

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] PropriedadeDto propriedadeDto)
        {
            var produtor = propriedadeService.Alterar(propriedadeDto);

            if (produtor.Errors != null)
                return StatusCode((int)EStatusCode.NOT_FOUND, produtor.Errors);

            return Ok();
        }
    }
}
