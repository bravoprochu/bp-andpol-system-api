using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class ChangeLog
    {
        public int ChangeLogId { get; set; }
        public DateTime Data{ get; set; }

        public string Grupa { get; set; }
        public string Nazwa { get; set; }

        public string Wersja { get; set; }
    }
}