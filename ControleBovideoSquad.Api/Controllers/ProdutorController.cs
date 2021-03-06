using ControleBovideoSquad.Application.IServices.Produtores;
using ControleBovideoSquad.CrossCutting.Dto.Produtores;
using ControleBovideoSquad.CrossCutting.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutorController : ControllerBase
    {
        private readonly IProdutorService produtorService;

        public ProdutorController(IProdutorService produtorService)
        {
            this.produtorService = produtorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtores = produtorService.ObterTodos();

            return Ok(produtores);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var produtor = produtorService.ObterProdutorPorId(id);

            return StatusCode(
                (int)produtor.StatusCode,
                produtor.Data != null ? produtor.Data : produtor.Errors
                );
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult GetCpf(string cpf)
        {
            var produtor = produtorService.ObterProdutorPorCpf(cpf);

            return StatusCode(
                (int)produtor.StatusCode,
                produtor.Data != null ? produtor.Data : produtor.Errors
                );
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutorDto produtorDto)
        {
            var produtor = produtorService.Incluir(produtorDto);

            if (produtor.Errors != null) return StatusCode((int)EStatusCode.NOT_FOUND, produtor.Errors);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody] ProdutorDto produtorDto)
        {
            var produtor = produtorService.Alterar(produtorDto);

            if (produtor.Errors != null)
                return StatusCode((int)EStatusCode.NOT_FOUND, produtor.Errors);

            return Ok();
        }
    }
}
