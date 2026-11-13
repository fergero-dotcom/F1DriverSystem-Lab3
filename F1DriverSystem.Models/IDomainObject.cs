namespace F1DriverSystem.Models
{
    /// <summary>
    /// Общий контракт доменной сущности, которая хранится в базе данных.
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Идентификатор сущности. Значение должно быть положительным.
        /// </summary>
        int ID { get; set; }
    }
}
