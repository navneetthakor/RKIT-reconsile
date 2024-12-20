
using System;
using System.Data;

//DataTable: in-memory tabular format data (illution of DBMS)

//columns: DataColumn 
//rows: DataRow

namespace MyDataTble
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("company", typeof(string));

            //adding data 
            table.Rows.Add(1, "Aman", "ISRO");
            table.Rows.Add(2, "Deep", "Zeus Learning");

            //adding primary key constrain 
            table.PrimaryKey = new DataColumn[] {table.Columns["id"]};
                //-> unfare operation happen then it throw exception

            //iterating over table 
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"id : {row["id"]}, name : {row["name"]}, company : {row["company"]}");
            }

            //filtering the table
            DataRow[] filterRows = table.Select("company = 'ISRO'");
            foreach (DataRow row in filterRows)
            {
                Console.WriteLine($"id : {row["id"]}, name : {row["name"]}, company : {row["company"]}");
            }

            //Updating table entry
            table.Rows[0]["name"] = "Ronak";

            // Deleting row
            table.Rows[0].Delete(); // still not deleted, just made hidden at the moment

            // Save current state
            table.AcceptChanges(); // accepts all operations and chnages state of rows to 'unchage'


            //to clear the table 
            table.Clear();
        }
    }
}
