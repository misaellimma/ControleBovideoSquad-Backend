using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Application.Mapper.Animais;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto.cs;
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

        public RebanhoDto ObterRebanhoPorId(int id)
        {
            var rebanho = _rebanhoRepository.ObterRebanhosPorId(id);
            return _rebanhoMapper.MapearEntidadeParaDto(rebanho);
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
