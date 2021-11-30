using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class RebanhoService : IRebanhoService
    {
        private readonly IRebanhoRepository _rebanhoRepository;

        public RebanhoService(IRebanhoRepository rebanhoRepository)
        {
            _rebanhoRepository = rebanhoRepository; 
        }

        public Rebanho ObterRebanhoPorId(int id)
        {
            return _rebanhoRepository.ObterRebanhosPorId(id);
        }

        public List<Rebanho> ObterRebanhos()
        {
            return _rebanhoRepository.ObterRebanhos();
        }

        public List<Rebanho> ObterRebanhosPorProdutor(string cpf)
        {
            return _rebanhoRepository.ObterRebanhosPorProdutor(cpf);
        }

        public List<Rebanho> ObterRebanhosPorPropriedade(string inscricaoEstadual)
        {
            return _rebanhoRepository.ObterRebanhosPorPropriedade(inscricaoEstadual);
        }
    }
}
