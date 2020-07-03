using Nito.AsyncEx;
using System.IO;
using System.Threading.Tasks;

namespace PuppetPdf
{
    class Program
    {
        static void Main()
        {
            AsyncContext.Run(MainAsync);
        }

        private static async Task MainAsync()
        {
            // async issues
            // https://github.com/kblok/puppeteer-sharp/issues/515


            //  https://github.com/kblok/puppeteer-sharp/blob/master/lib/PuppeteerSharp/Launcher.cs#L165

            //await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            //var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            //{
            //    Headless = true,
            //    ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
            //    IgnoredDefaultArgs = new string[] { "--disable-extensions" },
            //    IgnoreDefaultArgs=true,

            //});
            //var page = await browser.NewPageAsync();
            //await page.GoToAsync("http://www.google.com");
            //await page.PdfAsync("C:\\test.pdf");

            //return; 


            // Generate some mock data
            var data = new MyDocumentData
            {
                Year = "2019",
            };

            var generator = new MyDocumentGenerator();
            var pdfBytes = await generator.Generate(data);

            File.WriteAllBytes(@"C:\output.pdf", pdfBytes);
        }
    }
}
