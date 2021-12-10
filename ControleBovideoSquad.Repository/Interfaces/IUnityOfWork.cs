namespace ControleBovideoSquad.Repository.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        void Commit();
        void SaveOrUpdate<T>(T entity);
        void Delete<T>(T entity);
        IQueryable<T> Query<T>();
    }
}
