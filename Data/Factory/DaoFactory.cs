using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factory
{
    /// <summary>
    /// Data access object factory
    /// </summary>
    public class DaoFactory : IDaoFactory
    {
        class NestedDaoFactory
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static NestedDaoFactory()
            {

            }

            internal static readonly DaoFactory instance = new DaoFactory();
        }

        public static IContainer Container { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        private DaoFactory()
        {

        }

        public static DaoFactory Instance()
        {
            return NestedDaoFactory.instance;
        }

        /// <summary>
        /// Get data access object
        /// </summary>
        /// <typeparam name="T">Data access object type</typeparam>
        /// <returns>Data access object</returns>
        public T GetDao<T>() where T : BaseCore.IDao
        {
            if (Container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule<DataModule>();
                Container = builder.Build();
            }
            return Container.Resolve<T>();
        }
    }
}
