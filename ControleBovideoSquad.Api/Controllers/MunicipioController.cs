using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Domain.Entities.Municipios;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioService municipioService;

        public MunicipioController(IMunicipioService municipioService)
        {
            this.municipioService = municipioService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var municipios = municipioService.ObterTodos();

            return Ok(municipios);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorID(int id)
        {
            var municipio = municipioService.ObterPorId(id);

            if(municipio == null)
                return NotFound("Município não encontrado!");
            
            return Ok(municipio);
        }
    }
}
