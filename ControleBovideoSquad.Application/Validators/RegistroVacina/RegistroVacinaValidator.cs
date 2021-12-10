using ControleBovideoSquad.CrossCutting.Dto.Vacinacao;
using ControleBovideoSquad.Domain.Entities.Animais;

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
            if (rebanho == null)
            {
                errors.Add("Especie não encontrada para respectiva propriedade!");
                return;
            }
            if (registroVacinaDto.Quantidade == 0 || registroVacinaDto.IdVacina == 0)
            {
                errors.Add("Quantidade ou Vacina não pode ser 0 ou nulo");
            }
            if (registroVacinaDto.IdVacina == 1)
            {
                if (rebanho.QuantidadeVacinadaBrucelose == rebanho.QuantidadeTotal)
                    errors.Add("Animais já vacinados contra brucelose");
                else if (registroVacinaDto.Quantidade > rebanho.QuantidadeTotal - rebanho.QuantidadeVacinadaBrucelose)
                    errors.Add($"Quantidade de vacinados não pode ser maior que quantidade restante a vacinar: {rebanho.QuantidadeTotal - rebanho.QuantidadeVacinadaBrucelose}");
            }
            else if (registroVacinaDto.IdVacina == 2)
            {
                if (rebanho.QuantidadeVacinadaAftosa == rebanho.QuantidadeTotal)
                    errors.Add("Animais já vacinados contra Aftosa");
                else if (registroVacinaDto.Quantidade > rebanho.QuantidadeTotal - rebanho.QuantidadeVacinadaAftosa)
                    errors.Add($"Quantidade de vacinados não pode ser maior que quantidade restante a vacinar: {rebanho.QuantidadeTotal - rebanho.QuantidadeVacinadaAftosa}");
            }
        }
    }
}
