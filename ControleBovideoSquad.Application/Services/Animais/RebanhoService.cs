using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Application.Mapper.Animais;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class RebanhoService : IRebanhoService
    {
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly RebanhoMapper _rebanhoMapper;

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

        public void SalvarRebanho(RebanhoDto rebanhoDto)
        {
            Rebanho rebanho = this._rebanhoMapper.MapearDtoParaEntidade(rebanhoDto);
            this._rebanhoRepository.Save(rebanho);
        }
    }
}
