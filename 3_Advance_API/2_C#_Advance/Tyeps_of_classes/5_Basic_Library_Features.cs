using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.CSharp;

namespace AdvanceAPI.BLF
{
    internal class Tester
    {
        internal static void TestNow()
        {
            //-> Majority of the BLs we already seen like 
            //- Collection 
            //- Collection.Generic
            //- Linq (upcoming)
            //- IO 


            //few which are lefts are below ----
            //1) System.Globalization : helps in cultural conversions in globalized application
            //-> like data, time, currencies etc...
            var enIn = new CultureInfo("en-IN");
            Console.WriteLine(enIn.DateTimeFormat.ShortDatePattern); // dd - MM - yyyy

            var enUs = new CultureInfo("en-US");
            Console.WriteLine(enUs.DateTimeFormat.ShortDatePattern); // M/d/yyyy


            // 2) System.Net namespace : enables network based communication.
            WebClient webClient = new WebClient();
            string githubPage = webClient.DownloadString("https://www.github.com/navneetthakor");
            Console.WriteLine("Github Page : " + githubPage.Substring(0, 500));
        }
    }
}