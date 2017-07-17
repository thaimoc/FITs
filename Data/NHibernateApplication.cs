using Data.Factory;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal static class NHibernateApplication
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;
        private static ISession _session;
        private static IStatelessSession _statelessSession;

        public static bool QueryCache
        {
            get
            {
                var appSettings = System.Configuration.ConfigurationManager.AppSettings;
                var check = appSettings.AllKeys.Contains("QueryCache")
                    ? appSettings["QueryCache"] : string.Empty;
                return (check.Trim().ToLower() == "true");
            }
        }

        public NHibernateApplication()
        {
            try
            {
                _configuration = new Configuration();
                var fluentConfig = Fluently.Configure(_configuration);
                if (QueryCache)
                {
                    fluentConfig.Cache(cache => cache.UseQueryCache().UseSecondLevelCache());
                }
                else
                {
                    fluentConfig.Cache(cache => cache.Not.UseQueryCache().Not.UseSecondLevelCache());
                }
                _sessionFactory = fluentConfig.Mappings(map => map.FluentMappings.AddFromAssemblyOf<DaoFactory>()).BuildSessionFactory();
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Get current hibernate session
        /// </summary>
        public static ISession CurrentSession
        {
            get
            {
                if (_session == null)
                    _session = _sessionFactory.OpenSession();
                return _session;
            }
        }

        /// <summary>
        /// Get Stateless Session
        /// </summary>
        public static IStatelessSession StatelessSession
        {
            get
            {
                if (_statelessSession == null)
                    _statelessSession = _sessionFactory.OpenStatelessSession();
                return _statelessSession;
            }
        }

        /// <summary>
        /// Dispose all session
        /// </summary>
        public static void Dispose()
        {
            if (_session != null)
            {
                if (_session.IsOpen)
                    _session.Close();
                _session.Dispose();
                _session = null;
            }
            if (StatelessSession != null)
            {
                if (_statelessSession != null)
                    _statelessSession.Close();
                _statelessSession.Dispose();
                _statelessSession = null;
            }
        }

        /// <summary>
        /// Get a NHibernate Configuration instance
        /// </summary>
        public static Configuration Configuration
        {
            get { return _configuration; }
        }


        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    _sessionFactory.OpenSession();
                return _sessionFactory;
            }
        }
    }
}
