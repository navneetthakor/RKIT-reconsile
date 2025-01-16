using System;
using ServiceStack.OrmLite;
using ORM_LITE.Models;

public class Program
{
    public static void Main(string[] args)
    {
        // Set the DialectProvider for MySQL

        using (var db = DatabaseService.GetDbConnection())
        {
            db.CreateTableIfNotExists<User>();
            Console.WriteLine("Table created successfully.");
        }
    }
}
