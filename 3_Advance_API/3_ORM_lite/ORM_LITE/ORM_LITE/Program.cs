using System;
using ServiceStack.OrmLite;
using ORM_LITE.Models;
using ORM_LITE.Models.POCOs;

public class Program
{
    public static void Main(string[] args)
    {
        // Set the DialectProvider for MySQL

        using (var db = DatabaseService.GetDbConnection())
        {
            db.CreateTableIfNotExists<POCOAEWP01>();
            db.CreateTableIfNotExists<POCOAEWP02>();
            Console.WriteLine("Table created successfully.");
        }
    }
}




