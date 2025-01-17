using System;
using ServiceStack.OrmLite;
using ORM_LITE.Models;
using ORM_LITE.Models.POCOs;
using ORM_LITE.Business_Logic.BLClasses;
using ORM_LITE.Models.Enum;
using ORM_LITE.Models.DTOs;

public class Program2
{
    public static void Main2(string[] args)
    {
        /// <summary>
        /// Creating table  if not exist
        /// </summary>
        using (var db = DatabaseService.GetDbConnection())
        {
            db.CreateTableIfNotExists<POCOAEWP01>();
            db.CreateTableIfNotExists<POCOAEWP02>();
        }


        ///<summary>
        /// adding writer
        /// </summary>
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
            if (res.IsError)
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

        /// <summary>
        /// Adding book
        /// </summary>
        using (var db = DatabaseService.GetDbConnection())
        {

            DTOAEWP02 dto = new DTOAEWP02()
            {
                P02202 = "Hello Baby",
                P02203 = 1

            };
            BookLogic bl = new BookLogic(dto, OperationType.A, db);

            //presave 
            Response res = bl.PreSave();
            if (res.IsError)
            {
                Console.WriteLine("ERROR : " + res.Message); return;
            }
            Console.WriteLine("Presave");

            // validate
            res = bl.Validate();
            if (res.IsError)
            {
                Console.WriteLine("ERROR : " + res.Message); return;
            }
            Console.WriteLine("Validate");

            //save
            res = bl.Save();
            if (res.IsError)
            {
                Console.WriteLine("ERROR : " + res.Message); return;
            }
            Console.WriteLine("Save");
        }

        //fetching books by id of writer
        using (var db = DatabaseService.GetDbConnection())
        {
            WriterLogic wl = new WriterLogic(OperationType.R, db);
            BookLogic bl = new BookLogic(OperationType.R, db);

            Response writerData = wl.GetData(1);
            if (writerData.IsError)
            {
                Console.WriteLine("ERROR : " + writerData.Message); return;
            }

            Response allBooks = bl.GetAllBookByWriter(1);
            if (writerData.IsError)
            {
                Console.WriteLine("ERROR : " + writerData.Message); return;
            }

            //Displaying data 
            Console.WriteLine("BOOKS : :");
            foreach (var b in allBooks.Data)
            {
                //DTOAEWP03 sample = b.ToDTO(writerData);
                //Console.WriteLine("Book ID : " + b.P02201);
                Console.WriteLine("Book title : " + b.P02202);
                Console.WriteLine("Writer Name : " + writerData.Data.P01102);

            }
        }

    }
}




