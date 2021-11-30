using ControleBovideoSquad.Application.IServices.Animais;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Repositories.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services
{
    public class EspecieService : IEspecieService
    {
        private readonly IEspecieRepository _especieRepository;

        public EspecieService(IEspecieRepository especieRepository)
        {
            this._especieRepository = especieRepository;
        }

        public Especie? ObterPorId(int id)
        {
            return _especieRepository.ObterEspeciePorId(id);
        }

        public List<Especie> ObterTodos()
        {
            return _especieRepository.ObterTodos();
        }
    }
}
