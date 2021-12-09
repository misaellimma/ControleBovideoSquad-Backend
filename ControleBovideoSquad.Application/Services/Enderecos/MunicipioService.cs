using ControleBovideoSquad.Application.IServices.Enderecos;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Enderecos;

namespace ControleBovideoSquad.Application.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository municipioRepository;

        public MunicipioService(IMunicipioRepository municipioRepository)
        {
            this.municipioRepository = municipioRepository;
        }

        public Municipio ObterPorId(int id)
        {
            return municipioRepository.ObterPorId(id);
        }

        public List<Municipio> ObterTodos()
        {
            return municipioRepository.ObterTodos();
        }
    }
}
