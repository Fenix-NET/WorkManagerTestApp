using System.Diagnostics.CodeAnalysis;
using ConsoleDataGenerator.Data;
using ConsoleDataGenerator.Extensions;

namespace ConsoleDataGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для создания и заполнения БД начальными данными");
            Console.WriteLine("Вставьте строку подключения к БД PostgreSQL формата:\nserver=[server];username=[username];database=[databaseName];Password=[password]");

            try
            {
                string connectionString = Console.ReadLine();

                using (var db = new WorkDBContext(connectionString))
                {
                    if (db.Departments == null)
                    {
                        DataBasePlaceholder.AddDepartments(db);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("База данных уже заполнена");
                    }

                    if (db.Employees == null)
                    {
                        DataBasePlaceholder.AddEmployees(db);
                        db.SaveChanges();
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка выполнения программы");
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine("База данных успешно создана");
            Console.ReadKey();
        }
    }
}
