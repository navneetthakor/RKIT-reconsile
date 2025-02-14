﻿using System;
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
        /// <summary>
        /// Creating table  if not exist
        /// </summary>
        using (var db = DatabaseService.GetDbConnection())
        {
            db.CreateTableIfNotExists<POCOAEWP01>();
            db.CreateTableIfNotExists<POCOAEWP02>();
        }


        ///<summary>
        ///Iterative loop
        /// </summary>
        do
        {
            int input = 5;

            Console.WriteLine("\n\n --- select approperiate option ---- ");
            Console.WriteLine("1: AddWriter");
            Console.WriteLine("2: AddBook");
            Console.WriteLine("3: BookWithWriter");
            Console.WriteLine("4: Exit");

            input = Convert.ToInt32(Console.ReadLine());

            switch(input)
            {
                case 1:
                    AddWriter();
                    break;
                case 2:
                    AddBook();
                    break;
                case 3:
                    BookWithWriter();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Please provide appropriate input");
                    break;
            }

        } while (true);


        

    }

    /// <summary>
    /// To add writer 
    /// </summary>
    private static void AddWriter()
    {
        Console.Write("Name : ");
        string name = Console.ReadLine();

        Console.Write("Password : ");
        string password = Console.ReadLine();

        Console.Write("Email : ");
        string email = Console.ReadLine();

        Console.Write("Phone :  ");
        string phone = Console.ReadLine();

        DTOAEWP01 dto = new DTOAEWP01()
        {
            P01102 = name,
            P01103 = password,
            P01104 = email,
            P01105 = phone
        };

        using (var db = DatabaseService.GetDbConnection())
        {

            
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

    }

    /// <summary>
    /// To add book in database
    /// </summary>
    private static void AddBook()
    {
        Console.Write("Title : ");
        string title = Console.ReadLine();

        Console.Write("Writer Id : ");
        int WriterId = Convert.ToInt32(Console.ReadLine());

        DTOAEWP02 dto = new DTOAEWP02()
        {
            P02202 = title,
            P02203 = WriterId
        };

        using (var db = DatabaseService.GetDbConnection())
        {

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
    }

    /// <summary>
    /// To display all the book of particular user
    /// </summary>
    private static void BookWithWriter()
    {
        Console.Write("Writer ID : ");
        int WriterId = Convert.ToInt32(Console.ReadLine());

        using (var db = DatabaseService.GetDbConnection())
        {
            WriterLogic wl = new WriterLogic(OperationType.R, db);
            BookLogic bl = new BookLogic(OperationType.R, db);

            Response writerData = wl.GetData(WriterId);
            if (writerData.IsError)
            {
                Console.WriteLine("ERROR : " + writerData.Message); return;
            }

            Response allBooks = bl.GetAllBookByWriter(WriterId);
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
                Console.WriteLine();
            }
        }

    }
}




