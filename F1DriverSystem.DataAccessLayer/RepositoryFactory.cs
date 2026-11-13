using System;
using System.Configuration;
using F1DriverSystem.Models;

namespace F1DriverSystem.DataAccessLayer
{
    /// <summary>
    /// Фабрика репозиториев. Оставлена для обратной совместимости и тестов;
    /// в приложениях зависимости разрешаются через IoC-контейнер Ninject.
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// Создаёт репозиторий по настройкам App.config (RepositoryProvider и F1Database).
        /// </summary>
        /// <typeparam name="T">Тип доменной сущности.</typeparam>
        /// <returns>Репозиторий указанного в конфигурации провайдера.</returns>
        public static IRepository<T> Create<T>() where T : class, IDomainObject
        {
            string provider = ConfigurationManager.AppSettings["RepositoryProvider"] ?? "EF";
            var setting = ConfigurationManager.ConnectionStrings["F1Database"];
            if (setting == null)
                throw new ConfigurationErrorsException("В App.config отсутствует строка подключения F1Database.");
            return Create<T>(provider, setting.ConnectionString);
        }

        /// <summary>
        /// Создаёт репозиторий заданного провайдера с указанной строкой подключения.
        /// </summary>
        /// <typeparam name="T">Тип доменной сущности.</typeparam>
        /// <param name="provider">Провайдер доступа к данным: EF или Dapper.</param>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        /// <returns>Репозиторий указанного провайдера.</returns>
        public static IRepository<T> Create<T>(string provider, string connectionString)
            where T : class, IDomainObject
        {
            IRepository<T> repository;
            if (string.Equals(provider, "EF", StringComparison.OrdinalIgnoreCase))
                repository = new EntityRepository<T>(connectionString);
            else if (string.Equals(provider, "Dapper", StringComparison.OrdinalIgnoreCase))
                repository = new DapperRepository<T>(connectionString);
            else
                throw new ConfigurationErrorsException("RepositoryProvider должен быть EF или Dapper.");

            DatabaseInitializer.EnsureCreated(connectionString);
            return repository;
        }
    }
}
