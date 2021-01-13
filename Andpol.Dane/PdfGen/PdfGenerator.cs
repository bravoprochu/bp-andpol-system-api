using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Hosting;

namespace Andpol.Dane.PdfGen
{
    public static class PdfGenerator
    {
        public static HttpResponseMessage FakturaSprzedazy(FakturaSprzedazyDTO fvDTO) {

            MemoryStream ms = new MemoryStream();

            var pdfWriter = new PdfWriter(ms);
            var pdf = new PdfDocument(pdfWriter);

            //            var fBoldItalic = PdfFontFactory.CreateFont(FontConstants.TIMES, PdfEncodings.IDENTITY_H, true);
            var pg = PageSize.A4;
            var doc = new Document(pdf, pg);
            var width = pg.GetWidth() - (doc.GetRightMargin() + doc.GetLeftMargin());

            var logoImgUri = new Uri(HostingEnvironment.MapPath("~") + "\\Images\\andpolLogo.png");
            var page = pdf.AddNewPage(pg);


            Image logoImg = new Image(ImageDataFactory.Create(logoImgUri));
            TabStop tabSrodek = new TabStop(width / 2, iText.Layout.Properties.TabAlignment.CENTER);
            TabStop tabDoPrawej = new TabStop(width, iText.Layout.Properties.TabAlignment.RIGHT);



            Paragraph p = new Paragraph();
            //          p.SetFont(fBoldItalic);
            //            p.SetFixedPosition(0,pg.GetHeight()-30,pg.GetWidth());
            //           p.SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
            // p.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            p.AddTabStops(tabDoPrawej)
                .Add(new Tab())
                .Add($"{DateTime.Now}, I coś jeszcze więcej ! ");

            doc.Add(p);

            //var canv = new PdfCanvas(page);
            //canv.MoveTo((double)doc.g(), 0)
            //    .LineTo((double)p.GetHeight(), width)
            //    .Stroke();





            doc.Add(new Paragraph()
                .AddTabStops(tabSrodek)
                .Add(new Tab())
                .Add("Druga linia, poniżej !")
                .SetFontColor(Color.RED)
                .SetBold()
                .SetFontSize(24));



            //doc.Add(new Paragraph($"ok, utworzone o {DateTime.Now}").SetFont(fBoldItalic)).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);


            //.SetWidth(pageSizeDefault.GetWidth());
            //                .Add(logoImg);
            //            ms.Position = 0;


            var c = new PdfCanvas(page);
            c.SaveState();
            c.ConcatMatrix(1, 0, 0, 1, pg.GetWidth() / 2, pg.GetHeight() / 2);
            c.SetLineJoinStyle(PdfCanvasConstants.LineJoinStyle.ROUND);

            //c.SetLineWidth(4.2f);
            c.MoveTo(-(pg.GetWidth() / 2 - 50), 0)
                .LineTo(pg.GetWidth() / 2 - 50, 0)
                .SetLineWidth(6.5f)
                .SetStrokeColorRgb(1f, 0.51f, 0.51f)
                .Stroke();

            c.BeginText();


            doc.Close();



            HttpResponseMessage result = new HttpResponseMessage();
            result.StatusCode = HttpStatusCode.OK;
            result.Content = new ByteArrayContent(ms.GetBuffer());
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement")
            {
                FileName = $"pdfTest.pdf",
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");



            return result;



        }
    }
}