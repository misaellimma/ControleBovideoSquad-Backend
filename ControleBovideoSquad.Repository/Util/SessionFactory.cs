using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Repository.Util
{
    public class SessionFactory
    {
        private readonly ISessionFactory _sessionFactory;        

        public SessionFactory()
        {
            _sessionFactory = BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        private ISessionFactory BuildSessionFactory()
        {
            var configuration = new Configuration();

            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = "Server = DESKTOP - BJMO5PO; Database = DbVacinacaoBovina; User ID = treinamento; Password = senha;";
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Driver<SqlClientDriver>();
                db.Dialect<MsSql2012Dialect>();
                db.BatchSize = 100;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
            });

            var fluentlyConfiguration = Fluently.Configure(configuration);

            fluentlyConfiguration.Mappings(x =>
               x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
            );

            return fluentlyConfiguration.BuildSessionFactory();
        }
    }
}
