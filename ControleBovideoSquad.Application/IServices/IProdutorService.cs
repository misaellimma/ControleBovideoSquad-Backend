using ControleBovideoSquad.CrossCutting.Dto.Produtor;
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
        Produtor ObterProdutorPorCpf(string cpf);
        Produtor ObterProdutorPorId(int id);
        void CriarProdutor(Produtor produtor);
        void AlterarProdutor(Produtor produtor);
    }
}
