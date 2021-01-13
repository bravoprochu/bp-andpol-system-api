﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class JednMarzaZakladowa
    {
        public JednMarzaZakladowa()
        {
            MagPozycjaMagazynowa = new HashSet<MagPozycjaMagazynowa>();
        }

        public int JednMarzaZakladowaId { get; set; }

        [Required, MaxLength(50)]
        public string Nazwa { get; set; }

        public double Wartosc { get; set; }

        [MaxLength(100)]
        public string Uwagi { get; set; }

        [JsonIgnore]
        public virtual ICollection<MagPozycjaMagazynowa> MagPozycjaMagazynowa { get; set; }
    }
}