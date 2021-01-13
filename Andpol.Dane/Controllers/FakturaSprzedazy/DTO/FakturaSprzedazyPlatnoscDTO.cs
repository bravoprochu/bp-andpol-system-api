using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.DTO
{
    public class FakturaSprzedazyPlatnoscDTO
    {
        public int IleDni { get; set; }
        public string Uwagi { get; set; }
        public JednPlatnoscRodzaj PlatnoscRodzaj { get; set; }
        public string Info { get {
                var result = "";
                var dzien = IleDni == 1 ? "dzień" : "dni";
                switch (this.PlatnoscRodzaj.JednPlatnoscRodzajId)
                {
                    
                    case 2:
                        result = $"Gotówka w terminie {IleDni} {dzien}";
                        break;
                    case 3:
                        result = $"Przelew w terminie {IleDni} {dzien}";
                        break;
                    default:
                            result = this.PlatnoscRodzaj.Nazwa;
                        break;
                }

                return result;
            }
        }
        public string InfoEng
        {
            get
            {
                var result = "";
                var dzien = IleDni == 1 ? "day" : "days";
                switch (this.PlatnoscRodzaj.JednPlatnoscRodzajId)
                {
                    case 1:
                        result = "Payment by cash";
                        break;
                    case 2:
                        result = $"{IleDni} {dzien} after delivery, payment by cash";
                        break;
                    case 3:
                        result = $"{IleDni} {dzien} after delivery, by bank transfer";
                        break;
                    case 4:
                        result = "Credit card";
                        break;
                    case 5:
                        result = $"Other: {this.Uwagi}";
                        break;
                }

                return result;
            }
        }
    }
}