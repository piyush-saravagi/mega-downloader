using System;
using System.Net;
using System.IO;

namespace DownloaderLibrary
{
    public class Downloader
    {
        /*
         Downloads a file from the url provided to the specified path on the local system.

         Args:
            url: URL of the file to be downloaded
            path: Destination of the file on the local system.

          Returns:
            No return value. Exceptions are passed on to be handled by the caller
        */
        public bool Download(string url, string path, bool replace)
        {
            // Question: Is it a good practice to return some value (boolean, for example) to indicate the success or failure of the function?
            // My method returns nothing if it is successful and passes exceptions to the caller.
            // If an exception is caught by the caller, the caller can know that the operation has failed else it was successful

            // If file exists and it should not be replaced, return
            if (File.Exists(path) && !replace)
            {
                Console.WriteLine("File already exists at " + path + " and is not being replaced");
                return false;
            }

            // File should be downloaded (and replaced if it exists)

            // Handling null url
            if (url == null)
            {
                Console.WriteLine("Url cannot be null");
                return false;
            }


            WebClient webClient = new WebClient();

            try
            {
                webClient.DownloadFile(url, path);
            }
            finally
            {
                webClient.Dispose();
            }

        }


        /*
         * Overloaded function to download multiple files
         */
        public void Download(string[] urlList, string[] pathList, bool replace)
        {

            for (int i = 0; i < urlList.Length; i++)
            {

                bool downloadSuccess = false;
                // Calling the Download function might result in a WebException. Catching such exceptions and prompting the users about it
                // Try block ensures that even if one download fails, the rest of the downloads can be completed
                try
                {
                    downloadSuccess = Download(urlList[i], pathList[i], replace);
                }
                catch (WebException)
                {
                    Console.WriteLine("Error downloading file. Please check the url, the path and the network connection specified and try again");
                    downloadSuccess = false;
                }

                if (downloadSuccess == true)
                    Console.WriteLine("Successfully downloaded: " + urlList[i]);
                else
                    Console.WriteLine("Error downloading: " + urlList[i]);
            }
        }
    }
}
