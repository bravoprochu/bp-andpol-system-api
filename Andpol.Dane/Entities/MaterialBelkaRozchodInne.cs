using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Andpol.Dane.Entities
{
    public class MaterialBelkaRozchodInne
    {
        [Key]
        public int Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public DateTime DataRozchodu { get; set; }

        public int MaterialBelkaRefId { get; set; }

        [ForeignKey("MaterialBelkaRefId")]
        public virtual MaterialBelka MaterialBelka { get; set; }

        public int RozchodMagRodzajRefId { get; set; }
        [ForeignKey("RozchodMagRodzajRefId")]
        public virtual JednRozchodMagRodzaj RozchodMagRodzaj { get; set; }

        public string Uwagi { get; set; }
        public double Wartosc { get; set; }





    }
}
