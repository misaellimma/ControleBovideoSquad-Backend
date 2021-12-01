using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animal;
using ControleBovideoSquad.Domain.Repositories.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services.Animais
{
    public class RegistroVacinaService : IRegistroVacinaService
    {
        private readonly IRegistroVacinaRepository _registroVacinaRepository;
        private readonly IMapper<RegistroVacinaDto, RegistroVacina> _registroMapper;
        private readonly IRebanhoRepository _rebanhoRepository;

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository,
            IMapper<RegistroVacinaDto, RegistroVacina> registroMapper,
            IRebanhoRepository rebanhoRepository
            )
        {
            _registroVacinaRepository = registroVacinaRepository;
            _registroMapper = registroMapper;
            _rebanhoRepository = rebanhoRepository;
        }

        public Result<string> Cancelar(int id)
        {
            RegistroVacina? registroVacina= _registroVacinaRepository.Obter(id);

            if (registroVacina == null)
                return Result<string>.Error(EStatusCode.NOT_FOUND, "");

            registroVacina.Cancelar();
            _registroVacinaRepository.Save(registroVacina);

            return Result<string>.Success("");
        }

        public Result<RegistroVacina> Incluir(RegistroVacinaDto registroVacinaDto)
        {
            var validation = TempRegistroValidation(registroVacinaDto);

            if(validation.Any())
                return Result<RegistroVacina>.Error(EStatusCode.BAD_REQUEST, validation);

            _registroVacinaRepository.Save(_registroMapper.MapearDtoParaEntidade(registroVacinaDto));


            return Result<RegistroVacina>.Success(_registroMapper.MapearDtoParaEntidade(registroVacinaDto));
        }

        public List<RegistroVacina> ObterPorPropriedade(string inscricaoEstadual)
        {
            return _registroVacinaRepository.ObterPorPropriedade(inscricaoEstadual);
        }
        
        public List<string> TempRegistroValidation(RegistroVacinaDto registroVacinaDto)
        {
            List<string> error = new List<string>();

            if(registroVacinaDto.Quantidade <= 0)
            {
                error.Add("Quantidade não pode ser nula!");
            }
            if(registroVacinaDto.IdVacina <= 0)
            {
                error.Add("Vacina não pode ser nula!");
            }
            if (registroVacinaDto.IdRebanho <= 0)
            {
                error.Add("Rebanho não pode ser nulo!");
            }
            
            return error;
        }
    }
}
