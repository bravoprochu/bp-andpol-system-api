using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.Zamowienia.DTO
{
    public class ZamowienieBasicInfoDTO
    {
        public int ZamowienieId { get; set; }
        public string ZamowienieNr { get; set; }
        public string Commission { get; set; }
        public string Reference { get; set; }
        public string Uwagi { get; set; }
    }
}