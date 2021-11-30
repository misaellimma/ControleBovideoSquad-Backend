using ControleBovideoSquad.Application.IServices.Enderecos;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Services.Enderecos
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            this._enderecoRepository = enderecoRepository;
        }

        public Endereco Obter(int id)
        {
            return this._enderecoRepository.ObterEnderecoPorID(id);
        }

        public List<Endereco> ObterTodos()
        {
            return this._enderecoRepository.ObterEnderecos();
        }

        public Result<Endereco> Save(Endereco endereco)
        {
            var response = TempClassToValidate(endereco);

            if(response.Any())
                return Result<Endereco>.Error(response);

            return Result<Endereco>.Success(endereco);

        }

        public List<string> TempClassToValidate(Endereco endereco)
        {
            List<string> errors = new List<string>();

            if (endereco.Rua == null || endereco.Numero == null || endereco.Municipio.IdMunicipio == 0)
            {
                errors.Add("Rua, Endereco, ou IdMuncipio não pode ser nulo!");
            }
            if(endereco.Rua.Length > 200)
            {
                errors.Add("Rua não pode se rmaior que 250 caracteres");
            }
            if (endereco.Numero.Length > 20)
            {
                errors.Add("Numero não pode ser maior que 20 caracteres");
            }            

            return errors;
        }
    }
}
