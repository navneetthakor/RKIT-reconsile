using Final_Demo_AvanceCSharp.Business_Logic;
using Final_Demo_AvanceCSharp.Modals.POCOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Demo_AvanceCSharp.Controllers
{
    internal class AuthorController
    {
        private AuthorLogics atl;
        private IDbConnection _db;
        public void MainEvent(IDbConnection db, FDAP01 fdap01)
        {
            atl = new AuthorLogics(db, fdap01);
            _db = db;

            while (true)
            {

            Console.WriteLine("Select the operation : ");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. Get All Books");
            Console.WriteLine("5. Exit");


                int opCode = Convert.ToInt32(Console.ReadLine());
                switch(opCode)
                {
                    case 1:
                        this.AddBook();
                        break;

                    case 2:
                        this.UpdateBook();
                        break;

                    case 3:
                        this.DeleteBook();
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

        private void AddBook()
        {
            FDAP03 newBook = new FDAP03();
            Console.Write("Enter Title : ");
            newBook.A03F02 = Console.ReadLine();
            Console.Write("Enter Description : ");
            newBook.A03F03 = Console.ReadLine();

            atl.PreSave(newBook, Modals.Enums.OppEnum.A);
            atl.ValidateOnSave(Modals.Enums.OppEnum.A);
            atl.Save(Modals.Enums.OppEnum.A);

        }

        private void UpdateBook()
        {
            FDAP03 newBook = new FDAP03();
            Console.Write("Enter Id of Book : ");
            newBook.A03F01 = Convert.ToInt32( Console.ReadLine());

            Console.Write("Enter Title : ");
            newBook.A03F02 = Console.ReadLine();
            Console.Write("Enter Description : ");
            newBook.A03F03 = Console.ReadLine();

            atl.PreSave(newBook, Modals.Enums.OppEnum.U);
            atl.ValidateOnSave(Modals.Enums.OppEnum.U);
            atl.Save(Modals.Enums.OppEnum.U);

        }

        private void DeleteBook()
        {
            FDAP03 newBook = new FDAP03();
            Console.Write("Enter Id of Book : ");
            newBook.A03F01 = Convert.ToInt32(Console.ReadLine());

            atl.PreDelete(newBook.A03F01);
            atl.ValidateOnDelete();
            atl.Delete();
        }
    }
}
