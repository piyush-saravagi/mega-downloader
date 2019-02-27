using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace DownloaderLibrary {
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
        public void Download(string url, string path)
        {
            // Question: Is it a good practice to return some value (boolean, for example) to indicate the success or failure of the function?
            // My method returns nothing if it is successful and passes exceptions to the caller.
            // If an exception is caught by the caller, the caller can know that the operation has failed else it was successful

            WebClient webClient = new WebClient();

            try { 
                webClient.DownloadFile(url, path);
            }
            finally
            {
                webClient.Dispose();
            }
        }
    }
}
