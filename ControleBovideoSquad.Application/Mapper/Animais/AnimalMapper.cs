using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.AnimaisDto;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Repositories.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Mapper.Animais
{
    public class AnimalMapper : IMapper<AnimalDto, Animal>
    {
        private readonly IEspecieRepository _especieRepository;
        private readonly ITipoDeEntradaRepository _tipoDeEntradaRepository;

        // TODO: ajustar os campos de propriedade quando a entidade estiver pronta

        public AnimalMapper(IEspecieRepository especieRepostory, ITipoDeEntradaRepository tipoDeEntradaRepository)
        {
            _especieRepository = especieRepostory;
            _tipoDeEntradaRepository = tipoDeEntradaRepository;
        }

        public Animal MapearDtoParaEntidade(AnimalDto source)
        {
            Especie Especie = _especieRepository.ObterEspeciePorId(source.IdEspecie);
            TipoDeEntrada TipoDeEntrada = _tipoDeEntradaRepository.ObterTipoDeEntradaPorId(source.IdTipoDeEntrada);
            return new Animal(source.IdAnimal, source.QuantidadeTotal, source.QuantidadeVacinada, Especie,
                new Propriedade(), TipoDeEntrada, source.DataDeEntrada, source.Ativo);
        }

        public AnimalDto MapearEntidadeParaDto(Animal source)
        {
            return new AnimalDto(source.IdAnimal, source.QuantidadeTotal, source.QuantidadeVacinada,
                source.EspecieAnimal.IdEspecie, 1, source.TipoDeEntradaAnimal.IdTipoDeEntrada,
                source.DataDeEntrada, source.Ativo);
        }
    }
}
