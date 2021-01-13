using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class KombinacjaRobocizna
    {
        public KombinacjaRobocizna()
        {
            this.KombinacjaRobociznaGrupaRobocza = new HashSet<KombinacjaRobociznaGrupaRobocza>();
        }

        [Key]
        public int KombinacjaRobociznaId { get; set; }
        [Required(ErrorMessage = "Robocizna wartość, pole Wartosc jest wymagane")]
        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }
        public int ProdukcjaDzialRefId { get; set; }
        [ForeignKey("ProdukcjaDzialRefId")]
        public virtual ProdukcjaDzial ProdukcjaDzial { get; set; }
        public int Wartosc { get; set; }
        public virtual ICollection<KombinacjaRobociznaGrupaRobocza> KombinacjaRobociznaGrupaRobocza { get; set; }
    }
}
