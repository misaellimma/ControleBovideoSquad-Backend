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

            if (produtores == null)
                return NotFound("Produtores não localizados!");

            return Ok(produtores);
        }
    }
}
