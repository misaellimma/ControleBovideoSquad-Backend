using ControleBovideoSquad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Propriedades
{
    public interface IPropriedadeRepository
    {
        List<Propriedade> ObterTodos();
        List<Propriedade> ObterPorIdProdutor(int id);
        Propriedade ObterPorInscricaoEstadual(string InscricaoEstadual);
        Propriedade ObterPorId(int id);
        void Salvar(Propriedade produtor);
    }
}
