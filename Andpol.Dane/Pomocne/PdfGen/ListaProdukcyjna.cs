using Andpol.Dane.ModelsDTO;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.PdfGen
{
    public static partial class PdfGen
    {
        public static Document ListaProdukcyjna(PdfWriter pdfWriter, List<ZamowienieListaDTO> listaZamowien)
        {
            var pdf = new PdfDocument(pdfWriter);

            var doc = new Document(pdf, PageSize.A4.Rotate());
            doc.SetMargins(30, 20, 40, 20);


            var tbl = new Table(new float[] { 10, 50, 40, 50, 20 })
                .SetFixedLayout();

            var fontSizeDef = 6;

            tbl.AddHeaderCell(HeaderCell("dupa", fontSizeDef, 1, 1));
            tbl.AddHeaderCell(HeaderCell("dupa", fontSizeDef, 1, 1));
            tbl.AddHeaderCell(HeaderCell("dupa", fontSizeDef, 1, 1));
            tbl.AddHeaderCell(HeaderCell("dupa", fontSizeDef, 1, 1));
            tbl.AddHeaderCell(HeaderCell("dupa", fontSizeDef, 1, 1));

            doc.Add(tbl);


            doc.Close();


            return doc;
        }

    }
}
