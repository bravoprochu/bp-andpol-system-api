using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class PlanningPozycjaMagazynowa
    {
        public int PlanningPozycjaMagazynowaId { get; set; }

        public bool CzyWydane { get; set; }
        public int PlanningRefId { get; set; }
        [ForeignKey("PlanningRefId")]
        public virtual Planning Planning{ get; set; }
        public int PozycjaMagazynowaRefId { get; set; }
        [ForeignKey("PozycjaMagazynowaRefId")]
        public virtual MagPozycjaMagazynowa PozycjaMagazynowa { get; set; }
        public double Wartosc { get; set; }
    }
}