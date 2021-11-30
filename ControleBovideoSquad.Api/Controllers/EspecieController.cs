using ControleBovideoSquad.Application.IServices.Animais;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieService _especieService;

        public EspecieController(IEspecieService especieService)
        {
            this._especieService = especieService;
        }
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_especieService.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var result = _especieService.ObterPorId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
