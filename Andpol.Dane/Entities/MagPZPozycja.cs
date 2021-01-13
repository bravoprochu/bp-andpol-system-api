using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MagPzPozycja
    {

        public int MagPzPozycjaId { get; set; }

        public double Ilosc { get; set; }
        public int? MagPzRefId { get; set; }
        [ForeignKey("MagPzRefId")]
        public virtual MagPz MagPz { get; set; }

        public int? MagPzKorektaRefId { get; set; }
        [ForeignKey("MagPzKorektaRefId")]
        public virtual MagPzKorekta MagPzKorekta {get;set;}

        public int PozycjaMagazynowaRefId { get; set; }

        [ForeignKey("PozycjaMagazynowaRefId")]
        public virtual MagPozycjaMagazynowa PozycjaMagazynowa { get; set; }

        public bool Valid { get; set; }



    }

}