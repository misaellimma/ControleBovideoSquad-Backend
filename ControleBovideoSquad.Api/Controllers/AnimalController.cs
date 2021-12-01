using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;
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
        public IActionResult Get()
        {
            var animais = _animalService.ObterTodos();

            if (animais == null)
                return NotFound("Animais não encontrados");

            return Ok(animais);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var animal = _animalService.ObterPorId(id);

            if (animal == null)
                return NotFound("animal não encontrado");

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnimalDto animalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = this._animalService.SalvarAnimal(animalDto);

            if (response.StatusCode == 400)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }
    }
}
