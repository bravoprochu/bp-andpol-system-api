using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class GotowyAndpolWartosc
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Gotowy Anpol wartość, pole WARTOŚĆ: jest wymagane")]
        public int Wartosc { get; set; }
        
        public int GotowyAndpolRefId { get; set; }
        [ForeignKey("GotowyAndpolRefId")]
        public virtual GotowyAndpol GotowyAndpol { get; set; }

        public int KombinacjaRefId { get; set; }
        [ForeignKey("KombinacjaRefId")]
        public virtual Kombinacja Kombinacja { get; set; }


    }
}
