using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{

    public class NazwaKombinacji
    {
        public NazwaKombinacji() {
            this.Kombinacje = new HashSet<Kombinacja>();
            //this.ZamowienieKombi = new HashSet<ZamowienieKombi>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa kombinacji, pole Nazwa jest wymagane")]
        public string Nazwa { get; set; }
        
        
        [MaxLength(50,ErrorMessage="Nazwa kombinacji, pole Uwagi: Maksymalna długość to 50 znaków..")]
        public string Uwagi { get; set; }

        public virtual ICollection<Kombinacja> Kombinacje { get; set; }
        //public virtual ICollection<ZamowienieKombi> ZamowienieKombi { get; set; }
    }
}
