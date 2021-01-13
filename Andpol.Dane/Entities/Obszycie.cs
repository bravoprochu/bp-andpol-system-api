using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class Obszycie
    {
        public Obszycie() {
            this.KombinacjeObszycie = new HashSet<KombinacjaObszycie>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Obszycie, pole NAZWA jest wymagane")]
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public virtual ICollection<KombinacjaObszycie> KombinacjeObszycie { get; set; }
    }
}
