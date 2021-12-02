using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Application.Validators.RegistroVacina;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Animais;
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
        private readonly IRegistroVacinaValidator _registroVacinaValidator;

        public RegistroVacinaService(IRegistroVacinaRepository registroVacinaRepository,
            IMapper<RegistroVacinaDto, RegistroVacina> registroMapper,
            IRebanhoRepository rebanhoRepository,
            IRegistroVacinaValidator registroVacinaValidator
            )
        {
            _registroVacinaRepository = registroVacinaRepository;
            _registroMapper = registroMapper;
            _rebanhoRepository = rebanhoRepository;
            _registroVacinaValidator = registroVacinaValidator;
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
            Rebanho rebanho = _rebanhoRepository.ObterRebanhosPorId(registroVacinaDto.IdRebanho);

            _registroVacinaValidator.IsValid(registroVacinaDto);
            _registroVacinaValidator.VerificarQuantidade(registroVacinaDto,rebanho);

            var validation = _registroVacinaValidator.errors;

            if (validation.Any())
                return Result<RegistroVacina>.Error(EStatusCode.BAD_REQUEST, validation);


            rebanho.AdicionarNoRebanho(0,registroVacinaDto.Quantidade);

            _rebanhoRepository.Save(rebanho);
            _registroVacinaRepository.Save(_registroMapper.MapearDtoParaEntidade(registroVacinaDto));          

            return Result<RegistroVacina>.Success(_registroMapper.MapearDtoParaEntidade(registroVacinaDto));
        }

        public List<RegistroVacina> ObterPorPropriedade(string inscricaoEstadual)
        {
            return _registroVacinaRepository.ObterPorPropriedade(inscricaoEstadual);
        }             
    }
}
