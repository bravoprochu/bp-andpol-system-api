using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Andpol.Dane.Entities;
using System.ComponentModel.DataAnnotations;

namespace Andpol.Dane.Entities
{
    public class GotowyAndpol
    {
        public GotowyAndpol() { 
            this.GotowyAndpolWartosc = new HashSet<GotowyAndpolWartosc>();
        }
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Gotowy anpol, pole NAZWA jest wymagane")]
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public virtual ICollection<GotowyAndpolWartosc> GotowyAndpolWartosc { get; set; }
    }
}
