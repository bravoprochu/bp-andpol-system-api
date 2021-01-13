using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzZamowienieKombiWartoscDTO {
        public MagWzZamowienieKombiWartoscDTO()
        {
            this.NaliczeniaNazwy = new List<string>();
        }
        
        public List<string> NaliczeniaNazwy { get; set; }
        public double WartoscNaliczen { get; set; }
        public double WartoscPoNaliczeniach { get; set; }
        public double WartoscBaza { get; set; }
        

    }
}
