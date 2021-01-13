using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MaterialGrupaKontrahent
    {
        public MaterialGrupaKontrahent()
        {
            this.Material = new HashSet<Material>();
        }
        public int MaterialGrupaKontrahentId { get; set; }

        public virtual Kontrahent Kontrahent { get; set; }

        [Required(ErrorMessage ="MateriałBelka - Grupa, pole Nazwa jest wymagane !")]
        public string Nazwa { get; set; }

        public string Uwagi { get; set; }

        [JsonIgnore]
        public virtual ICollection<Material> Material { get; set; }

    }
}