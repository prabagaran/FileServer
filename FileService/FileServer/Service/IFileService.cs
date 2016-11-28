using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Service
{
    public interface IFileService
    {
        void Upload(string fileName, System.IO.Stream stream);
    }
}
