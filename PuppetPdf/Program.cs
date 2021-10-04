using System.IO;
using System.Threading.Tasks;

namespace PuppetPdf
{
    public class Program
    {
        public static async Task Main()
        {
            // Generate some mock data to inject
            var data = new MyDocumentData
            {
                Year = "2019",
            };
            
            var generator = new MyDocumentGenerator();
            var pdfBytes = await generator.Generate(data);

            File.WriteAllBytes(@"output.pdf", pdfBytes);
        }
    }
}
