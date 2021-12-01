using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.Application.IMapper.Animais;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;

namespace ControleBovideoSquad.Application.Mapper.Animais
{
    public class AnimalMapper : IAnimalMapper
    {
        private readonly IEspecieRepository _especieRepository;
        private readonly ITipoDeEntradaRepository _tipoDeEntradaRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;

        // TODO: ajustar os campos de propriedade quando a entidade estiver pronta

        public AnimalMapper(IEspecieRepository especieRepostory, ITipoDeEntradaRepository tipoDeEntradaRepository,
            IPropriedadeRepository propriedadeRepository)
        {
            _especieRepository = especieRepostory;
            _tipoDeEntradaRepository = tipoDeEntradaRepository;
            _propriedadeRepository = propriedadeRepository;
        }

        public Animal MapearDtoParaEntidade(AnimalDto source)
        {
            Especie Especie = _especieRepository.ObterEspeciePorId(source.IdEspecie);
            TipoDeEntrada TipoDeEntrada = _tipoDeEntradaRepository.ObterTipoDeEntradaPorId(source.IdTipoDeEntrada);
            Propriedade Propriedade = _propriedadeRepository.ObterPorId(source.IdPropriedade);
            return new Animal(source.IdAnimal, source.QuantidadeTotal, source.QuantidadeVacinada, Especie,
                Propriedade, TipoDeEntrada, source.DataDeEntrada, source.Ativo);
        }

        public AnimalDto MapearEntidadeParaDto(Animal source)
        {
            return new AnimalDto(source.IdAnimal, source.QuantidadeTotal, source.QuantidadeVacinada,
                source.EspecieAnimal.IdEspecie, source.PropriedadeAnimal.IdPropriedade, 
                source.TipoDeEntradaAnimal.IdTipoDeEntrada,
                source.DataDeEntrada, source.Ativo);
        }
    }
}
