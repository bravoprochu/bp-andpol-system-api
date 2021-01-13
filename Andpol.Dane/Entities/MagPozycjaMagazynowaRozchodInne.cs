using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MagPozycjaMagazynowaRozchodInne
    {
        public int MagPozycjaMagazynowaRozchodInneId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime DataRozchodu { get; set; }
        public int RozchodMagRodzajRefId { get; set; }
        [ForeignKey("RozchodMagRodzajRefId")]
        public virtual JednRozchodMagRodzaj RozchodMagRodzaj { get; set; }
        public int PozycjaMagazynowaRefId { get; set; }

        [ForeignKey("PozycjaMagazynowaRefId")]
        public virtual MagPozycjaMagazynowa PozycjaMagazynowa { get; set; }
        public string Uwagi { get; set; }
        public double Wartosc { get; set; }


    }
}