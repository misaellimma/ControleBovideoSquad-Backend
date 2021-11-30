using ControleBovideoSquad.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService; 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var animais = _animalService.ObterTodos();

            if (animais == null)
                return NotFound("Animais não encontrados");

            return Ok(animais);
        }
    }
}
