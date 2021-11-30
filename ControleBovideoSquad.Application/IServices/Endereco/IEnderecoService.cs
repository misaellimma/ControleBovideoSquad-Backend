using ControleBovideoSquad.CrossCutting.Dto.EnderecoDto;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IServices.Enderecos
{
    public interface IEnderecoService
    {
        Result<Endereco> Save(EnderecoDto endereco);
        List<Endereco> ObterTodos();
        Endereco Obter(int id);
    }
}
