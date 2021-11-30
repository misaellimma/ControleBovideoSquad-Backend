using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.Domain.Entities.Produtores;
using ControleBovideoSquad.Domain.Repositories.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Municipios;
using ControleBovideoSquad.Domain.Repositories.Produtores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services
{
    public class ProdutorService : IProdutorService
    {
        private readonly IProdutorRepository produtorRepository;
        private readonly IEnderecoRepository enderecoRepository;
        private readonly IMunicipioRepository municipioRepository;
        private readonly IProdutorMapper produtorMapper;

        public ProdutorService(IProdutorRepository produtorRepository)
        {
            this.produtorRepository = produtorRepository;
        }

        public void AlterarProdutor(Produtor produtor)
        {
            throw new NotImplementedException();
        }

        public void CriarProdutor(Produtor produtor)
        {
            produtorRepository.CriarOuAlterarProdutor(produtor);
            
        }

        public Produtor ObterProdutorPorCpf(string cpf)
        {
            return produtorRepository.ObterProdutorPorCpf(cpf);
        }

        public Produtor ObterProdutorPorId(int id)
        {
            return produtorRepository.ObterProdutorPorId(id);
        }

        public List<ProdutorDto> ObterTodos()
        {
            var produtores = produtorRepository.ObterTodos();
            
            if (produtores == null)
                return null;

            return produtorMapper.MapearEntidadeParaDto(produtores);
        }
    }
}
