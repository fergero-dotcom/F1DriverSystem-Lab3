using System;
using F1DriverSystem.Models;

namespace F1DriverSystem.DataAccessLayer
{
    /// <summary>
    /// Отображение сущности на таблицу базы данных для SQL-запросов Dapper.
    /// </summary>
    internal sealed class EntityMap
    {
        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public string Table { get; private set; }
        /// <summary>
        /// Список столбцов для чтения и вставки.
        /// </summary>
        public string Columns { get; private set; }
        /// <summary>
        /// Список параметров для команды INSERT.
        /// </summary>
        public string Parameters { get; private set; }
        /// <summary>
        /// Список присваиваний для команды UPDATE.
        /// </summary>
        public string Assignments { get; private set; }

        /// <summary>
        /// Закрытый конструктор отображения.
        /// </summary>
        /// <param name="table">Имя таблицы.</param>
        /// <param name="columns">Список столбцов.</param>
        /// <param name="parameters">Список параметров.</param>
        /// <param name="assignments">Список присваиваний.</param>
        private EntityMap(string table, string columns, string parameters, string assignments)
        {
            Table = table;
            Columns = columns;
            Parameters = parameters;
            Assignments = assignments;
        }

        /// <summary>
        /// Возвращает отображение для указанного типа сущности.
        /// </summary>
        /// <typeparam name="T">Тип доменной сущности.</typeparam>
        /// <returns>Отображение сущности на таблицу базы данных.</returns>
        public static EntityMap For<T>()
        {
            if (typeof(T) == typeof(Driver))
                return new EntityMap("[dbo].[Drivers]", "[Id], [Name], [Team], [Points]",
                    "@Id, @Name, @Team, @Points", "[Name]=@Name, [Team]=@Team, [Points]=@Points");
            if (typeof(T) == typeof(Race))
                return new EntityMap("[dbo].[Races]", "[Id], [Name], [Country], [Laps]",
                    "@Id, @Name, @Country, @Laps", "[Name]=@Name, [Country]=@Country, [Laps]=@Laps");
            throw new NotSupportedException("Не настроено отображение сущности " + typeof(T).Name);
        }
    }
}
