using ControleBovideoSquad.Domain.Entities.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Domain.Repositories.Animais
{
    public interface IRegistroVacinaRepository
    {
        void Save(RegistroVacina registroVacina);
        RegistroVacina? Obter(int id);
        List<RegistroVacina> ObterPorPropriedade(string inscricaoEstadual);        
    }
}
