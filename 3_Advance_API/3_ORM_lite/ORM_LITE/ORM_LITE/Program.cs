using System;
using ServiceStack.OrmLite;
using ORM_LITE.Models;
using ORM_LITE.Models.POCOs;
using ORM_LITE.Business_Logic.BLClasses;
using ORM_LITE.Models.Enum;
using ORM_LITE.Models.DTOs;

public class Program
{
    public static void Main(string[] args)
    {
        // Set the DialectProvider for MySQL

        using (var db = DatabaseService.GetDbConnection())
        {

            DTOAEWP01 dto = new DTOAEWP01()
            {
                P01102 = "Navneet",
                P01103 = "tonystark",
                P01104 = "codewithnavneet@gmail.com",
                P01105 = "6363636363"
            };
            WriterLogic wl = new WriterLogic(dto, OperationType.A, db);

            //presave 
            Response res = wl.PreSave();
            if (res.IsError)
            {
                Console.WriteLine("ERROR : " + res.Message); return;
            }
            Console.WriteLine("Presave");

            // validate
            res = wl.Validate();
            if(res.IsError)
            {
                Console.WriteLine("ERROR : " + res.Message); return;
            }
            Console.WriteLine("Validate");

            //save
            res = wl.Save();
            if (res.IsError)
            {
                Console.WriteLine("ERROR : " + res.Message); return;
            }
            Console.WriteLine("Save");
        }
    }
}




