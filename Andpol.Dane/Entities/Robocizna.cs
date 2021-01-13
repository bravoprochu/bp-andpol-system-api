using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Andpol.Dane.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class Robocizna
    {
        public Robocizna()
        {
            this.KombinacjaRobociznaGrupaRobocza = new HashSet<KombinacjaRobociznaGrupaRobocza>();
            this.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad = new HashSet<KalendarzDniRoboczychDzialProdGrupaRoboczaSklad>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Robocizna, pole NAZWA jest wymagane")]
        public string Nazwa { get; set; }
        public int ProdukcjaDzialRefId { get; set; }
        [ForeignKey("ProdukcjaDzialRefId")]
        public virtual ProdukcjaDzial ProdukcjaDzial { get; set; }
        public string Uwagi { get; set; }
        public virtual ICollection<KombinacjaRobociznaGrupaRobocza> KombinacjaRobociznaGrupaRobocza { get; set; }
        public virtual ICollection<KalendarzDniRoboczychDzialProdGrupaRoboczaSklad> KalendarzDniRoboczychDzialProdGrupaRoboczaSklad { get; set; }


    }
}
