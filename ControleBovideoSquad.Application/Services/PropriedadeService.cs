using ControleBovideoSquad.Application.IMapper.Propriedades;
using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Application.Mapper.Propriedades;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Propriedade;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Repositories.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Propriedades;

namespace ControleBovideoSquad.Application.Services
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

        public Result<PropriedadeDto> Alterar(int id, PropriedadeDto propriedadeDto)
        {
            if (propriedadeDto.IdPropriedade != id)
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Id da Url está divergente do body!");

            propriedadeDto.InscricaoEstadual = Formatar.FormatarString(propriedadeDto.InscricaoEstadual);
            propriedadeRepository.CriarOuAlterar(propriedadeMapper.MapearDtoParaEntidade(propriedadeDto));
            return Result<PropriedadeDto>.Success(propriedadeDto);
        }

        public Result<PropriedadeDto> Criar(PropriedadeDto propriedadeDto)
        {
            if (!Validacao.ValidarInscricaoEstadual(propriedadeDto.InscricaoEstadual))
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Inscricao Estadual invalido!");

            propriedadeDto.InscricaoEstadual = Formatar.FormatarString(propriedadeDto.InscricaoEstadual);

            var produtor = propriedadeMapper.MapearDtoParaEntidade(propriedadeDto);
            propriedadeRepository.CriarOuAlterar(produtor);

            return Result<PropriedadeDto>.Success(propriedadeDto);
        }

        public Result<PropriedadeDto> ObterPorId(int id)
        {
            var propriedade = propriedadeRepository.ObterPorId(id);

            if(propriedade == null)
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Produtor não localizado!");
            else
                return Result<PropriedadeDto>.Success(propriedadeMapper.MapearEntidadeParaDto(propriedade));
        }

        public Result<PropriedadeDto> ObterPorInscricaoEstadual(string InscricaoEstadual)
        {
            if (!Validacao.ValidarInscricaoEstadual(InscricaoEstadual))
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Inscrição Estadual inválida!");

            var propriedade = propriedadeRepository.ObterPorInscricaoEstadual(InscricaoEstadual);
            
            if (propriedade == null)
                return Result<PropriedadeDto>.Error(EStatusCode.NOT_FOUND, "Produtor não localizado!");
            else
                return Result<PropriedadeDto>.Success(propriedadeMapper.MapearEntidadeParaDto(propriedade));
        }

        public List<PropriedadeDto> ObterTodos()
        {
            var propriedades = propriedadeRepository.ObterTodos();
            return propriedadeMapper.MapearEntidadeParaDto(propriedades);
        }
    }
}
