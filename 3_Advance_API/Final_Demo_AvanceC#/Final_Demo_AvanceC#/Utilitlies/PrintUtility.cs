using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Demo_AvanceCSharp.Utilitlies
{
    internal class PrintUtility
    {
        // Helper method to print a single row
        public static void PrintRow(string[] rowValues, int[] columnWidths)
        {
            for (int i = 0; i < rowValues.Length; i++)
            {
                Console.Write(rowValues[i].PadRight(columnWidths[i]) + " | ");
            }
            Console.WriteLine();
        }

        public static void PrintHeader(string[] headerValues, int[] columnWidths)
        {
            for (int i = 0; i < headerValues.Length; i++)
            {
                Console.Write(headerValues[i].PadRight(columnWidths[i]) + " | ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', columnWidths.Sum() + (headerValues.Length - 1) * 3)); // separator line
        }

        public static void PrintData(string[] rowValues, string[] headerValues, int[] columnWidths)
        {
            PrintHeader(headerValues, columnWidths);
            PrintRow(rowValues, columnWidths);
        }
    }
}
