using DotNetEnv;
using Final_Demo_AvanceCSharp.Utilities;
using System;

class Program
{
    static void Main(string[] args)
    {
        
    }

    private static bool ChangePassword()
    {
        Env.Load("D:\\1\\rkit\\reconsile\\3_Advance_API\\Final_Demo_AvanceC#\\Final_Demo_AvanceC#\\.env");

        string? appPassword = Environment.GetEnvironmentVariable("APP_PASSWORDS");
        string? email = Environment.GetEnvironmentVariable("MY_EMAIL");

        MailService ms = new MailService(email, appPassword);

        if(ms.VarifyEmail("codewithNaveet@gmail.com"))
        {
            try
            {

                // logic to change Password
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
