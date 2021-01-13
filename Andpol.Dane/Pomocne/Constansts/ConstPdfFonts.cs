using iText.Kernel.Font;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Andpol.Dane.Pomocne.PdfGen
{
    public static class ConstPdfFonts
    {
        public static PdfFont ExoRegular { get {
                return PdfFontFactory.CreateFont(new Uri(HostingEnvironment.MapPath("~") + "\\Fonts\\Exo-Regular.otf").LocalPath, "Identity-H", true);
            }
        }
        public static PdfFont ExoBold
        {
            get
            {
                return PdfFontFactory.CreateFont(new Uri(HostingEnvironment.MapPath("~") + "\\Fonts\\Exo-Bold.otf").LocalPath, "Identity-H", true);
            }
        }

        public static PdfFont ExoExtraBold
        {
            get
            {
                return PdfFontFactory.CreateFont(new Uri(HostingEnvironment.MapPath("~") + "\\Fonts\\Exo-ExtraBold.otf").LocalPath, "Identity-H", true);
            }
        }

        public static PdfFont ExoThin
        {
            get
            {
                return PdfFontFactory.CreateFont(new Uri(HostingEnvironment.MapPath("~") + "\\Fonts\\Exo-Thin.otf").LocalPath, "Identity-H", true);
            }
        }

    }
}