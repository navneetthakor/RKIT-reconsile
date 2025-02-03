using Final_Demo_AvanceCSharp.Controllers;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using Final_Demo_AvanceCSharp.Utilitlies;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Demo_AvanceC_.Controllers
{
    internal class LoginController
    {
        public static void MainEvent( IDbConnection db)
        {
            A02F01Values typeOfUser;
            Response response = new Response();

            try
            {
                Console.WriteLine("\n\n--------- Login Module ---------------\n\n");

                while (true)
                {
                    Console.WriteLine("What type of Login you want?");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. Author");
                    Console.WriteLine("3. Exit");
                    int touu = Convert.ToInt32(Console.ReadLine());

                    if (touu == 1)
                    {
                        typeOfUser = A02F01Values.Admin;
                        break;
                    }
                    else if (touu == 2)
                    {
                        typeOfUser = A02F01Values.Author;
                        break;
                    }
                    else if(touu == 3)
                    {
                        Environment.Exit(0);
                    }
                }

                #region Taking input
                Console.Write("Email : ");
                string email = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();
                #endregion

                if (typeOfUser == A02F01Values.Admin)
                {
                    FDAP01? currentUser = db.Single<FDAP01>(x => x.A01F03 == email);
                    if(currentUser == null) throw new Exception("Admin with given email not exists");

                    FDAP02 isItAdmin = db.Single<FDAP02>(x => x.A02F01 == currentUser.A01F01);
                    if ( isItAdmin.A02F02 != 0 || currentUser.A01F04 != password) throw new Exception("Password is not valid or You are not admin");

                    Console.WriteLine($"\n\n***Welcom Admin : {currentUser.A01F02}***\n\n");
                    new AdminController().MainEvent(db, currentUser);
                }
                else
                {
                    FDAP01? currentUser = db.Single<FDAP01>(x => x.A01F03 == email);
                    if (currentUser == null) throw new Exception("USer with given email not exists");

                    if (currentUser.A01F04 != password) throw new Exception("Password is not valid");

                    Console.WriteLine($"***Welcom Author : {currentUser.A01F02}***");
                    new AuthorController().MainEvent(db, currentUser);
                }

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
                return;
            }
        }
    }
}
