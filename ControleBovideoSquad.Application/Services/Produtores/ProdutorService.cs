using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.Application.IServices.Produtores;
using ControleBovideoSquad.CrossCutting.Dto.Produtores;
using ControleBovideoSquad.CrossCutting.Enums;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Repositories.Produtores;

namespace ControleBovideoSquad.Application.Services.Produtores
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

        public Result<bool> Alterar(ProdutorDto produtor)
        {
            var produtorBD = produtorRepository.ObterProdutorPorId(produtor.IdProdutor);
            produtor.CPF = Formatar.FormatarString(produtor.CPF);
            produtorBD.AtualizarProdutor(produtor);
            produtorRepository.Salvar(produtorBD);
            return Result<bool>.Success(true);
        }

        public Result<ProdutorDto> Incluir(ProdutorDto produtorDto)
        {
            if (!Validacao.ValidaCpf(produtorDto.CPF))
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF invalido!");

            produtorDto.CPF = Formatar.FormatarString(produtorDto.CPF);
            var produtorDtoCpf = produtorRepository.ObterProdutorPorCpf(produtorDto.CPF);

            if (produtorDtoCpf != null)
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF já cadastrado!");

            var produtor = produtorMapper.MapearDtoParaEntidade(produtorDto);
            produtorRepository.Salvar(produtor);

            return Result<ProdutorDto>.Success(produtorDto);
        }

        public Result<ProdutorDto> ObterProdutorPorCpf(string cpf)
        {
            if (!Validacao.ValidaCpf(cpf))
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "CPF invalido!");

            cpf = Formatar.FormatarString(cpf);

            var produtor = produtorRepository.ObterProdutorPorCpf(cpf);

            if (produtor == null)
                return Result<ProdutorDto>.Error(EStatusCode.NOT_FOUND, "Não existe o CPF na base de dados!");

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
