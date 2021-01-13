using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Andpol.Dane.DTO;
using ZuzycieMaterialu.Zuzycie;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Net.Http.Headers;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.IO.Image;
using System.Web.Hosting;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;

namespace Andpol.Dane.Pomocne
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        //public ProstokatParent Get()
        //{

        //    List<ProstokatBaseClass> obszycia = new List<ProstokatBaseClass>();
        //    obszycia.Add(new ProstokatBaseClass(110, 50));
        //    obszycia.Add(new ProstokatBaseClass(40, 40));
        //    obszycia.Add(new ProstokatBaseClass(250, 30));
        //    obszycia.Add(new ProstokatBaseClass(110, 5));
        //    obszycia.Add(new ProstokatBaseClass(170, 110));
        //    obszycia.Add(new ProstokatBaseClass(110, 5));
        //    obszycia.Add(new ProstokatBaseClass(210, 65));
        //    obszycia.Add(new ProstokatBaseClass(170, 120));
        //    obszycia.Add(new ProstokatBaseClass(60, 65));
        //    obszycia.Add(new ProstokatBaseClass(100, 50));
        //    obszycia.Add(new ProstokatBaseClass(100, 25));
        //    obszycia.Add(new ProstokatBaseClass(80, 50));
        //    obszycia.Add(new ProstokatBaseClass(80, 50));
        //    obszycia.Add(new ProstokatBaseClass(120, 125));

        //    ProstokatBaseClass prostokatBaza = new ProstokatBaseClass(1200, 110);
        //    ProstokatParent pBaza = new ProstokatParent(prostokatBaza, obszycia);

        //    return pBaza;
        //}

        
        //public HttpResponseMessage GetValues()
        //{


            //            MemoryStream ms = new MemoryStream();

            //            var pdfWriter = new PdfWriter(ms);
            //            var pdf = new PdfDocument(pdfWriter);

            ////            var fBoldItalic = PdfFontFactory.CreateFont(FontConstants.TIMES, PdfEncodings.IDENTITY_H, true);
            //            var pg = PageSize.A4;
            //            var doc = new Document(pdf, pg);
            //            var width = pg.GetWidth()- (doc.GetRightMargin() + doc.GetLeftMargin());

            //            var logoImgUri = new Uri(HostingEnvironment.MapPath("~") +"\\Images\\andpolLogo.png");
            //            var page = pdf.AddNewPage(pg);


            //            Image logoImg = new Image(ImageDataFactory.Create(logoImgUri));
            //            TabStop tabSrodek = new TabStop(width/2, iText.Layout.Properties.TabAlignment.CENTER);
            //            TabStop tabDoPrawej = new TabStop(width, iText.Layout.Properties.TabAlignment.RIGHT);



            //            Paragraph p = new Paragraph();
            //            //          p.SetFont(fBoldItalic);
            //            //            p.SetFixedPosition(0,pg.GetHeight()-30,pg.GetWidth());
            //            //           p.SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
            //            // p.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            //            p.AddTabStops(tabDoPrawej)
            //                .Add(new Tab())
            //                .Add($"{DateTime.Now}, I coś jeszcze więcej ! ");

            //            doc.Add(p);

            //            //var canv = new PdfCanvas(page);
            //            //canv.MoveTo((double)doc.g(), 0)
            //            //    .LineTo((double)p.GetHeight(), width)
            //            //    .Stroke();





            //            doc.Add(new Paragraph()
            //                .AddTabStops(tabSrodek)
            //                .Add(new Tab())
            //                .Add("Druga linia, poniżej !")
            //                .SetFontColor(Color.RED)
            //                .SetBold()
            //                .SetFontSize(24));



            //            //doc.Add(new Paragraph($"ok, utworzone o {DateTime.Now}").SetFont(fBoldItalic)).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);


            //                //.SetWidth(pageSizeDefault.GetWidth());
            ////                .Add(logoImg);
            //            //            ms.Position = 0;


            //            var c = new PdfCanvas(page);
            //            c.SaveState();
            //            c.ConcatMatrix(1, 0, 0, 1, pg.GetWidth() / 2, pg.GetHeight() / 2);
            //            c.SetLineJoinStyle(PdfCanvasConstants.LineJoinStyle.ROUND);

            //            //c.SetLineWidth(4.2f);
            //            c.MoveTo(-(pg.GetWidth() / 2 - 50), 0)
            //                .LineTo(pg.GetWidth() / 2 - 50, 0)
            //                .SetLineWidth(6.5f)
            //                .SetStrokeColorRgb(1f,0.51f,0.51f)
            //                .Stroke();

            //            c.BeginText();


            //            doc.Close();


            //var ms = Pomocne.PdfGen.PdfGen.FakturaSprzedazy();

            //HttpResponseMessage result = new HttpResponseMessage();
            //result.StatusCode = HttpStatusCode.OK;
            //result.Content = new ByteArrayContent(ms.GetBuffer());
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement")
            //{
            //    FileName=$"pdfTest.pdf",
            //};
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");



            //return result;

        //}



        // GET api/values/5
        public IHttpActionResult Get(int id)
        {


            //db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { });
            //db.Users.Add(new ApplicationUser() { UserName = "kjl" });
            //db.SaveChanges();


            return Ok();
        }

        // POST api/values
        public ProstokatParent Post([FromBody]ProstokatDoObliczenia pBaza)
        {
            List<ProstokatBaseClass> doSprawdzenia = new List<ProstokatBaseClass>();
            foreach (var item in pBaza.ListaDoUlozenia)
            {
                doSprawdzenia.Add(new ProstokatBaseClass(item.Dlugosc, item.Szerokosc));
            }
            ProstokatParent baza = new ProstokatParent(new ProstokatBaseClass(pBaza.Dlugosc, pBaza.Szerokosc), doSprawdzenia, true);


            return baza;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
