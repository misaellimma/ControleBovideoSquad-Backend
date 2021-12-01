using ControleBovideoSquad.Repository.Interfaces;
using ControleBovideoSquad.Repository.Util;
using NHibernate;

namespace ControleBovideoSquad.Repository.Entity
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ISession _session;
        private bool _isAlive = true;
        private bool _isCommited = true;
        private ITransaction _transaction;

        public UnityOfWork(SessionFactory sessionFactory)
        {
            _session = sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            if (!_isAlive)
                return;

            _isCommited = true;
        }

        public void Delete<T>(T entity)
        {
           _session.Delete(entity);
        }

        public void Dispose()
        {
           if(!_isAlive)
                return;

            _isAlive = false;

            try
            {
                if(_isCommited)
                    _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
                _session.Dispose();
            }
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }

        public void SaveOrUpdate<T>(T entity)
        {
            _session.SaveOrUpdate(entity);
        }
    }
}
