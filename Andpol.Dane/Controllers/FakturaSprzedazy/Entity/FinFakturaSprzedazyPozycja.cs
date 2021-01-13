using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.FakturaSprzedazy.Entity
{
    public class FinFakturaSprzedazyPozycja
    {
        public int FinFakturaSprzedazyPozycjaId { get; set; }
        public bool CzyKorekta { get; set; }
        public bool CzyPozMag { get; set; }
        public int? FakturaSprzedazyPozycjaOrygRef { get; set; }

        public int? FakturaSprzedazyRefId { get; set; }
        [ForeignKey("FakturaSprzedazyRefId")]
        public virtual FinFakturaSprzedazy FakturaSprzedazy { get; set; }

        public int? FakturaSprzedazyZmianyRefId { get; set; }
        [ForeignKey("FakturaSprzedazyZmianyRefId")]
        public virtual FinFakturaSprzedazy FakturaSprzedazyZmmiany { get; set; }

        public double Ilosc { get; set; }
        public int? PozycjaMagazynowaRefId { get; set; }
        [ForeignKey("PozycjaMagazynowaRefId")]
        public virtual MagPozycjaMagazynowa PozycjaMagazynowa { get; set; }
        public string Nazwa { get; set; }
        public int PodatekStawkaRefId { get; set; }
        [ForeignKey("PodatekStawkaRefId")]
        public virtual JednPodatekStawka  PodatekStawka { get; set; }
        public double WartoscJedn { get; set; }
    }
}