using System.Threading.Tasks;

namespace PuppetPdf
{
    class MyDocumentGenerator : DocumentGeneratorBase
    {
        private const string Filename = "MyDocument.html";

        public async Task<byte[]> Generate(MyDocumentData data)
        {
            var html = string.Empty;
            html = ReadFileText(Filename);
            html = ReplacePlaceholders(html, data);
            var puppeteer = new PuppeteerDocumentGenerator();
            var pdfBytes = await puppeteer.Generate(html);
            return pdfBytes;
        }

        private string ReplacePlaceholders(string html, MyDocumentData data)
        {
            html = html.Replace("%%Year%%", data.Year);

            // Puppeteer cannot load local images, either used hosted images or embed them templates / embed them dynamically

            return html;
        }
    }
}
