using System;

/*
 * content about : Exception handling
 */

//Exception hanling mechanism can only handle runtime erros called : Exception
//folowwing are important keywords 
/*
try
catch
finally
throw
*/

namespace MyException
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				int turn = Convert.ToInt32(Console.ReadLine());

				if (turn == 0)
				{
					throw new Exception("my Custom Exception");
				}
				else if (turn == 1)
				{
					int divisor = 0;
					Console.WriteLine(turn/divisor);

				}

				Console.WriteLine("try completed\n");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("catch completed\n");
			}
			finally
			{
				//mainly use to realize resource aquire in try block 
				Console.WriteLine("finallly called");
			}
		}
	}
}