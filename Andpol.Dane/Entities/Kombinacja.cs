using Andpol.Dane.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class Kombinacja
    {
        public Kombinacja() {
            this.KombinacjeEtapyProdukcyjne = new HashSet<KombinacjaEtapyProdukcyjne>();
            this.KombinacjeObszycie = new HashSet<KombinacjaObszycie>();

            this.KombinacjaPozycjaMagazynowaWartosc = new HashSet<KombinacjaPozycjaMagazynowa>();

            this.KombinacjaWykonczenie = new HashSet<KombinacjaWykonczenie>();

            this.KombinacjaRobocizna = new HashSet<KombinacjaRobocizna>();

            this.ZamowienieKombi = new HashSet<ZamowienieKombi>();
        }

        public int KombinacjaId { get; set; }
        public int? Glebokosc { get; set; }
        public int? IloscPoduszekOparciowych { get; set; }
        public int? IloscPoduszekSiedzeniowych { get; set; }

        public double? Kubatura { get; set; }
        public int NazwaKombinacjiRefId { get; set; }
        [ForeignKey("NazwaKombinacjiRefId")]
        public virtual NazwaKombinacji NazwaKombinacji { get; set; }
        public int NormaRefId { get; set; }
        [ForeignKey("NormaRefId")]
        public virtual Norma Norma { get; set; }
        public double? Wartosc { get; set; }
        public int? Szerokosc { get; set; }
        public double? Waga { get; set; }
        public int? Wysokosc { get; set; }
        public string Uwagi { get; set; }
        


        [JsonIgnore]
        public virtual ICollection<KombinacjaEtapyProdukcyjne> KombinacjeEtapyProdukcyjne { get; set; }
        [JsonIgnore]
        public virtual ICollection<KombinacjaObszycie> KombinacjeObszycie { get; set; }
        [JsonIgnore]
        public virtual ICollection<KombinacjaPozycjaMagazynowa> KombinacjaPozycjaMagazynowaWartosc { get; set; }
        [JsonIgnore]
        public virtual ICollection<KombinacjaRobocizna> KombinacjaRobocizna { get; set; }
        [JsonIgnore]
        public virtual ICollection<KombinacjaWykonczenie> KombinacjaWykonczenie { get; set; }

        [JsonIgnore]
        public virtual ICollection<ZamowienieKombi> ZamowienieKombi { get; set; }







    }
}
