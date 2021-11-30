using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.Domain.Entities.Animal;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Mapper.RegistroVacinas
{
    public class RegistroVacinaMapper : IMapper<RegistroVacinaDto, RegistroVacina>
    {
        private readonly IVacinaRepository _vacinaRepository;
        private readonly IRebanhoRepository _rebanhoRepository;

        public RegistroVacinaMapper(IVacinaRepository vacinaRepository, IRebanhoRepository rebanhoRepository)
        {
            _vacinaRepository = vacinaRepository;
            _rebanhoRepository = rebanhoRepository;
        }

        public RegistroVacina MapearDtoParaEntidade(RegistroVacinaDto registroVacinaDto)
        {
            var vacina = _vacinaRepository.ObterPorId(registroVacinaDto.IdVacina);
            var rebanho = _rebanhoRepository.ObterRebanhosPorId(registroVacinaDto.IdRebanho);
            return new RegistroVacina(registroVacinaDto.IdRegistroVacina, registroVacinaDto.Quantidade, registroVacinaDto.DataDaVacina, vacina,rebanho);
        }

        public RegistroVacinaDto MapearEntidadeParaDto(RegistroVacina registroVacina)
        {
            return new RegistroVacinaDto(registroVacina.IdRegistroVacina,registroVacina.Quantidade, registroVacina.Vacina.IdVacina, 0 , registroVacina.DataDaVacina);
        }
    }
}
