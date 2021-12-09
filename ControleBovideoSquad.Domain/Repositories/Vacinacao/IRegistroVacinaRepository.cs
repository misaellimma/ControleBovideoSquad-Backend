using ControleBovideoSquad.Domain.Entities.Vacinacao;

namespace ControleBovideoSquad.Domain.Repositories.Vacinacao
{
    public interface IRegistroVacinaRepository
    {
        void Save(RegistroVacina registroVacina);
        RegistroVacina? Obter(int id);
        List<RegistroVacina> ObterPorPropriedade(string inscricaoEstadual);        
    }
}
