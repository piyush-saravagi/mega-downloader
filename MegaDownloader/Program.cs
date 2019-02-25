using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace MegaDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
            Downloader downloader = new Downloader();
            bool downloadResult = downloader.Download(args[0], args[1]);
            if (downloadResult == true)
                Console.WriteLine("Downloaded successfully.");
            else
                Console.WriteLine("Download failed.");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }

    class Downloader
    {
        /*
         Downloads a file from the url provided to the specified path on the local system.

         Args:
            url: URL of the file to be downloaded
            path: Destination of the file on the local system.

          Returns:
            true if a new file is successfully downloaded, else false. Prints the reason for the failure 
        */
        public bool Download(string url, string path)
        {

            WebClient webClient = new WebClient();

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
                            return false;
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
                return false;
            }

            //Handling download errors
            try
            {
                webClient.DownloadFile(url, path);
            }
            catch (WebException)
            {
                Console.WriteLine("Error downloading file. Please check the url, the path and the network connection specified and try again");
                return false;
            }


            return true;
        }
    }
}
