using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;

namespace ControleBovideoSquad.Application.Mapper.Animais
{
    public class RebanhoMapper : IMapper<RebanhoDto, Rebanho>
    {
        private readonly IEspecieRepository _especieRepository;

        public RebanhoMapper(IEspecieRepository especieRepository)
        {
            _especieRepository = especieRepository;
        }

        public Rebanho MapearDtoParaEntidade(RebanhoDto source)
        {
            Especie Especie = _especieRepository.ObterEspeciePorId(source.IdEspecie);
            return new Rebanho(source.IdRebanho, source.QuantidadeTotal, source.QuantidadeVacinadaAftosa, 
                source.QuantidadeVacinadaBrucelose, Especie, new Propriedade());
        }

        public RebanhoDto MapearEntidadeParaDto(Rebanho source)
        {
            return new RebanhoDto(source.IdRebanho, source.QuantidadeTotal, source.QuantidadeVacinadaAftosa,
                source.QuantidadeVacinadaBrucelose, source.Especie.IdEspecie, 1);
        }
    }
}
