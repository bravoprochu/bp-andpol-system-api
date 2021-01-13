using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.NormaExt
{
    public class GrupaRoboczaDTO
    {
        public GrupaRoboczaDTO()
        {
            Stanowiska = new List<RobociznaStanowiskoDTO>();
        }

        public int ProdukcjaDzialId { get; set; }
        public string ProdukcjaDzialNazwa { get; set; }
        public List<RobociznaStanowiskoDTO> Stanowiska { get; set; }
    }

    public class RobociznaStanowiskoDTO
    {
        public int RobociznaId { get; set; }
        public string RobociznaNazwa { get; set; }
        public int Wartosc { get; set; }
    }

    public class RobociznaStanowiskoStrataDTO : RobociznaStanowiskoDTO
    {
        public TimeSpan Strata { get; set; }
        public int RoboczoGodziny { get; set; }
        public int SkladWyjsciowy { get; set; }

    }

    public class RobociznaStanowiskoStrataCzasZakres
    {
        public int StrataInt { get; set; }
        public RobociznaStanowiskoDTO Stanowisko { get; set; }
    }
}