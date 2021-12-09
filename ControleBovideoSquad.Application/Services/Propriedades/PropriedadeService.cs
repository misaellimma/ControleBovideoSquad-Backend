using ControleBovideoSquad.Application.IMapper.Propriedades;
using ControleBovideoSquad.Application.IServices.Propriedades;
using ControleBovideoSquad.CrossCutting.Dto.Propriedades;
using ControleBovideoSquad.CrossCutting.Enums;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Repositories.Propriedades;

namespace ControleBovideoSquad.Application.Services.Propriedades
{

    public class PropriedadeService : IPropriedadeService
    {
        private readonly IPropriedadeRepository propriedadeRepository;
        private readonly IPropriedadeMapper propriedadeMapper;

        public PropriedadeService(IPropriedadeRepository propriedadeRepository, IPropriedadeMapper propriedadeMapper)
        {
            this.propriedadeRepository = propriedadeRepository;
            this.propriedadeMapper = propriedadeMapper;
        }

        public Result<bool> Alterar(PropriedadeDto propriedadeDto)
        {
            var propriedadeDB = propriedadeRepository.ObterPorId(propriedadeDto.IdPropriedade);
            propriedadeDto.InscricaoEstadual = Formatar.FormatarString(propriedadeDto.InscricaoEstadual);
            propriedadeDB.AlterarPropriedade(propriedadeDto);
            propriedadeRepository.Salvar(propriedadeDB);
            return Result<bool>.Success(true);
        }

        public Result<PropriedadeDto> Incluir(PropriedadeDto propriedadeDto)
        {
            if (!Validacao.ValidarInscricaoEstadual(propriedadeDto.InscricaoEstadual))
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Inscricao Estadual invalida!");

            propriedadeDto.InscricaoEstadual = Formatar.FormatarString(propriedadeDto.InscricaoEstadual);
            var propriedadeInscricao = propriedadeRepository.ObterPorInscricaoEstadual(propriedadeDto.InscricaoEstadual);

            if (propriedadeInscricao != null)
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Inscricao Estadual já cadastrada!");

            var propriedade = propriedadeMapper.MapearDtoParaEntidade(propriedadeDto);
            propriedadeRepository.Salvar(propriedade);

            return Result<PropriedadeDto>.Success(propriedadeDto);
        }

        public Result<PropriedadeDto> ObterPorId(int id)
        {
            var propriedade = propriedadeRepository.ObterPorId(id);

            if (propriedade == null)
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Propriedade não localizada!");
            else
                return Result<PropriedadeDto>.Success(propriedadeMapper.MapearEntidadeParaDto(propriedade));
        }

        public Result<PropriedadeDto> ObterPorInscricaoEstadual(string InscricaoEstadual)
        {
            if (!Validacao.ValidarInscricaoEstadual(InscricaoEstadual))
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Inscrição Estadual inválida!");

            var propriedade = propriedadeRepository.ObterPorInscricaoEstadual(InscricaoEstadual);

            if (propriedade == null)
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Propriedade não localizada!");
            else
                return Result<PropriedadeDto>.Success(propriedadeMapper.MapearEntidadeParaDto(propriedade));
        }

        public Result<bool> ValidaPorInscricaoEstadual(string InscricaoEstadual)
        {
            if (!Validacao.ValidarInscricaoEstadual(InscricaoEstadual))
                return Result<bool>.Error(EStatusCode.NOT_FOUND, "Inscrição Estadual inválida!");

            if (propriedadeRepository.ValidaPorInscricaoEstadual(InscricaoEstadual))
                return Result<bool>.Error(EStatusCode.NOT_FOUND, "Inscricao Estadual já cadastrada!");
            else
                return Result<bool>.Success(true);
        }

        public List<PropriedadeDto> ObterPorIdProdutor(int Id)
        {
            var result = propriedadeMapper.MapearEntidadeParaDto(propriedadeRepository.ObterPorIdProdutor(Id));

            return result;

        }

        public List<PropriedadeDto> ObterTodos()
        {
            var propriedades = propriedadeRepository.ObterTodos();
            return propriedadeMapper.MapearEntidadeParaDto(propriedades);
        }
    }
}
