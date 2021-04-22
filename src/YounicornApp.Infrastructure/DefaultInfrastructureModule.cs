using Autofac;
using System.Collections.Generic;
using System.Reflection;
using YounicornApp.Core;
using YounicornApp.Core.Interfaces;
using YounicornApp.Core.Services;
using YounicornApp.Infrastructure.Data;
using YounicornApp.Infrastructure.DomainEvents;
using YounicornApp.SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace YounicornApp.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private bool _isDevelopment = false;
        private List<Assembly> _assemblies = new List<Assembly>();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(DatabasePopulator));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository<>));
            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventDispatcher>().As<IDomainEventDispatcher>()
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>))
                .InstancePerLifetimeScope();           

            builder.RegisterAssemblyTypes(_assemblies.ToArray())
                .AsClosedTypesOf(typeof(IHandle<>));

            builder.RegisterType<ProviderService>().As<IProviderService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IspOfferService>().As<IIspOfferService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmailService>().As<IEmailService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnalyticsService>().As<IAnalyticsService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserHistoryService>().As<IUserHistoryService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountService>().As<IAccountService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SignUpService>().As<ISignUpService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmailSender>().As<IEmailSender>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }

    }
}
