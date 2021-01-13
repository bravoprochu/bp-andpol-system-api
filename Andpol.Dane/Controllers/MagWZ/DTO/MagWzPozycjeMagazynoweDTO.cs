using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzPozycjeMagazynoweDTO: MagPozycjaMagazynowaStanShortDTO
    {
        public double Ilosc { get; set; }
        public string UniqueKey { get; set; }
        public PodatekStawkaDTO PodatekStawka { get; set; }
    }
}