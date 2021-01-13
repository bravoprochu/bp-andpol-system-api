

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class KombinacjaPozycjaMagazynowa
    {
        public int KombinacjaPozycjaMagazynowaId { get; set; }

        [Required(ErrorMessage ="MagPozycjaMagazynowaWartość, pole Wartość jest wymagane")]
        public double Wartosc { get; set; }

        public int MagPozycjaMagazynowaRefId { get; set; }

        [ForeignKey("MagPozycjaMagazynowaRefId")]
        public virtual MagPozycjaMagazynowa MagPozycjaMagazynowa { get; set; }

        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }

    }
}