using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class ZamowienieStatusNazwa
    {
        public ZamowienieStatusNazwa() {
            this.ZamowienieStatusWartosc = new HashSet<ZamowienieStatusWartosc>();
        }
        
        public int ZamowienieStatusNazwaId { get; set; }

        public string Nazwa { get; set; }
        [JsonIgnore]
        public virtual ICollection<ZamowienieStatusWartosc> ZamowienieStatusWartosc { get; set; }
    }
}
