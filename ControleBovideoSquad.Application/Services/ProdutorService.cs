using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Produtores;
using ControleBovideoSquad.Domain.Repositories.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Municipios;
using ControleBovideoSquad.Domain.Repositories.Produtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services
{
    public class ProdutorService : IProdutorService
    {
        private readonly IProdutorRepository produtorRepository;
        private readonly IProdutorMapper produtorMapper;

        public ProdutorService(IProdutorRepository produtorRepository, IProdutorMapper produtorMapper)
        {
            this.produtorRepository = produtorRepository;
            this.produtorMapper = produtorMapper;
        }

        public Result<ProdutorDto> AlterarProdutor(int id, ProdutorDto produtor)
        {
            if (produtor.IdProdutor != id)
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "Id da Url está divergente do body!");

            produtor.CPF = Formatar.FormatarString(produtor.CPF);
            produtorRepository.CriarOuAlterarProdutor(produtorMapper.MapearDtoParaEntidade(produtor));
            return Result<ProdutorDto>.Success(produtor);
        }

        public Result<ProdutorDto> CriarProdutor(ProdutorDto produtorDto)
        {
            if (!Validacao.ValidaCpf(produtorDto.CPF))
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF invalido!");

            produtorDto.CPF = Formatar.FormatarString(produtorDto.CPF);
            var produtorDtoCpf = produtorRepository.ObterProdutorPorCpf(produtorDto.CPF);

            if(produtorDtoCpf != null)
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF já cadastrado!");

            produtorDto.IdProdutor = 0;
            produtorDto.IdEndereco = null;
            var produtor = produtorMapper.MapearDtoParaEntidade(produtorDto);
            produtorRepository.CriarOuAlterarProdutor(produtor);

            return Result<ProdutorDto>.Success(produtorDto);
        }

        public Result<ProdutorDto> ObterProdutorPorCpf(string cpf)
        {
            if (cpf == null)
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF vazio!");

            if (!Validacao.ValidaCpf(cpf))
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF invalido!");

            var produtor = produtorRepository.ObterProdutorPorCpf(cpf);
            return Result<ProdutorDto>.Success(produtorMapper.MapearEntidadeParaDto(produtor));
        }

        public Result<ProdutorDto> ObterProdutorPorId(int id)
        {
            var produtor = produtorRepository.ObterProdutorPorId(id);

            if (produtor == null)
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "Não existe o produtor na base de dados");

            return Result<ProdutorDto>.Success(produtorMapper.MapearEntidadeParaDto(produtor));
        }

        public List<ProdutorDto> ObterTodos()
        {
            var produtores = produtorRepository.ObterTodos();
            return produtorMapper.MapearEntidadeParaDto(produtores);
        }
    }
}
