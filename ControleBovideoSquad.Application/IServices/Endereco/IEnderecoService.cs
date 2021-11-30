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
        Result<Endereco> Save(Endereco endereco);
        List<Endereco> ObterTodos();
        Endereco Obter(int id);
    }
}
