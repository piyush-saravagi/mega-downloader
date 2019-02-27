using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
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



            // If file exists and it should not be replaced, return
            if (File.Exists(path) && !replace)
            {
                Console.WriteLine("File already exists and is not being replaced");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return;
            }

            // File should be downloaded (and replaced if it exists)
            
            // Handling null url
            if (url == null)
            {
                Console.WriteLine("Url cannot be null");
                return;
            }

            Downloader downloader = new Downloader();

            // Calling the Download function might result in a WebException. Catching such exceptions and prompting the users about it
            try
            {
               downloader.Download(args[0], args[1]);
               Console.WriteLine("Downloaded successfully.");
            }
            catch (WebException)
            {
                Console.WriteLine("Error downloading file. Please check the url, the path and the network connection specified and try again");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
