using ControleBovideoSquad.Application.IServices;
using Microsoft.AspNetCore.Http;
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

            if (produtor == null)
                return NotFound("Produtor não localizado!");

            return Ok(produtor);
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult GetCpf(string cpf)
        {
            if (cpf == null)
                return NotFound("CPF vazio!");

            var produtor = produtorService.ObterProdutorPorCpf(cpf);

            if (produtor.Data == null)
                return NotFound("Não existe o CPF na base de dados!");

            return Ok(produtor);
        }

        [HttpGet("validacpf/{cpf}")]
        public IActionResult ValidaCpf(string cpf)
        {
            if (cpf == null)
                return NotFound("CPF vazio!");

            var produtor = produtorService.ObterProdutorPorCpf(cpf);

            if (produtor.Data != null)
                return NotFound("CPF já cadastrado!");

            return Ok(produtor);
        }
    }
}
