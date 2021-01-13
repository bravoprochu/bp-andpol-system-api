using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzWyZamowienieKombiWykonczenieDTO:WykonczenieDTO
    {
        public int KombinacjaRefId { get; set; }
        public string NazwaKombinacji { get; set; }

    }
}