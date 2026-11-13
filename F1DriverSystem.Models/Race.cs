namespace F1DriverSystem.Models
{
    /// <summary>
    /// Этап чемпионата (Гран-при). Реализует контракт доменной сущности IDomainObject.
    /// </summary>
    public class Race : IDomainObject
    {
        /// <summary>
        /// Идентификатор этапа. Значение должно быть положительным.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название этапа.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Страна проведения.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Количество кругов.
        /// </summary>
        public int Laps { get; set; }

        /// <summary>
        /// Реализация контракта IDomainObject: идентификатор сущности.
        /// </summary>
        int IDomainObject.ID { get { return Id; } set { Id = value; } }

        /// <summary>
        /// Создаёт пустой объект этапа. Используется ORM и сериализацией.
        /// </summary>
        public Race() { }

        /// <summary>
        /// Создаёт объект этапа с заполненными данными.
        /// </summary>
        /// <param name="id">Идентификатор этапа.</param>
        /// <param name="name">Название этапа.</param>
        /// <param name="country">Страна проведения.</param>
        /// <param name="laps">Количество кругов.</param>
        public Race(int id, string name, string country, int laps)
        {
            Id = id;
            Name = name;
            Country = country;
            Laps = laps;
        }
    }
}
