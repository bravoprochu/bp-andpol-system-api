using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class KalendarzDniRoboczychDzialProdGrupaRoboczaSklad
    {
        public int KalendarzDniRoboczychDzialProdGrupaRoboczaSkladId { get; set; }
        public int Ilosc { get; set; }
        public int KalendarzDniRoboczychDzialProdRefId { get; set; }

        [ForeignKey("KalendarzDniRoboczychDzialProdRefId")]
        public virtual KalendarzDniRoboczychDzialProd KalendarzDniRoboczychDzialProd { get; set; }

        public int RobociznaRefId { get; set; }
        [ForeignKey("RobociznaRefId")]
        public virtual Robocizna Robocizna { get; set; }

    }
}