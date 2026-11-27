using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using F1DriverSystem.Models;

namespace F1DriverSystem.DataAccessLayer
{
    /// <summary>
    /// Репозиторий на основе Entity Framework 6: CRUD-операции через DbContext.
    /// Реализация абстракции IRepository, внедряется через DI-контейнер.
    /// </summary>
    /// <typeparam name="T">Тип доменной сущности.</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly string connectionString;

        /// <summary>
        /// Создаёт репозиторий с указанной строкой подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        public EntityRepository(string connectionString)
        {
            EntityMap.For<T>();
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Добавляет сущность в базу данных.
        /// </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        public void Add(T entity)
        {
            Validate(entity);
            using (var context = new DBContext(connectionString))
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет сущность из базы данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>true, если сущность удалена.</returns>
        public bool Delete(int id)
        {
            using (var context = new DBContext(connectionString))
            {
                T entity = context.Set<T>().Find(id);
                if (entity == null) return false;
                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Возвращает все сущности из базы данных, отсортированные по идентификатору.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        public List<T> ReadAll()
        {
            using (var context = new DBContext(connectionString))
                return context.Set<T>().AsNoTracking().ToList().OrderBy(x => x.Id).ToList();
        }

        /// <summary>
        /// Находит сущность в базе данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null, если она не найдена.</returns>
        public T ReadById(int id)
        {
            using (var context = new DBContext(connectionString))
                return context.Set<T>().Find(id);
        }

        /// <summary>
        /// Обновляет сущность в базе данных.
        /// </summary>
        /// <param name="entity">Сущность с обновлёнными данными.</param>
        /// <returns>true, если сущность обновлена.</returns>
        public bool Update(T entity)
        {
            Validate(entity);
            using (var context = new DBContext(connectionString))
            {
                T stored = context.Set<T>().Find(entity.Id);
                if (stored == null) return false;
                context.Entry(stored).CurrentValues.SetValues(entity);
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Проверяет корректность сущности перед записью в базу данных.
        /// </summary>
        /// <param name="entity">Проверяемая сущность.</param>
        private static void Validate(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id <= 0) throw new ArgumentOutOfRangeException(nameof(entity), "ID должен быть положительным.");
        }
    }
}
