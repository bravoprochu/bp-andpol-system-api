using Andpol.Dane.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Pomocne.MagWZ
{
    public class MagWzPozycjaPozMag
    {
        public int MagWzPozycjaPozMagId { get; set; }
        public double Ilosc { get; set; }

        public int MagWzRefId { get; set; }
        [ForeignKey("MagWzRefId")]
        public virtual MagWz MagWz { get; set; }

        public int PozycjaMagazynowaRefId { get; set; }
        [ForeignKey("PozycjaMagazynowaRefId")]
        public virtual MagPozycjaMagazynowa PozycjaMagazynowa { get;set;}


    }
}