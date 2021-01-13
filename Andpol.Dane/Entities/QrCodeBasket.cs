using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class QrCodeBasket
    {
        [Key]
        public int QrCodeBasketId { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string Grupa { get; set; }

        [Required]
        public string Uwagi { get; set; }

        [Required]
        public string Link { get; set; }
    }
}