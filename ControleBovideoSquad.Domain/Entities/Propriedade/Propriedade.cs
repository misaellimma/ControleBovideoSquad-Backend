using ControleBovideoSquad.CrossCutting.Dto.Propriedade;
using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Entities.Produtores;

namespace ControleBovideoSquad.Domain.Entities 
{
    public class Propriedade
    {
        public virtual int IdPropriedade { get; protected set; }
        public virtual string InscricaoEstadual { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual Endereco Endereco { get; protected set; }
        public virtual Produtor Produtor { get; protected set; }

        public Propriedade()
        {
        }

        public Propriedade(int idPropriedade, string inscricaoEstadual, string nome, Endereco endereco, Produtor produtor)
        {
            IdPropriedade = idPropriedade;
            InscricaoEstadual = inscricaoEstadual;
            Nome = nome;
            Endereco = endereco;
            Produtor = produtor;
        }

        public virtual void AlterarPropriedade(PropriedadeDto propriedadeDto)
        {
            Nome = propriedadeDto.Nome;
            Endereco.AtualizarEndereco(propriedadeDto);
            Produtor = new Produtor(propriedadeDto.IdProdutor);
        }
    }
}