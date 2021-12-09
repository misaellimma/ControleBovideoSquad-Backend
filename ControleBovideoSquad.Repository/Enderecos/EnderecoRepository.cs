using ControleBovideoSquad.Domain.Entities.Enderecos;
using ControleBovideoSquad.Domain.Repositories.Enderecos;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Enderecos
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public EnderecoRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public void Save(Endereco endereco)
        {
            this.unityOfWork.SaveOrUpdate(endereco);
        }

        public Endereco ObterEnderecoPorID(int id)
        {
            return this.unityOfWork.Query<Endereco>().FirstOrDefault(x => x.IdEndereco == id);
        }

        public List<Endereco> ObterEnderecos()
        {
            return this.unityOfWork.Query<Endereco>().ToList();
        }
    }
}
