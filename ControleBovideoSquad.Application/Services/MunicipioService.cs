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
        private readonly MunicipioMapper municipioMapper;

        public MunicipioService(IMunicipioRepository municipioRepository, MunicipioMapper municipioMapper)
        {
            this.municipioRepository = municipioRepository;
            this.municipioMapper = municipioMapper;
        }

        public MunicipioDto ObterPorId(int id)
        {
            var municipio = municipioRepository.ObterPorId(id);
            return municipioMapper.MapearEntidadeParaDto(municipio);
        }

        public List<MunicipioDto> ObterTodos()
        {
            var municipios = municipioRepository.ObterTodos();
            return municipioMapper.MapearEntidadeParaDto(municipios);
        }
    }
}
