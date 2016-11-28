using System.Threading;
using System.Web.Mvc;
using System.Web;
using System;
using FileServer.Service;

namespace FileServer.Controllers
{
    public class FileController : Controller
    {
        private static IFileService fileService = FileServiceFactory.GetFileService("Azure");
        
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Upload()
        {
            ThreadPool.QueueUserWorkItem(UploadFiles);
            return View();
        }
        
        public void UploadFiles(Object obj)
        {
            try
            {
                HttpPostedFileBase filePosted = Request.Files[0];
                if (filePosted != null && filePosted.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(filePosted.FileName);
                    var inputStream = filePosted.InputStream;
                    fileService.Upload(fileName, inputStream);
                }
            }
            catch
            {

            }
        }
    }
}
