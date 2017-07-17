using Autofac;
using System;

namespace Data.Factory
{
    public class DataModule : Module
    {
        /// <summary>
        /// Override to add registratins to the container
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            // Register access security data access object
            builder.Register<ctx => new UsersDao()).As<IUsersDao>().SingleInstance();
        }
    }
}
