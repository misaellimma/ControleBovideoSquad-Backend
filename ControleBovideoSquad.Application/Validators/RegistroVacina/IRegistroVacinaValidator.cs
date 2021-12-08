using ControleBovideoSquad.CrossCutting.Dto.RegistroVacina;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.Validators.RegistroVacina
{
    public interface IRegistroVacinaValidator : IValidator<RegistroVacinaDto>
    {
        void VerificarQuantidade(RegistroVacinaDto registroVacinaDto, Rebanho rebanho);

    }
}
