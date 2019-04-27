namespace StockPracticeWork27._04._2019
{
    using StockPracticWork;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StockContext : DbContext
    {
        // Контекст настроен для использования строки подключения "StockContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "StockPracticeWork27._04._2019.StockContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "StockContext" 
        // в файле конфигурации приложения.
        public StockContext()
            : base("name=StockContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Stock> Stocks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}