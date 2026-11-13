using System.Collections.Generic;

namespace F1DriverSystem.Core
{
    /// <summary>
    /// Абстракция бизнес-логики системы учёта гонщиков Формулы-1.
    /// Слой представления зависит только от этого интерфейса,
    /// конкретная реализация внедряется IoC-контейнером (Ninject).
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Добавляет нового гонщика.
        /// </summary>
        /// <param name="name">Имя гонщика.</param>
        /// <param name="team">Название команды.</param>
        /// <param name="points">Количество очков.</param>
        /// <returns>true, если гонщик успешно добавлен.</returns>
        bool AddDriver(string name, string team, int points);

        /// <summary>
        /// Возвращает список всех гонщиков, отсортированный по идентификатору.
        /// </summary>
        /// <returns>Список гонщиков.</returns>
        List<Driver> GetAllDrivers();

        /// <summary>
        /// Находит гонщика по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор гонщика.</param>
        /// <returns>Гонщик или null, если он не найден.</returns>
        Driver FindById(int id);

        /// <summary>
        /// Удаляет гонщика по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор гонщика.</param>
        /// <returns>true, если гонщик удалён.</returns>
        bool DeleteDriver(int id);

        /// <summary>
        /// Обновляет данные гонщика.
        /// </summary>
        /// <param name="id">Идентификатор гонщика.</param>
        /// <param name="name">Новое имя.</param>
        /// <param name="team">Новая команда.</param>
        /// <param name="points">Новое количество очков.</param>
        /// <returns>true, если данные обновлены.</returns>
        bool UpdateDriver(int id, string name, string team, int points);

        /// <summary>
        /// Возвращает гонщиков указанной команды.
        /// </summary>
        /// <param name="team">Название команды.</param>
        /// <returns>Список гонщиков команды.</returns>
        List<Driver> GetDriversByTeam(string team);

        /// <summary>
        /// Вычисляет среднее количество очков по всем гонщикам.
        /// </summary>
        /// <returns>Среднее количество очков (0, если гонщиков нет).</returns>
        double CalculateAveragePoints();
    }
}
