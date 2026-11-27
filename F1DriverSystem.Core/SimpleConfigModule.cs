using System;
using System.Configuration;
using F1DriverSystem.DataAccessLayer;
using F1DriverSystem.Models;
using Ninject;
using Ninject.Modules;

namespace F1DriverSystem.Core
{
    /// <summary>Регистрирует репозитории и бизнес-логику в Ninject.</summary>
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            string provider = ConfigurationManager.AppSettings["RepositoryProvider"] ?? "EF";
            if (!string.Equals(provider, "EF", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(provider, "Dapper", StringComparison.OrdinalIgnoreCase))
                throw new ConfigurationErrorsException("RepositoryProvider должен быть EF или Dapper.");

            var setting = ConfigurationManager.ConnectionStrings["F1Database"];
            if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                throw new ConfigurationErrorsException("В App.config отсутствует или пуста строка подключения F1Database.");

            string connectionString = setting.ConnectionString;
            Bind<IRepository<Driver>>()
                .ToMethod(context => RepositoryFactory.Create<Driver>(provider, connectionString))
                .InSingletonScope();
            Bind<IRepository<Race>>()
                .ToMethod(context => RepositoryFactory.Create<Race>(provider, connectionString))
                .InSingletonScope();
            Bind<ILogic>()
                .ToMethod(context => Logic.GetInstance(context.Kernel.Get<IRepository<Driver>>()))
                .InSingletonScope();
            Bind<IRaceLogic>()
                .ToMethod(context => RaceLogic.GetInstance(context.Kernel.Get<IRepository<Race>>()))
                .InSingletonScope();
        }
    }
}
