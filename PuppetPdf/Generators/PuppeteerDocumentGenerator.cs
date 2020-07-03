using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.Threading.Tasks;

namespace PuppetPdf
{
    public class PuppeteerDocumentGenerator : DocumentGeneratorBase
    {
        public async Task<Byte[]> Generate(string html)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,

                ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
                IgnoredDefaultArgs = new string[] { "--disable-extensions" },
                IgnoreDefaultArgs = true,

            });

            using (var page = await browser.NewPageAsync())
            {
                await page.SetContentAsync(html, new NavigationOptions
                {
                    WaitUntil = new WaitUntilNavigation[]
                                        {
                        WaitUntilNavigation.Load,
                        WaitUntilNavigation.DOMContentLoaded,
                        WaitUntilNavigation.Networkidle0
                    }
                });

                //await page.AddStyleTagAsync(new AddTagOptions
                //{
                //    Path = GetDocumentPath("RecommendationHtmlVersion/styles.css")
                //});
                await page.ScreenshotDataAsync();

                var pdfData = await page.PdfDataAsync(new PdfOptions
                {
                    PrintBackground = true,
                    MarginOptions = new MarginOptions
                    {
                        Top = "1.5cm",
                        Bottom = "1.5cm"
                    },
                    DisplayHeaderFooter = true,
                    HeaderTemplate = "<div></div>",
                    FooterTemplate = "<div style='font-size:8px; text-align:center; display:block; width:100%;'><span class='pageNumber' style='display:block;text-align:center; font-color:#6f6e6c;'></span></div>",
                    Format = PaperFormat.A4
                });

                browser.Dispose();
                return pdfData;
            }
        }
    }
}
