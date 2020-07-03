using System;
using System.IO;

namespace PuppetPdf
{
    public class DocumentGeneratorBase
    {
        protected virtual string GetDocumentPath(string filename)
        {
            var root = GetRootPath();
            var docTemplateFolder = "DocumentTemplates";
            var fullPath = Path.Combine(root, docTemplateFolder, filename);

            return fullPath;
        }

        protected string GetRootPath()
        {
            //var path = System.Web.Hosting.HostingEnvironment.MapPath("~");
            string path = null;
            if (path == null)
            {
                path = new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
                path = Path.GetDirectoryName(path);
            }

            return path;
        }

        internal string ReadFileText(string filename)
        {
            var path = GetDocumentPath(filename);
            return File.ReadAllText(path);
        }
    }
}