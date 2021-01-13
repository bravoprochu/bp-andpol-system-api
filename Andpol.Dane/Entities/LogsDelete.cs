using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class LogsDelete
    {
        public int LogsDeleteId{ get; set; }
        
        public DateTime DataUsuniecia{ get; set; }
        public string Tabela { get; set; }
        public string UserName { get; set; }
        public string Uwagi{ get; set; }

    }
}