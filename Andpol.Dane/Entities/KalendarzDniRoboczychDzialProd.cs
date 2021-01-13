using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class KalendarzDniRoboczychDzialProd
    {
        public KalendarzDniRoboczychDzialProd()
        {
            this.KalendarzDniRoboczychZakres = new HashSet<KalendarzDniRoboczychZakres>();
            this.KalendarzDniRoboczychDzialProdGrupaRoboczaSklad = new HashSet<KalendarzDniRoboczychDzialProdGrupaRoboczaSklad>();
        }
        public int KalendarzDniRoboczychDzialProdId { get; set; }

        public bool CzyKalendarzDniRoboczychZakresAktywny { get; set; }
        public int? KalendarzDniRoboczychRefId { get; set; }
        [ForeignKey("KalendarzDniRoboczychRefId")]
        public virtual KalendarzDniRoboczych KalendarzDniRoboczych { get; set; }


        public int ProdukcjaDzialRefId { get; set; }
        [ForeignKey("ProdukcjaDzialRefId")]
        public virtual ProdukcjaDzial ProdukcjaDzial { get; set; }

        
        public virtual KalendarzDniRoboczychSzablon KalendarzDniRoboczychSzablon { get; set; }
        public virtual ICollection<KalendarzDniRoboczychDzialProdGrupaRoboczaSklad> KalendarzDniRoboczychDzialProdGrupaRoboczaSklad { get; set; }
        public virtual ICollection<KalendarzDniRoboczychZakres> KalendarzDniRoboczychZakres { get; set; }
        



    }
}