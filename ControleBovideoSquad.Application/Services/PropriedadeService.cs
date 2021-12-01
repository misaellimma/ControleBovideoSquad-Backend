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
        private readonly IEnderecoRepository enderecoRepository;
        private readonly IPropriedadeMapper propriedadeMapper;

        public PropriedadeService(IPropriedadeRepository propriedadeRepository/*, IEnderecoRepository enderecoRepository*/, IPropriedadeMapper propriedadeMapper)
        {
            this.propriedadeRepository = propriedadeRepository;
            //this.enderecoRepository = enderecoRepository;
            this.propriedadeMapper = propriedadeMapper;
        }

        public void Alterar(Propriedade produtor)
        {
            throw new NotImplementedException();
        }

        public void Criar(Propriedade produtor)
        {
            throw new NotImplementedException();
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
