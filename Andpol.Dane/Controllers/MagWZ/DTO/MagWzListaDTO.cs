using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzListaDTO:MagWzBasicInfoDTO
    {
        public int ZamowieniaWybraneCount { get; set; }
        public int PozycjeMagazynoweCount { get; set; }
    }
}