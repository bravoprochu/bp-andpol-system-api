using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Andpol.Dane.Entities
{
    public class KalendarzDniRoboczychZakres
    {
        public int KalendarzDniRoboczychZakresId { get; set; }
        [StringLength(5)]
        public string CzasDuration { get; set; }
        public DateTime CzasEnd { get; set; }
        public DateTime CzasStart { get; set; }
        public int KalendarzDniRoboczychDzialProdId { get; set; }
        [ForeignKey("KalendarzDniRoboczychDzialProdId")]
        public virtual KalendarzDniRoboczychDzialProd KalendarzDniRoboczychDzialProd { get; set; }
        public string Uwagi { get; set; }

    }
}