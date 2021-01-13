using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.Wykonczenia.DTO
{
    public class WykonczenieOpcjeByWykonczenieGrupaDTO
    {
        public WykonczenieOpcjeByWykonczenieGrupaDTO()
        {
            this.Wykonczenia = new List<KombinacjaWykonczenieDTO>();
        }
        public int WykonczenieGrupaRefId { get; set; }
        public string WykonczenieGrupaNazwa { get; set; }
        public List<KombinacjaWykonczenieDTO> Wykonczenia{ get; set; }

    }
}