using DotNetEnv;
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

        /// <summary>
        /// Creating table  if not exist
        /// </summary>
        //using (var db = DatabaseService.GetDbConnection())
        //{
        //    db.Open();

        //db.CreateTableIfNotExists<FDAP01>();
        //db.CreateTableIfNotExists<FDAP02>();
        //db.CreateTableIfNotExists<FDAP03>();

        //FDAP01 fdap01 = new FDAP01() { A01F01 = 1 , A01F02 = "Navneet" ,A01F03 = "codewithnavneet@gmail.com", A01F05 = "6353367637"};
        //AdminLogics adm = new AdminLogics(db, fdap01);
        //Response rs = adm.GetAllAuthors();

        //Console.WriteLine("\n\n");
        //adm.GetAllBooks();

        //Console.WriteLine("\n\n");
        //adm.PreDelete(2, WOBEnum.Book);
        //adm.ValidateOnDelete(WOBEnum.Book);
        //adm.Delete(WOBEnum.Book);

        //Console.WriteLine("\n\n");
        //rs = adm.GetAllAuthors();

        //Console.WriteLine("\n\n");
        //adm.GetAllBooks();

        // Author logic ----
        //FDAP01 fdap011 = new FDAP01() { A01F01 =  2};
        //AuthorLogics atl = new AuthorLogics(db, fdap011);

        // add book --
        //FDAP03 fdap03 = new FDAP03() { A03F02 = "Hello", A03F03 = "hhh" };
        //Response rs = atl.PreSave(fdap03, OppEnum.A);
        //if (!rs.IsError) rs = atl.ValidateOnSave(OppEnum.A);
        //if (!rs.IsError) rs = atl.Save(OppEnum.A);

        // update book ---
        //FDAP03 fdap03 = new FDAP03() { A03F01 = 17, A03F02 = "NkTheBoss", A03F03 = "nk" };
        //Response rs = atl.PreSave(fdap03, OppEnum.U);
        //if (!rs.IsError) rs = atl.ValidateOnSave(OppEnum.U);
        //if (!rs.IsError) rs = atl.Save(OppEnum.U);

        //Console.WriteLine("\n\n");
        //adm.GetAllBooks();

        // delete book ---
        //rs = atl.PreDelete(16);
        //if (!rs.IsError) rs = atl.ValidateOnDelete();
        //if (!rs.IsError) rs = atl.Delete();

        //Console.WriteLine("\n\n");
        //adm.GetAllBooks();

        //    // read books ---
        //    Console.WriteLine("\n\n");
        //    Response rs = atl.GetAllBooks();

        //    // change password --
        //    ChangePassword(adm._admin, db);
        //}


    }

    private static bool ChangePassword(FDAP01 user, IDbConnection db)
    {

        string? appPassword = Environment.GetEnvironmentVariable("APP_PASSWORDS");
        string? email = Environment.GetEnvironmentVariable("MY_EMAIL");



        MailService ms = new MailService(email, appPassword);

        if(ms.VarifyEmail(user.A01F03))
        {
            try
            {
                string? npass = "";

                while(npass == "" || npass == null)
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
