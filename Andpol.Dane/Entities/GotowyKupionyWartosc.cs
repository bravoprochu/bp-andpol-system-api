using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class GotowyKupionyWartosc
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Gotowy kupiony wartość, pole WARTOŚĆ jest wymagane")]
        public int Wartosc { get; set; }

        public int GotowyKupionyRefId { get; set; }
        [ForeignKey("GotowyKupionyRefId")]
        public virtual GotowyKupiony GotowyKupiony { get; set; }

        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }

    }
}
