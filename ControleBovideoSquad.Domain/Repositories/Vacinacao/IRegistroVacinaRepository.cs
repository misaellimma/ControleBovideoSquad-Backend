using ControleBovideoSquad.Domain.Entities.Vacinacao;

namespace ControleBovideoSquad.Domain.Repositories.Vacinacao
{
    public interface IRegistroVacinaRepository
    {
        void Salvar(RegistroVacina registroVacina);
        RegistroVacina? ObterPorId(int id);
        List<RegistroVacina> ObterPorInscricaoPropriedade(string inscricaoEstadual);
    }
}
