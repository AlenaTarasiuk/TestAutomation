using Autofac;
using TestAutomation.Core.Utilities.Helpers.Configuration;
using Thinktecture;
using Thinktecture.IO;
using Thinktecture.IO.Adapters;

namespace TestAutomation.Core.Utilities.Helpers
{
    public static class ConfigurationHelper
    {
        public static IAppConfiguration Configuration { get; set; }

        static ConfigurationHelper()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileAdapter>().As<IFile>().SingleInstance();
            builder.RegisterJsonFileConfigurationProvider($"./appconfig.json");
            builder.RegisterJsonFileConfiguration<AppConfiguration>().As<IAppConfiguration>().SingleInstance();
            Configuration = builder.Build().BeginLifetimeScope().Resolve<IAppConfiguration>();
        }
    }
}
