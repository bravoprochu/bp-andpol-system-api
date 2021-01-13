using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class KalendarzDniRoboczych
    {
        public KalendarzDniRoboczych()
        {
            this.KalendarzDniRoboczychDzialProd = new HashSet<KalendarzDniRoboczychDzialProd>();
        }
        public int KalendarzDniRoboczychId { get; set; }
        public DateTime DzienRoboczy { get; set; }
        //public int KalendarzDniRoboczychDzialProdId { get; set; }
        public virtual ICollection<KalendarzDniRoboczychDzialProd> KalendarzDniRoboczychDzialProd { get; set; }
        public string Uwagi { get; set; }
    }
}