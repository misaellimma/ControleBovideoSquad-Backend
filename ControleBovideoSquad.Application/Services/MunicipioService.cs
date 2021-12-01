using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.Application.Mapper;
using ControleBovideoSquad.CrossCutting.Dto.Municipio;
using ControleBovideoSquad.Domain.Entities.Municipios;
using ControleBovideoSquad.Domain.Repositories.Municipios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository municipioRepository;

        public MunicipioService(IMunicipioRepository municipioRepository)
        {
            this.municipioRepository = municipioRepository;
        }

        public Municipio ObterPorId(int id)
        {
            return municipioRepository.ObterPorId(id);
        }

        public List<Municipio> ObterTodos()
        {
            return municipioRepository.ObterTodos();
        }
    }
}
