using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;

using System.Reflection.Metadata;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }   
        public IActionResult StaticPdfReport()
        {
            string guid = Guid.NewGuid().ToString().Substring(0, 3);
            int counter = 1;
            string fileName = $"dosya{counter}_{guid}.pdf";
            counter++;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + fileName);
            var stream = new FileStream(path, FileMode.Create);

            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            var paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/" + fileName, "application/pdf",fileName);

        }
        public IActionResult StaticCustomerReport()
        {
            string guid = Guid.NewGuid().ToString().Substring(0,3);
            int counter = 1; 
            string fileName = $"dosya{counter}_{guid}.pdf";
            counter++;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + fileName);
            var stream = new FileStream(path, FileMode.Create);

            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            PdfPTable pdfTable = new PdfPTable(3);

            pdfTable.AddCell("Misafir Adı");
            pdfTable.AddCell("Misafir Soyadı");
            pdfTable.AddCell("Misafir TC");

            pdfTable.AddCell("Eylül");
            pdfTable.AddCell("Yücedağ");
            pdfTable.AddCell("11111111111");

            pdfTable.AddCell("kemal");
            pdfTable.AddCell("Yıldırım");
            pdfTable.AddCell("22222222222");

            pdfTable.AddCell("Mehmet");
            pdfTable.AddCell("Yücedağ");
            pdfTable.AddCell("33333333333");
            document.Add(pdfTable);

            document.Close();
            return File("/pdfreports/" + fileName, "application/pdf", fileName);
        }
    }
}
