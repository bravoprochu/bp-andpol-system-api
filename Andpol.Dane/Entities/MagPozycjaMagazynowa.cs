using Andpol.Dane.Pomocne.FakturaSprzedazy.Entity;
using Andpol.Dane.Pomocne.MagWZ;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class MagPozycjaMagazynowa
    {
        public MagPozycjaMagazynowa()
        {
            this.MagPozycjaMagazynowaWartoscColl = new HashSet<KombinacjaPozycjaMagazynowa>();
            this.MagPozycjaMagazynowaRozchodInne = new HashSet<MagPozycjaMagazynowaRozchodInne>();
            this.MagPZPozycjaColl = new HashSet<MagPzPozycja>();
            this.MagWzPozycjaPozMag = new HashSet<MagWzPozycjaPozMag>();
            this.FakturaPozycje = new HashSet<FinFakturaPozycje>();
            this.FakturaSprzedazyPozycja = new HashSet<FinFakturaSprzedazyPozycja>();
            this.PlanningPozycjaMagazynowa = new HashSet<PlanningPozycjaMagazynowa>();
        }

        public int MagPozycjaMagazynowaId { get; set; }


        public bool czyPotwierdzone { get; set; }

        public int GrupaZakladowaRefId { get; set; }

        [ForeignKey("GrupaZakladowaRefId")]
        public virtual JednGrupaZakladowa GrupaZakladowa { get; set; }


        public int JednostkaMiaryRefId { get; set; }
        [ForeignKey("JednostkaMiaryRefId")]
        public virtual JednJednostkaMiary JednostkaMiary {get;set;}


        [StringLength(48)]
        public string KodKreskowy { get; set; }


        public int MarzaZakladowaRefId { get; set; }
        [ForeignKey("MarzaZakladowaRefId")]
        public virtual JednMarzaZakladowa MarzaZakladowa { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        public string Nazwa { get; set; }

        public double? StanMinAlarm { get; set; }
        public double? StanAktualny { get; set; }
        public double? StanRzeczywisty { get; set; }
        public int TypTowaru { get; set; }

        public int VatSprzedazyRefId { get; set; }
        [ForeignKey("VatSprzedazyRefId")]
        public virtual JednPodatekStawka VatSprzedazy { get; set; }


        public int VatZakupuRefId { get; set; }
        [ForeignKey("VatZakupuRefId")]
        public virtual JednPodatekStawka VatZakupu { get; set; }
        public string Uwagi { get; set; }

        [InverseProperty("MagPozycjaMagazynowa")]
        public virtual ICollection<KombinacjaPozycjaMagazynowa> MagPozycjaMagazynowaWartoscColl { get; set; }
        [JsonIgnore]
        public virtual ICollection<MagPozycjaMagazynowaRozchodInne> MagPozycjaMagazynowaRozchodInne { get; set; }

        [InverseProperty("PozycjaMagazynowa")]
        public virtual ICollection<MagPzPozycja> MagPZPozycjaColl { get; set; }

        public virtual ICollection<MagWzPozycjaPozMag> MagWzPozycjaPozMag { get; set; }

        public virtual ICollection<FinFakturaPozycje> FakturaPozycje { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinFakturaSprzedazyPozycja> FakturaSprzedazyPozycja { get; set; }

        [JsonIgnore]
        public virtual ICollection<PlanningPozycjaMagazynowa> PlanningPozycjaMagazynowa { get; set; }



    }
}