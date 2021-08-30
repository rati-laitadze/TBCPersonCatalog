using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonCatalog.Web.Helpers
{
    public static class ImageFilesHelpers
    {
        public static string UploadFolderPhysicalPath = null;

        public static string GetUploadedFilePhysicalPath(string Filename)
        {
            return string.IsNullOrWhiteSpace(Filename) ? null : $"{UploadFolderPhysicalPath}{Filename}";
        }

    }
}
