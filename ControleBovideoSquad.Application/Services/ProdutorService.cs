using ControleBovideoSquad.Application.IMapper.Produtores;
using ControleBovideoSquad.Application.IServices;
using ControleBovideoSquad.CrossCutting.Dto.Produtor;
using ControleBovideoSquad.CrossCutting.Util;
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
        //private readonly IEnderecoRepository enderecoRepository;
        //private readonly IMunicipioRepository municipioRepository;
        private readonly IProdutorMapper produtorMapper;

        public ProdutorService(IProdutorRepository produtorRepository, IProdutorMapper produtorMapper)
        {
            this.produtorRepository = produtorRepository;
            this.produtorMapper = produtorMapper;
        }

        public void AlterarProdutor(Produtor produtor)
        {
            throw new NotImplementedException();
        }

        public void CriarProdutor(Produtor produtor)
        {
            produtorRepository.CriarOuAlterarProdutor(produtor);
            
        }

        public Result<Produtor> ObterProdutorPorCpf(string cpf)
        {
            if (!Validacao.ValidaCpf(cpf))
                return Result<Produtor>.Error("CPF invalido!");

            var produtor = produtorRepository.ObterProdutorPorCpf(cpf);
            return Result<Produtor>.Success(produtor);
        }

        public Produtor ObterProdutorPorId(int id)
        {
            return produtorRepository.ObterProdutorPorId(id);
        }

        public List<ProdutorDto> ObterTodos()
        {
            var produtores = produtorRepository.ObterTodos();

            //return produtores;
            return produtorMapper.MapearEntidadeParaDto(produtores);
        }
    }
}
