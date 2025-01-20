using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;

namespace DBWC
{
    internal class Program
    {
        //MySql connection string 
        static string connectionStr = "Server=127.0.0.1;Database=nk_ormlite_demo;User Id=Admin;Password=gs@123;Port=3306";

        public static void Main(string[] args)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Program.connectionStr))
                {
                    // opening connection
                    conn.Open();

                    //Select query ----
                    Console.WriteLine("Before starting : ");
                    Program.selectExecutor(conn);
                    Console.WriteLine("\n\n");

                    ////Insert query ----
                    Console.WriteLine("Insert Query : ");
                    string insertQuery = "insert into pocoaewp01(P01F02,P01F03,P01F04,P01F05) values(" +
                        "@P01F02,@P01F03,@P01F04,@P01F05);";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        //adding values 
                        //cmd.Parameters.AddWithValue("@P01F01", 5);
                        cmd.Parameters.AddWithValue("@P01F02", "Meet");
                        cmd.Parameters.AddWithValue("@P01F03", "mJ2002");
                        cmd.Parameters.AddWithValue("@P01F04", "meet@rkitsoftware.com");
                        cmd.Parameters.AddWithValue("@P01F05", "4595123685");

                        int affectedRows = cmd.ExecuteNonQuery();
                        Console.WriteLine("affectedRows : " + affectedRows);
                    }

                    //Select query ----
                    Program.selectExecutor(conn);
                    Console.WriteLine("\n\n");

                    // update query ----
                    Console.WriteLine("Update Query : ");
                    string updateQuery = " update pocoaewp01 set P01F03 = @P01F03 where P01F02 = @P01F02";
                    using(MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@P01F03", "MJ1112003");
                        cmd.Parameters.AddWithValue("@P01F02", "Meet");
                        int affectedRows = cmd.ExecuteNonQuery();
                        Console.WriteLine("affectedRows : " + affectedRows);
                    }

                    //Select query ----
                    Program.selectExecutor(conn);
                    Console.WriteLine("\n\n");

                    // delete Query ----
                    Console.WriteLine("Delete Query : ");
                    string deleteQuery = "delete from pocoaewp01 where P01F02 = @P01F02";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@P01F02", "Meet");
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) deleted.");
                    }

                    //Select query ----
                    Program.selectExecutor(conn);
                    Console.WriteLine("\n\n");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }

        public static void selectExecutor(MySqlConnection conn)
        {
            string selectQuery = "select * from pocoaewp01";
            using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("P01F01");
                        string name = reader.GetString("P01F02");

                        Console.WriteLine($"Id : {id}, Name : {name}");
                    }
                }
            }
        }
    }
}