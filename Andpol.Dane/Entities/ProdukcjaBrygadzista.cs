using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class ProdukcjaBrygadzista
    {
        public int ProdukcjaBrygadzistaId { get; set; }
        public string UserName { get; set; }
        public int ProdukcjaDzialRefId { get; set; }
        [ForeignKey("ProdukcjaDzialRefId")]
        public virtual ProdukcjaDzial ProdukcjaDzial { get; set; }



    }
}