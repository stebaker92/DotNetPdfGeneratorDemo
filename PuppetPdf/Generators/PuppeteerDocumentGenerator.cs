using PuppeteerSharp;
using PuppeteerSharp.Media;
using System.Threading.Tasks;

namespace PuppetPdf
{
    public class PuppeteerDocumentGenerator : DocumentGeneratorBase
    {
        public async Task<byte[]> Generate(string html)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,

                // If needed, we can specify a specific version of Chrome
                //ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
                //IgnoredDefaultArgs = new string[] { "--disable-extensions" },
                //IgnoreDefaultArgs = true,

            });

            using (var page = await browser.NewPageAsync())
            {
                await page.SetContentAsync(html);

                var pdfData = await page.PdfDataAsync(new PdfOptions
                {
                    MarginOptions = new MarginOptions
                    {
                        Top = "1.5cm",
                        Bottom = "1.5cm"
                    },
                });

                browser.Dispose();
                return pdfData;
            }
        }
    }
}
