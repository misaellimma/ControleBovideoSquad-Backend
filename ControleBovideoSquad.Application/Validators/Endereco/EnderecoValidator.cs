using ControleBovideoSquad.CrossCutting.Dto.EnderecoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Validators.Endereco
{
    public class EnderecoValidator : IValidator<EnderecoDto>
    {

        private readonly IValidator<EnderecoDto> _nullValidator;

        public EnderecoValidator()
        {
                _nullValidator = new NullValidator<EnderecoDto>();
                errors = new List<string>();
        }

        public List<string> errors { get; }

        public List<string> IsValid(EnderecoDto enderecoDto)
        {
            errors.AddRange(_nullValidator.IsValid(enderecoDto));

            if (enderecoDto.Rua.Length > 200)
            {
                errors.Add("Rua não pode se rmaior que 250 caracteres");
            }
            if (enderecoDto.Numero.Length > 20)
            {
                errors.Add("Numero não pode ser maior que 20 caracteres");
            }

            return errors;
        }
    }
}
