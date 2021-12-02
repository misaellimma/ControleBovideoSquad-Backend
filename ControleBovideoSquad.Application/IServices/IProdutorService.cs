using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Produtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices
{
    public interface IProdutorService
    {
        List<ProdutorDto> ObterTodos();
        Result<ProdutorDto> ObterProdutorPorCpf(string cpf);
        Result<ProdutorDto> ObterProdutorPorId(int id);
        Result<ProdutorDto> CriarProdutor(ProdutorDto produtor);
        Result<ProdutorDto> AlterarProdutor(int id, ProdutorDto produtor);
    }
}
