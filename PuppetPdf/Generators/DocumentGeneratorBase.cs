using System;
using System.IO;

namespace PuppetPdf
{
    public class DocumentGeneratorBase
    {
        const string docTemplateFolder = "DocumentTemplates";
        
        protected virtual string GetDocumentPath(string filename)
        {
            var root = GetRootPath();
            var fullPath = Path.Combine(root, docTemplateFolder, filename);

            return fullPath;
        }

        protected string GetRootPath()
        {
            var assemblyPath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            var path = Path.GetDirectoryName(assemblyPath);

            return path;
        }

        internal string ReadFileText(string filename)
        {
            var path = GetDocumentPath(filename);
            return File.ReadAllText(path);
        }
    }
}
