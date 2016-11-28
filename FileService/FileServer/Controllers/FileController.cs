using System.Threading;
using System.Web.Mvc;
using System.Web;
using System;
using FileServer.Service;
using System.Configuration;

namespace FileServer.Controllers
{
    public class FileController : Controller
    {
        private static IFileService fileService = FileServiceFactory.GetFileService(ConfigurationManager.AppSettings["Mode"]);
        
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Upload()
        {
            try
            {
                ThreadPool.QueueUserWorkItem(UploadFiles);
                ViewBag.Message = "Queued for uploading";
            }
            catch
            {
                ViewBag.Message = "Error uploading the file";
            }

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
