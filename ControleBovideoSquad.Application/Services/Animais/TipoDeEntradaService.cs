using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class TipoDeEntradaService : ITipoDeEntradaService
    {
        private readonly ITipoDeEntradaRepository _tipoDeEntradaRepository;

        public TipoDeEntradaService(ITipoDeEntradaRepository tipoDeEntradaRepository)
        {
            this._tipoDeEntradaRepository = tipoDeEntradaRepository;
        }

        public List<TipoDeEntrada> ObterTodos()
        {
            var tiposDeEntrada = this._tipoDeEntradaRepository.ObterTipos();
            return tiposDeEntrada;
        }

        public TipoDeEntrada ObterPorId(int id)
        {
            var tipoDeEntrada = this._tipoDeEntradaRepository.ObterTipoDeEntradaPorId(id);
            return tipoDeEntrada;
        }
    }
}
