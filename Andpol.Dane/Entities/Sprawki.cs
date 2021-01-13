using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class Sprawki
    {
        [Key]
        public int SprawkiId { get; set; }

        [Required]
        public string Grupa { get; set; }

        public Boolean IsDone { get; set; }

        public string Opis { get; set; }

        [Required]
        public int Priorytet { get; set; }
        public string Respond { get; set; }
        [Required]
        public string Tytul { get; set; }

        public string Zglaszajacy { get; set; }

        public DateTime DataZgloszenia { get; set; }



    }
}