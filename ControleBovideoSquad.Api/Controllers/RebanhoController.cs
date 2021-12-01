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
        public IActionResult Get()
        {
            var rebanhos = _rebanhoService.ObterRebanhos();

            if (rebanhos == null)
                return NotFound("Animais não encontrados");

            return Ok(rebanhos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var rebanho = _rebanhoService.ObterRebanhoPorId(id);

            if (rebanho == null)
                return NotFound("animais não encontrados");

            return Ok(rebanho);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RebanhoDto rebanhoDto)
        {
            var response = this._rebanhoService.SalvarRebanho(rebanhoDto);

            if (response.StatusCode == 400)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }
    }
}