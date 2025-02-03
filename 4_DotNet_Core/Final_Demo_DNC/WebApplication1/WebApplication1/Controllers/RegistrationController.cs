using Final_Demo_AvanceCSharp.Business_Logic;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Utilitlies;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Demo_AvanceCSharp.Controllers
{
    internal class RegistrationController
    {

        public static void MainEvent(IDbConnection db)
        {
            Response response = new Response();

            try
            {
                Console.WriteLine("------- Welcome To Registraion Module ------------");
                FDAP01 newUser = new FDAP01();
                #region Taking input
                Console.Write("Name : ");
                newUser.A01F02 = Console.ReadLine();
                Console.Write("Email : ");
                newUser.A01F03 = Console.ReadLine();
                Console.Write("Password : ");
                newUser.A01F04 = Console.ReadLine();
                Console.Write("Phone : ");
                newUser.A01F05 = Console.ReadLine();
                #endregion


                Response rs = AuthorLogics.RegisterAuthor(newUser, db);
                if (rs.IsError) throw new Exception(rs.Message);

               Console.WriteLine("\nRegistration successful!!\n");
                return;
            }
            catch (Exception ex)
            {

                Console.WriteLine("\n\nException : " + ex.Message + "\n\n");
                return;
            }
        }
    }
}
