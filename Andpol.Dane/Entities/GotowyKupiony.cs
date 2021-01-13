using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Andpol.Dane.Entities;
using System.ComponentModel.DataAnnotations;

namespace Andpol.Dane.Entities
{
    public class GotowyKupiony
    {
        public GotowyKupiony() {
            this.GotoweKupioneWartosc = new HashSet<GotowyKupionyWartosc>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Gotowy kupiony, pole NAZWA jest wymagane")]
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }
        public virtual ICollection<GotowyKupionyWartosc> GotoweKupioneWartosc { get; set; }
    }
}
