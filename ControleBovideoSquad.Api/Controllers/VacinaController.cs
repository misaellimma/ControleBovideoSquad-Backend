using ControleBovideoSquad.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly IVacinaService vacinaService;

        public VacinaController(IVacinaService vacinaService)
        {
            this.vacinaService = vacinaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vacinas = vacinaService.ObterTodos();

            if (vacinas == null)
                return NotFound("Vacinas não localizadas!");

            return Ok(vacinas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var vacina = vacinaService.ObterPorId(id);

            if (vacina == null)
                return NotFound("Vacina não encontrado!");

            return Ok(vacina);
        }
    }
}
