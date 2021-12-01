using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.CrossCutting.Util;
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

            return StatusCode((int)produtor.StatusCode, produtor.Data);
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult GetCpf(string cpf)
        {
            var produtor = produtorService.ObterProdutorPorCpf(cpf);

            if (produtor.Data == null)
                return StatusCode((int)produtor.StatusCode, Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "Não existe o CPF na base de dados!"));

            return StatusCode((int)produtor.StatusCode, produtor.Data);
        }

        [HttpGet("validacpf/{cpf}")]
        public IActionResult ValidaCpf(string cpf)
        {
            var produtor = produtorService.ObterProdutorPorCpf(cpf);

            if (produtor.Data != null)
                return StatusCode((int)produtor.StatusCode, Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF já cadastrado!"));

            return StatusCode((int)produtor.StatusCode, produtor.Data);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutorDto produtorDto)
        {
            if(produtorDto == null)
                return StatusCode((int)EStatusCode.NOT_FOUND, Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "Produtor não pode ser vazio!"));

            var produtor = produtorService.CriarProdutor(produtorDto);
            if(produtor.Errors != null)
                return StatusCode((int)EStatusCode.NOT_FOUND, produtor.Errors);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] ProdutorDto produtorDto)
        {
            if (produtorDto == null)
                return StatusCode((int)EStatusCode.NOT_FOUND, Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "Produtor não pode ser vazio!"));

            var produtor = produtorService.AlterarProdutor(id, produtorDto);

            if (produtor.Errors != null)
                return StatusCode((int)EStatusCode.NOT_FOUND, produtor.Errors);

            return Ok();
        }
    }
}
