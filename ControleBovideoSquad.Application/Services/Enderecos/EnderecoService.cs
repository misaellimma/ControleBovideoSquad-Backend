using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.Application.IServices.Enderecos;
using ControleBovideoSquad.Application.Validators;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Enderecos;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Enderecos;

namespace ControleBovideoSquad.Application.Services.Enderecos
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper<EnderecoDto, Endereco> _enderecoMapper;
        private readonly IValidator<EnderecoDto> enderecoValidator;

        public EnderecoService(IEnderecoRepository enderecoRepository, 
            IMapper<EnderecoDto, Endereco> enderecoMapper,
            IValidator<EnderecoDto> enderecoValidator)            
        {
            _enderecoRepository = enderecoRepository;
            _enderecoMapper = enderecoMapper;
            this.enderecoValidator = enderecoValidator;
        }

        public Endereco Obter(int id)
        {
            return this._enderecoRepository.ObterEnderecoPorID(id);
        }

        public List<Endereco> ObterTodos()
        {
            return this._enderecoRepository.ObterEnderecos();
        }

        public Result<Endereco> Save(EnderecoDto enderecoDto)
        {
            var validator = enderecoValidator.IsValid(enderecoDto);

            if(validator.Count > 0)
                return Result<Endereco>.Error(EStatusCode.BAD_REQUEST, validator);

            _enderecoRepository.Save(_enderecoMapper.MapearDtoParaEntidade(enderecoDto));
            return Result<Endereco>.Success(_enderecoMapper.MapearDtoParaEntidade(enderecoDto));

        }
       
    }
}
