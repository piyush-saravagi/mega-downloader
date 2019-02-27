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

            // Flag for prompting the user about an exisiting file
            bool fileReplacePrompt = true;

            do
            {
                //Checking if file exists
                if (File.Exists(path))
                {
                    Console.WriteLine("File already exists. Do you want to replace the existing file? Y/N");
                    char keyPressed = Console.ReadLine()[0];
                    switch (keyPressed)
                    {
                        case 'N':
                        case 'n':
                            return;
                        case 'Y':
                        case 'y':
                            fileReplacePrompt = false;
                            break;
                        default:
                            Console.WriteLine("Invalid key pressed, please enter Y for yes and N for no");
                            break;
                    }
                }
                else
                {
                    // File does not exist, no prompt needed
                    fileReplacePrompt = false;
                }
            }
            while (fileReplacePrompt);

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
