using ControleBovideoSquad.Application.IServices.Animais;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/tipodeentrada")]
    [ApiController]
    public class TipoDeEntradaController : ControllerBase
    {
        private readonly ITipoDeEntradaService _tipoDeEntradaService;

        public TipoDeEntradaController(ITipoDeEntradaService tipoDeEntradaService)
        {
            this._tipoDeEntradaService = tipoDeEntradaService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_tipoDeEntradaService.ObterTodos());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult ObterPorId(int id)
        {
            var tipoDeEntrada = _tipoDeEntradaService.ObterPorId(id);

            if (tipoDeEntrada == null)
                return NotFound();

            return Ok(tipoDeEntrada);
        }
    }
}
