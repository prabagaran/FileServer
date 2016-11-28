using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileServer.Service
{
    public class FileServiceFactory
    {
        public static IFileService GetFileService(string mode)
        {
            if(mode == "Local")
            {
                return new LocalFileService();
            }

            if(mode == "Azure")
            {
                return new AzureFileService();
            }

            return null;
        }
    }
}