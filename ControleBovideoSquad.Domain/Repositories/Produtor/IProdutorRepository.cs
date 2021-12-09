using ControleBovideoSquad.Domain.Entities.Produtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Produtores
{
    public interface IProdutorRepository
    {
        List<Produtor> ObterTodos();
        Produtor ObterProdutorPorCpf(string cpf);
        Produtor ObterProdutorPorId(int id);
        void Salvar(Produtor produtor);
    }
}
