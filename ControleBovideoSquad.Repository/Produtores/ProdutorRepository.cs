using ControleBovideoSquad.Domain.Entities.Produtores;
using ControleBovideoSquad.Domain.Repositories.Produtores;
using ControleBovideoSquad.Repository.Interfaces;

namespace ControleBovideoSquad.Repository.Produtores
{
    public class ProdutorRepository : IProdutorRepository
    {
        private readonly IUnityOfWork unityOfWork;

        public ProdutorRepository(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public void Salvar(Produtor produtor)
        {
            unityOfWork.SaveOrUpdate(produtor);
        }

        public Produtor ObterProdutorPorCpf(string cpf)
        {
            return unityOfWork
                .Query<Produtor>()
                .FirstOrDefault(e => e.CPF == cpf);
        }

        public Produtor ObterProdutorPorId(int id)
        {
            return unityOfWork
                .Query<Produtor>()
                .FirstOrDefault(e => e.IdProdutor == id);
        }

        public List<Produtor> ObterTodos()
        {
            return unityOfWork
                .Query<Produtor>()
                .ToList();
        }

        public void CriarOuAlterarProdutor(Produtor produtor)
        {
            throw new NotImplementedException();
        }
    }
}
