using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class Material
    { 
        public Material() {
            this.FakturaPozycjeTkaniny = new HashSet<FinFakturaPozycjeTkaniny>();
            this.MaterialBelka = new HashSet<MaterialBelka>();
            this.KombinacjaObszycie = new HashSet<KombinacjaObszycie>();
        }


        public int MaterialId { get; set; }

        public bool CzyUtrudnienie { get; set; }

        public int MaterialGrupaRefId { get; set; }

        [ForeignKey("MaterialGrupaRefId")]
        public virtual MaterialGrupaKontrahent MaterialGrupa { get; set; }
        [Required(ErrorMessage = "Material, pole NAZWA jest wymagane")]
        public string Nazwa { get; set; }
        public double SzerokoscBelki { get; set; }
        public string Uwagi { get; set; }
        [JsonIgnore]
        public virtual ICollection<MaterialBelka> MaterialBelka { get; set; }
        [JsonIgnore]
        public virtual ICollection<KombinacjaObszycie> KombinacjaObszycie { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinFakturaPozycjeTkaniny> FakturaPozycjeTkaniny { get; set; }

    }
}
