using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class Wykonczenie
    {
        public int WykonczenieId { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public int WykonczenieGrupaRefId { get; set; }
        [ForeignKey("WykonczenieGrupaRefId")]
        public virtual WykonczenieGrupa WykonczenieGrupa { get; set; }
        public string Uwagi { get; set; }

    }
}