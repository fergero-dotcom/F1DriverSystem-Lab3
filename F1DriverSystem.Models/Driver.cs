using F1DriverSystem.Models;
namespace F1DriverSystem.Core
{
    /// <summary>
    /// Гонщик Формулы-1. Реализует контракт доменной сущности IDomainObject.
    /// </summary>
    public class Driver : IDomainObject
    {
        /// <summary>
        /// Идентификатор гонщика. Значение должно быть положительным.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Реализация контракта IDomainObject: идентификатор сущности.
        /// </summary>
        int IDomainObject.ID { get { return Id; } set { Id = value; } }
        /// <summary>
        /// Имя гонщика.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Название команды.
        /// </summary>
        public string Team { get; set; }
        /// <summary>
        /// Количество очков.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Создаёт пустой объект гонщика. Используется ORM и сериализацией.
        /// </summary>
        public Driver() { }

        /// <summary>
        /// Создаёт объект гонщика с заполненными данными.
        /// </summary>
        /// <param name="id">Идентификатор гонщика.</param>
        /// <param name="name">Имя гонщика.</param>
        /// <param name="team">Название команды.</param>
        /// <param name="points">Количество очков.</param>
        public Driver(int id, string name, string team, int points)
        {
            Id = id;
            Name = name;
            Team = team;
            Points = points;
        }
    }
}
