using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class ZamowienieKombi
    {
        public ZamowienieKombi() {
            this.ZamowienieObszycie = new HashSet<ZamowienieKombiObszycie>();
            this.ZamowienieKombiWykonczenie = new HashSet<ZamowienieKombiWykonczenie>();
        }


        public int ZamowienieKombiId { get; set; }

        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }

        public int ZamowienieRefId { get; set; }

        [ForeignKey("ZamowienieRefId")]
        public virtual Zamowienie Zamowienie { get; set; }

        [JsonIgnore]
        public virtual ICollection<ZamowienieKombiObszycie> ZamowienieObszycie { get; set; }

        [JsonIgnore]
        public virtual ICollection<ZamowienieKombiWykonczenie> ZamowienieKombiWykonczenie { get; set; }

        [JsonIgnore]
        public virtual ICollection<PlanningDzienRoboczyZamowienieKombi> PlanningZamowienieKombi { get; set; }




    }
}
