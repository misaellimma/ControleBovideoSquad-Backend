using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Data;
using System.Reflection;

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

        private static ISessionFactory BuildSessionFactory()
        {
            var configuration = new Configuration();

            configuration.DataBaseIntegration(db =>
            {
                //db.ConnectionString = "Server = 192.168.0.104; Database = DbVacinacaoBovina; User ID = treinamento; Password = senha;";
                //db.ConnectionString = "Server = DESKTOP-BJMO5PO;Database = DbVacinacaoBovina;User ID=treinamento;Password=senha;";
                db.ConnectionString = "Server=(local);Database = DbVacinacaoBovina;Integrated Security = SSPI;";
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Driver<SqlClientDriver>();
                db.Dialect<MsSql2012Dialect>();
                db.BatchSize = 100;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
            });

            var fluentlyConfiguration = Fluently.Configure(configuration);

            fluentlyConfiguration.Mappings(x =>
               x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
            );

            return fluentlyConfiguration.BuildSessionFactory();
        }
    }
}
