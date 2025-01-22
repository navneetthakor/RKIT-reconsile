using DotNetEnv;
using Final_Demo_AvanceCSharp.Business_Logic;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Models;
using Final_Demo_AvanceCSharp.Modals.Enums;
using Final_Demo_AvanceCSharp.Utilitlies;
using ServiceStack.OrmLite;
using System;
using Final_Demo_AvanceCSharp.Modals.DTOs;

class Program
{
    static void Main(string[] args)
    {
        /// <summary>
        /// Creating table  if not exist
        /// </summary>
        using (var db = DatabaseService.GetDbConnection())
        {
            db.Open();

            db.CreateTableIfNotExists<FDAP01>();
            db.CreateTableIfNotExists<FDAP02>();
            db.CreateTableIfNotExists<FDAP03>();

            AdminLogics adm = new AdminLogics(db);
            //Response rs = adm.GetAllAuthors();

            //Console.WriteLine("\n\n");
            //adm.GetAllBooks();

            //Console.WriteLine("\n\n");
            //adm.PreDelete(2, WOBEnum.Book);
            //adm.ValidateOnDelete(WOBEnum.Book);
            //adm.Delete(WOBEnum.Book);

            //Console.WriteLine("\n\n");
            //rs = adm.GetAllAuthors();

            Console.WriteLine("\n\n");
            adm.GetAllBooks();

            // Author logic ----
            FDAP01 fdap01 = new FDAP01() { A01F01 = 2 };
            AuthorLogics atl = new AuthorLogics(db, fdap01);

            // add book
            //FDAP03 fdap03 = new FDAP03() { A03F02 = "Hello", A03F03 = "hhh" };
            //Response rs = atl.PreSave(fdap03, OppEnum.A);
            //if(!rs.IsError) rs = atl.ValidateOnSave(OppEnum.A);
            //if (!rs.IsError) rs = atl.Save(OppEnum.A);

            // update book
            FDAP03 fdap03 = new FDAP03() { A03F01 = 17, A03F02 = "NkTheBoss", A03F03 = "nk" };
            Response rs = atl.PreSave(fdap03, OppEnum.U);
            if (!rs.IsError) rs = atl.ValidateOnSave(OppEnum.U);
            if (!rs.IsError) rs = atl.Save(OppEnum.U);

            Console.WriteLine("\n\n");
            adm.GetAllBooks();
        }


    }

    private static bool ChangePassword()
    {
        Env.Load("D:\\1\\rkit\\reconsile\\3_Advance_API\\Final_Demo_AvanceC#\\Final_Demo_AvanceC#\\.env");

        string? appPassword = Environment.GetEnvironmentVariable("APP_PASSWORDS");
        string? email = Environment.GetEnvironmentVariable("MY_EMAIL");

        MailService ms = new MailService(email, appPassword);

        if(ms.VarifyEmail("codewithNaveet@gmail.com"))
        {
            try
            {

                // logic to change Password
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return false;

    }
}
