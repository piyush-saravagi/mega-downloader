using System;
using System.Net;
using DownloaderLibrary;

namespace MegaDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 

            string url = args[0];
            string path = args[1];
            bool replace = false;
            if (args.Length > 2 && args[2] == "r")
                replace = true;


            Downloader downloader = new Downloader();

            // Calling the Download function might result in a WebException. Catching such exceptions and prompting the users about it
            bool downloadSuccess = false;
            try
            {
                downloadSuccess = downloader.Download(args[0], args[1], replace);
            }
            catch (WebException)
            {
                Console.WriteLine("Error downloading file. Please check the url, the path and the network connection specified and try again");

            }

            if (downloadSuccess)
                Console.WriteLine("Successfully downloaded: " + url);
            else
                Console.WriteLine("Error downloading: " + url);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
