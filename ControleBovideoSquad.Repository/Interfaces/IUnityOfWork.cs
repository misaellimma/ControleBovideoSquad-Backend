using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
