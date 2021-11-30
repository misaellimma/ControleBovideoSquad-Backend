using ControleBovideoSquad.Application.IServices.Animais;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Get()
        {
            var tiposDeEntrada = this._tipoDeEntradaService.ObterTodos();
            
            if (tiposDeEntrada == null)
                return NotFound();

            return Ok(tiposDeEntrada);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var tipoDeEntrada = this._tipoDeEntradaService.ObterPorId(id);

            if (tipoDeEntrada == null)
                return NotFound();

            return Ok(tipoDeEntrada);
        }
    }
}
