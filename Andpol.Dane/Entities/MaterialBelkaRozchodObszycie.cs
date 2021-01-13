using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class MaterialBelkaRozchodObszycie
    {

        public int MaterialBelkaRozchodObszycieId { get; set; }

        public int ZamowienieObszycieRefId { get; set; }

        [ForeignKey("ZamowienieObszycieRefId")]
        public virtual ZamowienieKombiObszycie ZamowienieObszycie { get; set; }

        public int MaterialBelkaRefId { get; set; }

        [ForeignKey("MaterialBelkaRefId")]
        public virtual MaterialBelka MaterialBelka { get; set; }

    }
}