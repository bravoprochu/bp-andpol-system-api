using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Splitting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using iText.IO.Font.Otf;
using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using iText.Kernel.Events;

namespace Andpol.Dane.Pomocne.PdfGen
{
    public static partial class PdfGen
    {
        public static MemoryStream FakturaSprzedazy(FakturaSprzedazyDTO fv, List<Kontrahent> kontr)
        {
            MemoryStream ms = new MemoryStream();

            var pdfWriter = new PdfWriter(ms);
            var pdf = new PdfDocument(pdfWriter);

            var doc = new Document(pdf, PageSize.A4);
            doc.SetMargins(30, 20, 40, 20);

            var logoImgUri = new Uri(HostingEnvironment.MapPath("~") + "\\Images\\andpolLogo.png");
            Image logoImg = new Image(ImageDataFactory.Create(logoImgUri));
            

            doc.SetFont(ConstPdfFonts.ExoRegular);

            var tblNaglowek = new Table(new float[] { 2,2,1,2,2})
                .SetWidthPercent(100)
                .SetFixedLayout();
            

            //dane

            var podsumowanieWartosciByTax = fv.FakturaPozycje.GroupBy(g => g.PodatekStawka.JednPodatekStawkaId).Select(s => new
            {
                PodatekStawkaId=s.Key,
                PodatekStawkaNazwa=s.FirstOrDefault().PodatekStawka.Nazwa,
                PodatekStawkaWartosc=s.FirstOrDefault().PodatekStawka.Wartosc,
                RazemNetto=s.Sum(sum=>sum.Ilosc*sum.WartoscJedn)
            }).OrderByDescending(o=>o.PodatekStawkaNazwa).ToList();

            var sprzedawca = kontr.Where(w => w.KontrahentId == fv.Sprzedawca.KontrahentId).Select(s => s).FirstOrDefault();
            var nabywca = kontr.Where(w => w.KontrahentId == fv.Nabywca.KontrahentId).Select(s => s).FirstOrDefault();
            var nabywcaWarunkiDostawy = fv.DodatkoweInfo.CzyAdresDostawy ? nabywca.KontrahentDealerzy.Where(w => w.Id == fv.DodatkoweInfo.AdresDostawy.KontrahentDealerId).Select(s => s).FirstOrDefault() : null;
            

            var sprzedawcaDTO=    new KontrahentInfoDTO()
            {
                Kontrahent = sprzedawca
            };
            var nabywcaDTO = new KontrahentInfoDTO()
            {
                Kontrahent = nabywca
            };

            var nabywcaWarunkiDostawyDTO = nabywcaWarunkiDostawy == null ? null : new KontrahentDealerInfoDTO
            {
                KontrahentDealer = nabywcaWarunkiDostawy,
            };
            var sprzedawcaKontoBankowe = String.IsNullOrEmpty(sprzedawca.KontoBankoweSwift) ? sprzedawca.KontoBankowe : $"SWIFT: {sprzedawca.KontoBankoweSwift}, {sprzedawca.KontoBankowe}";



            float fontSizeDef = 8f;

            //slowniki

            string tytul;
            string korektaDotyczy;
            string podsumWart;
            string razemDoZaplaty;
            string razemDoZwrotu;
            if (fv.CzyKorekta) {
                tytul = fv.CzyEng ? "Correction Invoice" : "Faktura korygująca";
                korektaDotyczy = fv.CzyEng ? $"to document {fv.BaseFakturaNumerDokumentu} [{fv.BaseFakturaDataWystawienia.ToShortDateString()}]" : $"dotyczy dokumentu {fv.BaseFakturaNumerDokumentu}, [{fv.BaseFakturaDataWystawienia.ToShortDateString()}]";
                podsumWart = fv.CzyEng ? "Summary (after correction)" : "Podsumowanie wartości (po korekcie)";
                razemDoZaplaty = fv.CzyEng ? "Due amount" : "Do zapłaty";
                razemDoZwrotu = fv.CzyEng ? "Overpayment" : "Do zwrotu";
            }
            else {
                tytul = fv.CzyEng ? "Invoice" : "Faktura";
                korektaDotyczy = "";
                podsumWart = fv.CzyEng ? "Summary" : "Podsumowanie wartości";
                razemDoZaplaty = "";
                razemDoZwrotu = "";
            }
            var tblPrzed = fv.CzyEng ? "Before correction" : "Przed korektą";
            var tblZmiany = fv.CzyEng ? "Changes" : "Zmiany";
            var tblPo = fv.CzyEng ? "After correction" : "Po korekcie";

            var tytulKorekta = fv.CzyKorekta ? "Correction Invoice" : "Faktura korygująca";
            var dataWyst = fv.CzyEng ? "Invoice date" : "Data wystawienia";
            var numerDokumentu = fv.CzyEng ? "Invoice No." : "Numer dokumentu";
            var sprzed = fv.CzyEng ? "Seller" : "Sprzedawca";
            var nabyw = fv.CzyEng ? "Buyer" : "Nabywca";
            var kontrNazwa = fv.CzyEng ? "Name" : "Nazwa";
            var kontrAdres = fv.CzyEng ? "Address" : "Adres";
            var kontrBank = fv.CzyEng ? "Account No." : "Nr konta";
            var nabNip = String.IsNullOrEmpty(nabywca.NIP) ? "PESEL" : "NIP";

            var hc1 = fv.CzyEng ? "Pos" : "LP";
            var hc2 = fv.CzyEng ? "Product name" : "Nazwa towaru / usługi";
            var hc3 = fv.CzyEng ? "Qty" : "Ilość";
            var hc4 = fv.CzyEng ? "Unit price without tax" : "Cena jedn.bez podatku";
            var hc5 = fv.CzyEng ? "Value without tax" : "Wartość towaru/usługi bez podatku";
            var hc6 = fv.CzyEng ? "Tax" : "Podatek";
            var hc6a = fv.CzyEng ? "Rate" : "Stawka";
            var hc6b = fv.CzyEng ? "Value" : "Kwota";
            var hc8 = fv.CzyEng ? "Total price (incl. tax)" : "Wartość towaru/usługi z podatkiem";

            
            var podsumWartoPlatnoscRodzaj = fv.CzyEng ? fv.Platnosc.InfoEng : fv.Platnosc.Info;
            var podsumWartWarunkiPlatnosci = fv.CzyEng ? "Condition of payment" : "Warunki płatności";
            var podsumWartRazem = fv.CzyEng ? "Total" : "Razem";
            var podsumWartPodatek = fv.CzyEng ? "Tax" : "Podatek";
            var podsumWartStawka = fv.CzyEng ? "Rate" : "Stawka";

            var dodatkoweInfo = fv.CzyEng ? "Additional information" : "Dodatkowe informacje";
            var dodatkoweInfoWaga = fv.CzyEng ? "Weight" : "Waga";
            var dodatkoweInfoAdresDostawy = fv.CzyEng ? "Condition of delivery" : "Warunki dostawy";
            var dodatkoweInfoUwagi = fv.CzyEng ? "Notice" : "Uwagi";


            var headerFontSize = 6;

            tblNaglowek.AddCell(new Cell(1, 2).Add(logoImg).SetBorder(Border.NO_BORDER));
            tblNaglowek.AddCell(PustaCell(1,1));
            tblNaglowek.AddCell(FakCell(fv.DataWystawienia.ToShortDateString(), dataWyst, fontSizeDef, TextAlignment.RIGHT, 1, 2));
            tblNaglowek.StartNewRow();
            tblNaglowek.AddCell(HeaderCell(tytul +" "+ fv.NumerDokumentu, 24,1,5)
                .SetFont(ConstPdfFonts.ExoExtraBold)
                .SetBackgroundColor(null)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                .SetBorder(Border.NO_BORDER)
                );
            if (fv.CzyKorekta) {
                tblNaglowek.StartNewRow();
                tblNaglowek.AddCell(FakCell(korektaDotyczy, null, 12, TextAlignment.CENTER, 1, 5));
            }

            tblNaglowek.StartNewRow();
            tblNaglowek.AddCell(new Cell(1, 2).Add(sprzed).SetFontSize(12).SetBorder(Border.NO_BORDER).SetBorderBottom(new DoubleBorder(Color.LIGHT_GRAY,1)).SetTextAlignment(TextAlignment.CENTER));
            tblNaglowek.AddCell(PustaCell(1, 1));
            tblNaglowek.AddCell(new Cell(1, 2).Add(nabyw).SetFontSize(12).SetBorder(Border.NO_BORDER).SetBorderBottom(new DoubleBorder(Color.LIGHT_GRAY, 1)).SetTextAlignment(TextAlignment.CENTER));
            tblNaglowek.StartNewRow();
            tblNaglowek.AddCell(FakCell(sprzedawcaDTO.Nazwa, null, fontSizeDef, TextAlignment.CENTER, 1, 2).SetBold());
            tblNaglowek.AddCell(PustaCell(1, 1));
            tblNaglowek.AddCell(FakCell(nabywcaDTO.Nazwa, null, fontSizeDef, TextAlignment.CENTER, 1, 2).SetBold());

            tblNaglowek.AddCell(FakCell(sprzedawcaDTO.Adres, null, fontSizeDef-1, TextAlignment.CENTER, 1, 2));
            tblNaglowek.AddCell(PustaCell(1, 1));
            tblNaglowek.AddCell(FakCell(nabywcaDTO.Adres, null, fontSizeDef-1, TextAlignment.CENTER, 1, 2));

            tblNaglowek.AddCell(FakCell(sprzedawca.NIP, "NIP", fontSizeDef - 1, TextAlignment.CENTER, 1, 2));
            tblNaglowek.AddCell(PustaCell(1, 1));
            tblNaglowek.AddCell(FakCell(nabywca.NIP, nabNip, fontSizeDef - 1, TextAlignment.CENTER, 1, 2));
            
            tblNaglowek.AddCell(FakCell(sprzedawcaKontoBankowe, kontrBank, fontSizeDef, TextAlignment.CENTER, 1, 2));
            tblNaglowek.StartNewRow();

            tblNaglowek.AddCell(FakCell(sprzedawca.Tel, "Tel", fontSizeDef - 1, TextAlignment.CENTER, 1, 1));
            tblNaglowek.AddCell(FakCell(sprzedawca.Fax, "Fax", fontSizeDef - 1, TextAlignment.CENTER, 1, 1));
            tblNaglowek.StartNewRow();
            tblNaglowek.AddCell(FakCell(sprzedawca.Email, "e-mail", fontSizeDef - 1, TextAlignment.CENTER, 1, 2));
            tblNaglowek.StartNewRow();

            var defTablePozycje = new float[] { 20f, 240f, 20f, 50f, 70f, 50f, 40f, 75f };

            var tblPozycjePrzed = new Table(defTablePozycje)
                .SetFixedLayout();
            var tblPozycjeZmiany = new Table(defTablePozycje)
                .SetFixedLayout();

            var tblPozycje = new Table(defTablePozycje)
                .SetFixedLayout();

            if (fv.CzyKorekta)
            {
                //tabela przed
                tblPozycjePrzed
                    .AddHeaderCell(HeaderCell(hc1, headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell(hc2, headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell(hc3, headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell($"{hc4} [{fv.Waluta.Skrot}]", headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell($"{hc5} [{fv.Waluta.Skrot}]", headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell(hc6, 6, 1, 2))
                    .AddHeaderCell(HeaderCell($"{hc8} [{fv.Waluta.Skrot}]", headerFontSize, 2, 1))

                    .AddHeaderCell(HeaderCell(hc6a))
                    .AddHeaderCell(HeaderCell(hc6b))
                    ;

                for (int i = 0; i < fv.FakturaPozycjePrzed.Count; i++)
                {
                    var p = fv.FakturaPozycjePrzed[i];
                    tblPozycjePrzed.AddCell(PozCell((i + 1).ToString() + ".", 10, TextAlignment.CENTER));

                    tblPozycjePrzed.AddCell(PozCell(p.Nazwa, 8, TextAlignment.LEFT));
                    tblPozycjePrzed.AddCell(PozCell(p.Ilosc.ToString(), 8, TextAlignment.CENTER));
                    tblPozycjePrzed.AddCell(PozCell(p.WartoscJedn.ToString("### ### ##0.00"), 8, TextAlignment.RIGHT));
                    tblPozycjePrzed.AddCell(PozCell((p.WartoscJedn * p.Ilosc).ToString("### ### ##0.00"), 8, TextAlignment.RIGHT));
                    tblPozycjePrzed.AddCell(PozCell(p.PodatekStawka.Nazwa, 6, TextAlignment.CENTER));
                    tblPozycjePrzed.AddCell(PozCell((p.PodatekStawka.Wartosc * p.WartoscJedn * p.Ilosc).ToString("### ### ##0.00"), 8, TextAlignment.RIGHT));
                    var wartBrutto = (p.WartoscJedn * p.Ilosc) + (p.WartoscJedn * p.Ilosc * p.PodatekStawka.Wartosc);
                    tblPozycjePrzed.AddCell(PozCell(wartBrutto.ToString("### ### ##0.00"), 10, TextAlignment.RIGHT));
                    tblPozycjePrzed.StartNewRow();
                }
                tblPozycjePrzed.GetHeader().SetBorder(new SolidBorder(Color.DARK_GRAY, 2f, 0.5f));


                //zmiany

                tblPozycjeZmiany
                    .AddHeaderCell(HeaderCell(hc1, headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell(hc2, headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell(hc3, headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell($"{hc4} [{fv.Waluta.Skrot}]", headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell($"{hc5} [{fv.Waluta.Skrot}]", headerFontSize, 2, 1))
                    .AddHeaderCell(HeaderCell(hc6, 6, 1, 2))
                    .AddHeaderCell(HeaderCell($"{hc8} [{fv.Waluta.Skrot}]", headerFontSize, 2, 1))

                    .AddHeaderCell(HeaderCell(hc6a))
                    .AddHeaderCell(HeaderCell(hc6b))
                    ;

                for (int i = 0; i < fv.FakturaPozycjeZmiany.Count; i++)
                {
                    var p = fv.FakturaPozycjeZmiany[i];
                    tblPozycjeZmiany.AddCell(PozCell((i + 1).ToString() + ".", 10, TextAlignment.CENTER));

                    tblPozycjeZmiany.AddCell(PozCell(p.Nazwa, 8, TextAlignment.LEFT));
                    tblPozycjeZmiany.AddCell(PozCell(p.Ilosc.ToString(), 8, TextAlignment.CENTER));
                    tblPozycjeZmiany.AddCell(PozCell(p.WartoscJedn.ToString("### ### ##0.00"), 8, TextAlignment.RIGHT));
                    tblPozycjeZmiany.AddCell(PozCell("", 8, TextAlignment.RIGHT));
                    tblPozycjeZmiany.AddCell(PozCell(p.PodatekStawka.Nazwa, 6, TextAlignment.CENTER));
                    tblPozycjeZmiany.AddCell(PozCell("", 8, TextAlignment.RIGHT));
                    tblPozycjeZmiany.AddCell(PozCell("", 10, TextAlignment.RIGHT));
                    tblPozycjeZmiany.StartNewRow();
                }

                tblPozycjeZmiany.GetHeader().SetBorder(new SolidBorder(Color.DARK_GRAY, 2f, 0.5f));
            }



            tblPozycje
                .AddHeaderCell(HeaderCell(hc1,headerFontSize,2,1))
                .AddHeaderCell(HeaderCell(hc2,headerFontSize,2,1))
                .AddHeaderCell(HeaderCell(hc3,headerFontSize,2,1))
                .AddHeaderCell(HeaderCell($"{hc4} [{fv.Waluta.Skrot}]", headerFontSize,2,1))
                .AddHeaderCell(HeaderCell($"{hc5} [{fv.Waluta.Skrot}]",headerFontSize,2,1))
                .AddHeaderCell(HeaderCell(hc6,6,1,2))
                .AddHeaderCell(HeaderCell($"{hc8} [{fv.Waluta.Skrot}]",headerFontSize,2,1))

                .AddHeaderCell(HeaderCell(hc6a))
                .AddHeaderCell(HeaderCell(hc6b))
                ;

            for (int i = 0; i < fv.FakturaPozycje.Count; i++)
            {
                var p = fv.FakturaPozycje[i];
                tblPozycje.AddCell(PozCell((i+1).ToString()+".",10,TextAlignment.CENTER));

                tblPozycje.AddCell(PozCell(p.Nazwa,8,TextAlignment.LEFT));
                tblPozycje.AddCell(PozCell(p.Ilosc.ToString(), 8, TextAlignment.CENTER));
                tblPozycje.AddCell(PozCell(p.WartoscJedn.ToString("### ### ##0.00"), 8, TextAlignment.RIGHT));
                tblPozycje.AddCell(PozCell((p.WartoscJedn * p.Ilosc).ToString("### ### ##0.00"),8, TextAlignment.RIGHT));
                tblPozycje.AddCell(PozCell(p.PodatekStawka.Nazwa, 5, TextAlignment.CENTER));
                tblPozycje.AddCell(PozCell((p.PodatekStawka.Wartosc * p.WartoscJedn * p.Ilosc).ToString("### ### ##0.00"), 8, TextAlignment.RIGHT));
                var wartBrutto = (p.WartoscJedn * p.Ilosc) + (p.WartoscJedn * p.Ilosc * p.PodatekStawka.Wartosc);
                tblPozycje.AddCell(PozCell(wartBrutto.ToString("### ### ##0.00"), 10, TextAlignment.RIGHT));
                tblPozycje.StartNewRow();
            }

            tblPozycje.GetHeader().SetBorder(new SolidBorder(Color.DARK_GRAY, 2f, 0.5f));



            var tblPodsumowanieWart = new Table(new float[] { 225, 75, 85, 65, 65 })
//                .SetHorizontalAlignment(HorizontalAlignment.RIGHT)
                .SetWidthPercent(100)
                .SetFixedLayout();


            tblPodsumowanieWart.AddCell(FakCell(podsumWartWarunkiPlatnosci, null, fontSizeDef + 4, TextAlignment.LEFT, 1, 1).SetBold().SetMarginTop(20f));
            tblPodsumowanieWart.AddCell(FakCell(podsumWart,null,fontSizeDef+4, TextAlignment.LEFT,1,4).SetBold().SetMarginTop(20f));

            tblPodsumowanieWart.AddCell(FakCell(podsumWartoPlatnoscRodzaj, null, fontSizeDef, TextAlignment.LEFT, 1, 1));

            tblPodsumowanieWart.AddCell(FakCell("Netto", null, fontSizeDef, TextAlignment.LEFT, 1, 1));
            tblPodsumowanieWart.AddCell(FakCell(podsumWartStawka, null, fontSizeDef, TextAlignment.CENTER, 1, 1));
            tblPodsumowanieWart.AddCell(FakCell(podsumWartPodatek, null, fontSizeDef, TextAlignment.CENTER, 1, 1));
            tblPodsumowanieWart.AddCell(FakCell("Brutto", null, fontSizeDef, TextAlignment.RIGHT, 1, 1));


            tblPodsumowanieWart.AddCell(PustaCell());
            tblPodsumowanieWart.AddCell(new Cell(1, 4).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(Color.DARK_GRAY, 1, 0.5f)));

            var razemNetto = podsumowanieWartosciByTax.Sum(sum => sum.RazemNetto);
            var razemPodatek = podsumowanieWartosciByTax.Sum(sum => (sum.RazemNetto * sum.PodatekStawkaWartosc));
            var razemBrutto = razemNetto + razemPodatek;

            for (int i = 0; i < podsumowanieWartosciByTax.Count; i++)
            {
                var p = podsumowanieWartosciByTax[i];
                tblPodsumowanieWart.AddCell(PustaCell(1, 1));
                tblPodsumowanieWart.AddCell(FakCell(p.RazemNetto.ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.LEFT, 1, 1));
                tblPodsumowanieWart.AddCell(FakCell(p.PodatekStawkaNazwa, null, fontSizeDef, TextAlignment.CENTER, 1, 1));
                tblPodsumowanieWart.AddCell(FakCell((p.PodatekStawkaWartosc*p.RazemNetto).ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.CENTER, 1, 1));
                tblPodsumowanieWart.AddCell(FakCell(((p.PodatekStawkaWartosc * p.RazemNetto)+p.RazemNetto).ToString("### ### ##0.00"), null, fontSizeDef+1, TextAlignment.RIGHT, 1, 1));
            }


            tblPodsumowanieWart.AddCell(PustaCell());
            tblPodsumowanieWart.AddCell(new Cell(1, 4).SetBorder(Border.NO_BORDER).SetBorderTop(new SolidBorder(Color.DARK_GRAY, 1)));

            if (fv.CzyKorekta)
            {
                tblPodsumowanieWart.AddCell(PustaCell());
                tblPodsumowanieWart.AddCell(FakCell(tblPrzed, null, 8, TextAlignment.LEFT, 1, 4)).SetBorder(Border.NO_BORDER);
                tblPodsumowanieWart.AddCell(PustaCell());
                tblPodsumowanieWart.AddCell(FakCell(fv.BaseFakturaRazemNetto.ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.LEFT, 1, 2).SetBorderBottom(new SolidBorder(1)));
                tblPodsumowanieWart.AddCell(FakCell((fv.BaseFakturaRazemBrutto-fv.BaseFakturaRazemNetto).ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.CENTER, 1, 1).SetBorderBottom(new SolidBorder(1)));
                tblPodsumowanieWart.AddCell(FakCell(fv.BaseFakturaRazemBrutto.ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.RIGHT, 1, 1).SetBorderBottom(new SolidBorder(1)));

                tblPodsumowanieWart.AddCell(PustaCell());
                tblPodsumowanieWart.AddCell(FakCell(tblPo, null, 8, TextAlignment.LEFT, 1, 4));
                tblPodsumowanieWart.AddCell(PustaCell());
                tblPodsumowanieWart.AddCell(FakCell(razemNetto.ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.LEFT, 1, 2).SetBorderBottom(new SolidBorder(1)));
                tblPodsumowanieWart.AddCell(FakCell(razemPodatek.ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.CENTER, 1, 1).SetBorderBottom(new SolidBorder(1)));
                tblPodsumowanieWart.AddCell(FakCell(razemBrutto.ToString("### ### ##0.00"), null, fontSizeDef, TextAlignment.RIGHT, 1, 1).SetBorderBottom(new SolidBorder(1)));


                tblPodsumowanieWart.AddCell(PustaCell());
                tblPodsumowanieWart.AddCell(FakCell(fv.BaseFakturaRazemBrutto>fv.RazemBrutto ? razemDoZwrotu: razemDoZaplaty, null, fontSizeDef + 4, TextAlignment.LEFT, 1, 1).SetBold().SetBorderBottom(new DoubleBorder(Color.DARK_GRAY, 1)));
                tblPodsumowanieWart.AddCell(FakCell((fv.RazemBrutto- fv.BaseFakturaRazemBrutto).ToString("### ### ##0.00"), null, fontSizeDef + 3, TextAlignment.RIGHT, 1, 3).SetBold().SetBorderBottom(new DoubleBorder(Color.DARK_GRAY, 1)));
            }
            else {
                tblPodsumowanieWart.AddCell(PustaCell());
                tblPodsumowanieWart.AddCell(FakCell(podsumWartRazem, null, fontSizeDef + 4, TextAlignment.LEFT, 1,1).SetBold().SetBorderBottom(new DoubleBorder(Color.DARK_GRAY, 1)));
                tblPodsumowanieWart.AddCell(FakCell(razemBrutto.ToString("### ### ###.00"), null, fontSizeDef + 3, TextAlignment.RIGHT, 1, 3).SetBold().SetBorderBottom(new DoubleBorder(Color.DARK_GRAY, 1)));
            }

            



            var tblExtraInfo = new Table(new float[] { 1})
                .SetWidthPercent(75);


            tblExtraInfo.AddCell(FakCell(dodatkoweInfo, null, fontSizeDef + 4, TextAlignment.LEFT, 1, 1));
            if (!String.IsNullOrEmpty(fv.Uwagi)) {
                tblExtraInfo.AddCell(FakCell(fv.Uwagi, dodatkoweInfoUwagi, fontSizeDef, TextAlignment.LEFT, 1, 1));
            }
            if (fv.DodatkoweInfo.CzyColli) {
                tblExtraInfo.AddCell(FakCell(fv.DodatkoweInfo.Colli.ToString(), "Colli", fontSizeDef, TextAlignment.LEFT, 1, 1));
            }
            if (fv.DodatkoweInfo.CzyWaga)
            {
                var netto = fv.DodatkoweInfo.WagaNetto.ToString("### ### ##0.00");
                var brutto = fv.DodatkoweInfo.WagaBrutto.ToString("### ### ##0.00");
            tblExtraInfo.AddCell(FakCell($"Netto: {netto}, Brutto: {brutto}", dodatkoweInfoWaga, fontSizeDef, TextAlignment.LEFT, 1, 1));
            }
            if (fv.DodatkoweInfo.CzyAdresDostawy)
            {
                tblExtraInfo.AddCell(FakCell(nabywcaWarunkiDostawyDTO.Nazwa+", "+ nabywcaWarunkiDostawyDTO.Adres, dodatkoweInfoAdresDostawy, fontSizeDef, TextAlignment.LEFT, 1, 1));
            }




            var czyExtraInfo = !String.IsNullOrEmpty(fv.Uwagi) || fv.CzyDodatkoweInfo;




            doc.Add(tblNaglowek);
            if (fv.CzyKorekta) {
                doc.Add(new Paragraph(tblPrzed).SetBorder(Border.NO_BORDER).SetFontSize(13));
                doc.Add(tblPozycjePrzed);
                doc.Add(new Paragraph(tblZmiany).SetBorder(Border.NO_BORDER).SetFontSize(13));
                doc.Add(tblPozycjeZmiany);
                doc.Add(new Paragraph(tblPo).SetBorder(Border.NO_BORDER).SetFontSize(13));
            }
            doc.Add(tblPozycje);
            doc.Add(tblPodsumowanieWart);



            float totalHeight = (tblNaglowek.GetHeight().HasValue ? tblNaglowek.GetHeight().Value: 0) + (tblPozycje.GetHeight().HasValue ? tblPozycje.GetHeight().Value: 0);


            if (czyExtraInfo) {
                doc.Add(tblExtraInfo);
            }

            if (pdf.GetNumberOfPages() > 1)
            {
                pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler(doc, fv));
            }


            doc.Close();

            return ms;
        }

        protected class FooterEventHandler : IEventHandler
        {
            protected Document doc;
            protected FakturaSprzedazyDTO fv;
            public FooterEventHandler(Document doc, FakturaSprzedazyDTO fv)
            {
                this.doc = doc;
                this.fv = fv;
            }
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfCanvas canvas = new PdfCanvas(docEvent.GetPage());
                Rectangle pageSize = docEvent.GetPage().GetPageSize();
                canvas.BeginText();
                canvas.SetFontAndSize(ConstPdfFonts.ExoRegular, 6);
                var docTitle = fv.CzyEng ? $"Invoice {fv.NumerDokumentu}" : $"Faktura {fv.NumerDokumentu}";
                var strona = fv.CzyEng ? "Page" : "Strona";

                canvas.MoveText((pageSize.GetRight() - (doc.GetLeftMargin() + doc.GetRightMargin())) / 2, pageSize.GetBottom() + doc.GetBottomMargin()-20)
                    .ShowText($"{docTitle}, {strona} {docEvent.GetDocument().GetPageNumber(docEvent.GetPage())} /{docEvent.GetDocument().GetNumberOfPages()}")
                    .EndText()
                    .Release();
            }
        }


        private static Cell HeaderCell (string text,float fontSize=6,  int rowSpan=1, int colspan=1)
        {
            return new Cell(rowSpan,colspan).Add(new Paragraph(text)
                .SetFont(ConstPdfFonts.ExoBold)
                .SetFontSize(fontSize)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER)
                )
            .SetPadding(0)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetBackgroundColor(Color.LIGHT_GRAY);
        }

        private static Cell PozCell(string text, float fontSize, TextAlignment textAlignment, int rowSpan = 1, int colSpan=1)
        {
            return new Cell(rowSpan,colSpan)
            .Add(new Paragraph().Add(new Text(text)))
            .SetFontSize(fontSize)
            .SetTextAlignment(textAlignment)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetBorder(new SolidBorder(Color.LIGHT_GRAY, 1, 0.5f));
        }

        private static Cell FakCell(string text, string caption, float fontSize, TextAlignment textAlignment, int rowSpan = 1, int colSpan = 1)
        {
            return new Cell(rowSpan, colSpan)
              .Add(new Paragraph().Add(new Text(String.IsNullOrEmpty(caption)? "": caption + ": ").SetFontSize(fontSize / 2)).Add(new Text(String.IsNullOrEmpty(text) ? "" : text)).SetFontSize(fontSize))
            //.Add(new Paragraph().Add(new Text(String.IsNullOrEmpty(text)?"": text)).SetFontSize(fontSize).Add(new Text("\n"+caption).SetFontSize(fontSize/2)))
            //.Add(new Paragraph().Add(new Text("data wystawienia").SetFontSize(fontSize/2)))
            .SetPadding(0)
            .SetTextAlignment(textAlignment)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetBorder(Border.NO_BORDER);
        }

        private static Cell PustaCell(int rowSpan=1, int colSpan=1)
        {
            return new Cell(rowSpan, colSpan)
                .SetBorder(Border.NO_BORDER);
        }

    }


    public class SplittingOpt : ISplitCharacters
    {
        public bool IsSplitCharacter(GlyphLine text, int glyphPos)
        {
            if (!text.Get(glyphPos).HasValidUnicode())
            {
                return false;
            }
            int charCode = text.Get(glyphPos).GetUnicode();
            return (charCode <= ' ' || charCode == '-' || charCode == '\u2010' || (charCode >= 0x2002 && charCode <= 0x200b
                ) || (charCode >= 0x2e80 && charCode < 0xd7a0) || (charCode >= 0xf900 && charCode < 0xfb00) || (charCode
                 >= 0xfe30 && charCode < 0xfe50) || (charCode >= 0xff61 && charCode < 0xffa0));
        
        }
    }
}