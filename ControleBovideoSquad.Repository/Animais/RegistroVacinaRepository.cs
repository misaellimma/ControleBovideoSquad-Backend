﻿using ControleBovideoSquad.Domain.Entities.Animal;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Animais
{
    public class RegistroVacinaRepository : IRegistroVacinaRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        public RegistroVacinaRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public RegistroVacina? Obter(int id)
        {
            return _unityOfWork.Query<RegistroVacina>().FirstOrDefault(x => x.IdRegistroVacina == id);
        }

        public List<RegistroVacina> ObterPorPropriedade(string inscricaoEstadual)
        {            
            return _unityOfWork.Query<RegistroVacina>().Where(x => x.Rebanho.Propriedade.InscricaoEstadual == inscricaoEstadual && x.Ativo == true).ToList();
        }

        public void Salvar(RegistroVacina registroVacina)
        {
            _unityOfWork.SaveOrUpdate(registroVacina);
        }
    }
}
