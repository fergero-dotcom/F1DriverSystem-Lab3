using System.Collections.Generic;
using F1DriverSystem.Models;

namespace F1DriverSystem.Core
{
    /// <summary>
    /// Абстракция бизнес-логики каталога этапов (Гран-при).
    /// Слой представления зависит только от этого интерфейса,
    /// конкретная реализация внедряется IoC-контейнером (Ninject).
    /// </summary>
    public interface IRaceLogic
    {
        /// <summary>
        /// Возвращает список всех этапов, отсортированный по идентификатору.
        /// </summary>
        /// <returns>Список этапов.</returns>
        List<Race> GetAllRaces();

        /// <summary>
        /// Находит этап по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор этапа.</param>
        /// <returns>Этап или null, если он не найден.</returns>
        Race FindById(int id);

        /// <summary>
        /// Добавляет новый этап.
        /// </summary>
        /// <param name="name">Название этапа.</param>
        /// <param name="country">Страна проведения.</param>
        /// <param name="laps">Количество кругов.</param>
        /// <returns>true, если этап успешно добавлен.</returns>
        bool AddRace(string name, string country, int laps);

        /// <summary>
        /// Обновляет данные этапа.
        /// </summary>
        /// <param name="id">Идентификатор этапа.</param>
        /// <param name="name">Новое название.</param>
        /// <param name="country">Новая страна проведения.</param>
        /// <param name="laps">Новое количество кругов.</param>
        /// <returns>true, если данные обновлены.</returns>
        bool UpdateRace(int id, string name, string country, int laps);

        /// <summary>
        /// Удаляет этап по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор этапа.</param>
        /// <returns>true, если этап удалён.</returns>
        bool DeleteRace(int id);
    }
}
