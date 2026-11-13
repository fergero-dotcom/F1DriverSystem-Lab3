using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using F1DriverSystem.Models;

namespace F1DriverSystem.DataAccessLayer
{
    /// <summary>
    /// Репозиторий на основе Dapper: CRUD-операции выполняются SQL-запросами.
    /// Реализация абстракции IRepository, внедряется через DI-контейнер.
    /// </summary>
    /// <typeparam name="T">Тип доменной сущности.</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly string connectionString;
        private readonly EntityMap map;

        /// <summary>
        /// Создаёт репозиторий с указанной строкой подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        public DapperRepository(string connectionString)
        {
            this.connectionString = connectionString;
            map = EntityMap.For<T>();
        }

        /// <summary>
        /// Добавляет сущность в базу данных.
        /// </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        public void Add(T entity)
        {
            Validate(entity);
            using (var connection = new SqlConnection(connectionString))
                connection.Execute("INSERT INTO " + map.Table + " (" + map.Columns +
                    ") VALUES (" + map.Parameters + ")", entity);
        }

        /// <summary>
        /// Удаляет сущность из базы данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>true, если сущность удалена.</returns>
        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
                return connection.Execute("DELETE FROM " + map.Table + " WHERE [Id]=@Id",
                    new { Id = id }) > 0;
        }

        /// <summary>
        /// Возвращает все сущности из базы данных, отсортированные по идентификатору.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        public List<T> ReadAll()
        {
            using (var connection = new SqlConnection(connectionString))
                return connection.Query<T>("SELECT " + map.Columns + " FROM " + map.Table +
                    " ORDER BY [Id]").ToList();
        }

        /// <summary>
        /// Находит сущность в базе данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null, если она не найдена.</returns>
        public T ReadById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
                return connection.QuerySingleOrDefault<T>("SELECT " + map.Columns + " FROM " +
                    map.Table + " WHERE [Id]=@Id", new { Id = id });
        }

        /// <summary>
        /// Обновляет сущность в базе данных.
        /// </summary>
        /// <param name="entity">Сущность с обновлёнными данными.</param>
        /// <returns>true, если сущность обновлена.</returns>
        public bool Update(T entity)
        {
            Validate(entity);
            using (var connection = new SqlConnection(connectionString))
                return connection.Execute("UPDATE " + map.Table + " SET " + map.Assignments +
                    " WHERE [Id]=@Id", entity) > 0;
        }

        /// <summary>
        /// Проверяет корректность сущности перед записью в базу данных.
        /// </summary>
        /// <param name="entity">Проверяемая сущность.</param>
        private static void Validate(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.ID <= 0) throw new ArgumentOutOfRangeException(nameof(entity), "ID должен быть положительным.");
        }
    }
}
