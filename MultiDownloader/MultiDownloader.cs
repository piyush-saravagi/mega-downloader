using System;
using DownloaderLibrary;
namespace MultiDownloader
{
    class MultiDownloader
    {
        static void Main(string[] args)
        {
            /* The follwing arguments are expected 
             * argument 0: Number of files to be downloaded (n)
             * next n arguments represent the urls of the files to be downloaded
             * next n arguments are the respective paths where the files need to be saved
             * this is follwed by an optional argument to indicate whether file replacement should take place
             */

            int numOfDownloads = Convert.ToInt32(args[0]);
            string[] urlList = new string[numOfDownloads];
            string[] pathList = new string[numOfDownloads];
            for (int i = 0; i < numOfDownloads; i++)
            {
                urlList[i] = args[i + 1];
                pathList[i] = args[i + 1 + numOfDownloads];
            }

            bool replace = false;
            if (args.Length > 1 + numOfDownloads + numOfDownloads && args[args.Length - 1] == "r")
            {
                //optional argument present for file replacement 
                replace = true;
            }

            Downloader downloader = new Downloader();
            downloader.Download(urlList, pathList, replace);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
