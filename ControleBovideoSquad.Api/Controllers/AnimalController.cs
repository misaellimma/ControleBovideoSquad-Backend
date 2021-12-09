using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
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
        public IActionResult ObterTodos()
        {
            var animais = _animalService.ObterTodos();

            if (animais == null)
                return NotFound("Animais não encontrados");

            return Ok(animais);
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var animal = _animalService.ObterPorId(id);

            if (animal == null)
                return NotFound("animal não encontrado");

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] AnimalDto animalDto)
        {
            var response = this._animalService.Salvar(animalDto);

            if (response.Errors != null)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public IActionResult Cancelar(int id)
        {
            var response = _animalService.Cancelar(id);
            return Ok(response);
        }
    }
}
