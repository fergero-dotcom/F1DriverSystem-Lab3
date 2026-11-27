using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using F1DriverSystem.Models;

namespace F1DriverSystem.DataAccessLayer
{
    /// <summary>
    /// Конфигурация Entity Framework: регистрирует провайдер SQL Server.
    /// </summary>
    public class SqlServerConfiguration : DbConfiguration
    {
        /// <summary>
        /// Настраивает использование провайдера System.Data.SqlClient.
        /// </summary>
        public SqlServerConfiguration()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }

    /// <summary>
    /// Контекст Entity Framework: отображает сущности Driver и Race на таблицы базы данных.
    /// </summary>
    [DbConfigurationType(typeof(SqlServerConfiguration))]
    public class DBContext : DbContext
    {
        static DBContext()
        {
            Database.SetInitializer<DBContext>(null);
        }

        /// <summary>
        /// Создаёт контекст с указанной строкой подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        public DBContext(string connectionString) : base(connectionString) { }

        /// <summary>
        /// Набор сущностей гонщиков (таблица Drivers).
        /// </summary>
        public DbSet<Driver> Drivers { get; set; }
        /// <summary>
        /// Набор сущностей этапов (таблица Races).
        /// </summary>
        public DbSet<Race> Races { get; set; }

        /// <summary>
        /// Настраивает отображение сущностей на таблицы базы данных.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели Entity Framework.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().ToTable("Drivers", "dbo").HasKey(x => x.Id);
            modelBuilder.Entity<Driver>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Driver>().Property(x => x.Name).IsRequired().IsMaxLength();
            modelBuilder.Entity<Driver>().Property(x => x.Team).IsRequired().IsMaxLength();

            modelBuilder.Entity<Race>().ToTable("Races", "dbo").HasKey(x => x.Id);
            modelBuilder.Entity<Race>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Race>().Property(x => x.Name).IsRequired().IsMaxLength();
            modelBuilder.Entity<Race>().Property(x => x.Country).IsRequired().IsMaxLength();
            base.OnModelCreating(modelBuilder);
        }
    }
}
