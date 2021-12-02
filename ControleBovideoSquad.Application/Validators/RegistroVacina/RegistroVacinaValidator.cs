using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.Domain.Entities.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Validators.RegistroVacina
{
    public class RegistroVacinaValidator : IRegistroVacinaValidator
    {
        private readonly IValidator<RegistroVacinaDto> _nullValidator;

        public RegistroVacinaValidator()
        {
            _nullValidator = new NullValidator<RegistroVacinaDto>();
            errors = new List<string>();
        }

        public List<string> errors { get; }

        public List<string> IsValid(RegistroVacinaDto registroVacinaDto)
        {
           errors.AddRange(_nullValidator.IsValid(registroVacinaDto));
            return errors;
        }

        public void VerificarQuantidade(RegistroVacinaDto registroVacinaDto, Rebanho rebanho)
        {
            if(rebanho == null)
            {
                errors.Add("Especie não encontrada para respectiva propriedade!");
                return;
            }
            if (registroVacinaDto.Quantidade == 0|| registroVacinaDto.IdVacina == 0)
            {
                errors.Add("Quantidade ou Vacina não pode ser 0 ou nulo");
            }
            if (registroVacinaDto.IdVacina == 1 && rebanho.QuantidadeVacinadaBrucelose == rebanho.QuantidadeTotal)
            {
                errors.Add("Animais já vacinados contra brucelose");            
            }
            if (registroVacinaDto.IdVacina == 2 && rebanho.QuantidadeVacinadaAftosa == rebanho.QuantidadeTotal)
            {
                errors.Add("Animais já vacinados contra Aftose");            
            }
        }
    }
}
