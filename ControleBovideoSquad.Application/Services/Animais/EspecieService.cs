using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class EspecieService : IEspecieService
    {
        private readonly IEspecieRepository _especieRepository;

        public EspecieService(IEspecieRepository especieRepository)
        {
            _especieRepository = especieRepository;
        }

        public Especie ObterPorId(int id)
        {
            return _especieRepository.ObterPorId(id);
        }

        public List<Especie> ObterTodos()
        {
            return _especieRepository.ObterTodos();
        }
    }
}
