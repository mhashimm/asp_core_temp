using Autofac;
using mb.srs.Core.Interfaces;
using mb.srs.Core.Services;

namespace mb.srs.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}
