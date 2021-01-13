using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class KalendarzDniRoboczychSzablon
    {

        [Key, ForeignKey("KalendarzDniRoboczychDzialProd")]
        public int KalendarzDniRoboczychDzialProdId { get; set; }
        public string Nazwa { get; set; }
        public virtual KalendarzDniRoboczychDzialProd KalendarzDniRoboczychDzialProd { get; set; }

    }
}