using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.Wykonczenia.DTO
{
    public class WykonczenieOpcjeByKombinacjeNormyDTO
    {
        public WykonczenieOpcjeByKombinacjeNormyDTO()
        {
            this.WykonczenieByGrupa = new List<WykonczenieOpcjeByWykonczenieGrupaDTO>();
        }

        public int KombinacjaRefId { get; set; }
        public string KombinacjaNazwa { get; set; }
        public List<WykonczenieOpcjeByWykonczenieGrupaDTO> WykonczenieByGrupa { get; set; }
    }
}