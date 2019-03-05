using System.Net;
using System;

namespace ConsoleApp2
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile(args[0], args[1]);
            }
            catch (WebException)
            {
                Console.WriteLine("Error");
            }
            Console.Write("Done");
            Console.ReadKey();
        }
    }
}
