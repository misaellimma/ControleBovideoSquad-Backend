﻿using ControleBovideoSquad.CrossCutting.Dto.Vacinacao;
using ControleBovideoSquad.Domain.Entities.Animais;

namespace ControleBovideoSquad.Application.Validators.Vacinacao
{
    public interface IRegistroVacinaValidator : IValidator<RegistroVacinaDto>
    {
        void VerificarQuantidade(RegistroVacinaDto registroVacinaDto, Rebanho rebanho);

    }
}
