using System.Collections.Generic;
using F1DriverSystem.Models;

namespace F1DriverSystem.DataAccessLayer
{
    /// <summary>
    /// Абстракция репозитория: контракт CRUD-операций над доменными сущностями.
    /// Конкретная реализация (EntityRepository или DapperRepository)
    /// внедряется в бизнес-логику через DI-контейнер.
    /// </summary>
    /// <typeparam name="T">Тип доменной сущности.</typeparam>
    public interface IRepository<T> where T : class, IDomainObject
    {
        /// <summary>
        /// Добавляет сущность в хранилище.
        /// </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        void Add(T entity);
        /// <summary>
        /// Удаляет сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>true, если сущность удалена.</returns>
        bool Delete(int id);
        /// <summary>
        /// Возвращает все сущности из хранилища.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        List<T> ReadAll();
        /// <summary>
        /// Находит сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null, если она не найдена.</returns>
        T ReadById(int id);
        /// <summary>
        /// Обновляет сущность в хранилище.
        /// </summary>
        /// <param name="entity">Сущность с обновлёнными данными.</param>
        /// <returns>true, если сущность обновлена.</returns>
        bool Update(T entity);
    }
}
