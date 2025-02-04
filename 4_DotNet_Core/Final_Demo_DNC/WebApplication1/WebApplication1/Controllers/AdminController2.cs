using Final_Demo_AvanceCSharp.Business_Logic;
using Final_Demo_AvanceCSharp.Modals.Enums;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using System;
using System.Data;


namespace Final_Demo_AvanceC_.Controllers
{
    internal class AdminController2
    {
        private AdminLogics atl;
        private IDbConnection _db;

        public void MainEvent(IDbConnection db, FDAP01 fdap01)
        {
            atl = new AdminLogics(db, fdap01);
            _db = db;

            while (true)
            {

                Console.WriteLine("\n\nSelect the operation : ");
                Console.WriteLine("1. Delete Book");
                Console.WriteLine("2. Delete Author");
                Console.WriteLine("3. Get All Authors");
                Console.WriteLine("4. Get All Books");
                Console.WriteLine("5. Exit");


                int opCode = Convert.ToInt32(Console.ReadLine());
                switch (opCode)
                {
                    case 1:
                        this.DeleteBook();
                        break;

                    case 2:
                        this.DeleteAuthor();
                        break;

                    case 3:
                        atl.GetAllAuthors();
                        break;
                    case 4:
                        atl.GetAllBooks();
                        break;

                    case 5:
                        return;
                    default:
                        Console.WriteLine("\nSelect appropriate option\n");
                        break;
                }
            }

        }

        private void DeleteBook()
        {
            FDAP03 newBook = new FDAP03();
            Console.Write("Enter Id of Book : ");
            newBook.A03F01 = Convert.ToInt32(Console.ReadLine());

            atl.PreDelete(newBook.A03F01, WOBEnum.Book);
            atl.ValidateOnDelete(WOBEnum.Book);
            atl.Delete(WOBEnum.Book);
        }

        private void DeleteAuthor()
        {
            FDAP03 newBook = new FDAP03();
            Console.Write("Enter Id of Author : ");
            newBook.A03F01 = Convert.ToInt32(Console.ReadLine());

            atl.PreDelete(newBook.A03F01, WOBEnum.Author);
            atl.ValidateOnDelete(WOBEnum.Author);
            atl.Delete(WOBEnum.Author);
        }
    }
}
