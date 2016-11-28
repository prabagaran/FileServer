using System.IO;
using System;

namespace FileServer.Service
{
    public class LocalFileService : IFileService
    {
        public void Upload(string fileName, System.IO.Stream stream)
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "uploads")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "uploads"));
            }

            using (var fileStream = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "uploads", fileName), FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
        }
    }
}