using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class JednDokumentTyp
    {
        public JednDokumentTyp()
        {
            MagPz = new HashSet<MagPz>();
            MagPzKorekta = new HashSet<MagPzKorekta>();
        }

        public int JednDokumentTypId { get; set; }
        public string Nazwa { get; set; }
        public string Uwagi { get; set; }

        [JsonIgnore]
        public virtual ICollection<MagPz> MagPz { get; set; }

        [JsonIgnore]
        public virtual ICollection<MagPzKorekta> MagPzKorekta { get; set; }
    }
}