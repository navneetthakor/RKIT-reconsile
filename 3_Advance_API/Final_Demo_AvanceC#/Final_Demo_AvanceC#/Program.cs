using DotNetEnv;
using Final_Demo_AvanceC_.Controllers;
using Final_Demo_AvanceCSharp.Controllers;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Utilitlies;
using ServiceStack.OrmLite;
using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        #region DotEnv
        // for my personal laptop
        //Env.Load("D:\\1\\rkit\\reconsile\\3_Advance_API\\Final_Demo_AvanceC#\\Final_Demo_AvanceCSharp\\.env"); 

        // for compnay server
        Env.Load("C:\\Users\\navneetkumar.t\\source\\repos\\navneetthakor\\RKIT-reconsile\\3_Advance_API\\Final_Demo_AvanceC#\\Final_Demo_AvanceC#\\.env");
        #endregion 

        using (var db = DatabaseService.GetDbConnection())
        {
            db.Open();

            #region CreateTableIfNotExist
            db.CreateTableIfNotExists<FDAP01>();
            db.CreateTableIfNotExists<FDAP02>();
            db.CreateTableIfNotExists<FDAP03>();
            #endregion

            while (true)
            {
                Console.WriteLine("\n\n---------- Main Menu ---------------\n\n");
                Console.WriteLine("1. Register as Author");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                int opCode = Convert.ToInt32(Console.ReadLine());

                switch (opCode)
                {
                    case 1:
                        RegistrationController.MainEvent(db);
                        break;
                    case 2:
                        LoginController.MainEvent(db);
                        break;
                    case 3:
                        return;

                }

            }

        }


    }

    private static bool ChangePassword(FDAP01 user, IDbConnection db)
    {

        string? appPassword = Environment.GetEnvironmentVariable("APP_PASSWORDS");
        string? email = Environment.GetEnvironmentVariable("MY_EMAIL");



        MailService ms = new MailService(email, appPassword);

        if (ms.VarifyEmail(user.A01F03))
        {
            try
            {
                string? npass = "";

                while (npass == "" || npass == null)
                {
                    Console.Write("Enter New password : ");
                    npass = Convert.ToString(Console.ReadLine());

                }
                user.A01F04 = npass;

                db.Update<FDAP01>(user);

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
