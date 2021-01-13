using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.PlanningExt
{
    public class ZakresGroupedDTO
    {
        public ZakresGroupedDTO()
        {
            ZakresyGrouped = new List<ZakresDTO>();
        }

        public DateTime DzienRoboczy { get; set; }
        public List<ZakresDTO> ZakresyGrouped { get; set; }
    }

    public class PlanningZakresDzienDTO
    {
        public DateTime DzienRoboczy { get; set; }
        public PlanningKalendarzDzien PlanningKalendarzDzien { get; set; }
        public CzasZakres Zakres { get; set; }
    }

}