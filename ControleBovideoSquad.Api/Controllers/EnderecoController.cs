using ControleBovideoSquad.Application.IServices.Enderecos;
using ControleBovideoSquad.CrossCutting.Dto.EnderecoDto;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleBovideoSquad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            this._enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_enderecoService.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            return Ok(_enderecoService.Obter(id));
        }

        [HttpPost]
        public IActionResult IncluirEndereco([FromBody]EnderecoDto Endereco)
        {
            var result =  _enderecoService.Save(Endereco);

            if(result.Errors != null)
            {
                return StatusCode((int)result.StatusCode,result.Errors);
            }

            return StatusCode((int)result.StatusCode, result.Data);
        }
    }
}
