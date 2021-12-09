using ControleBovideoSquad.Application.IServices.Vacinacao;
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
        public IActionResult ObterTodos()
        {
            var vacinas = vacinaService.ObterTodos();

            return Ok(vacinas);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorID(int id)
        {
            var vacina = vacinaService.ObterPorId(id);

            if (vacina == null)
                return NotFound("Vacina não encontrada!");

            return Ok(vacina);
        }
    }
}
