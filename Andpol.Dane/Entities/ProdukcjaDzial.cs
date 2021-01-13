using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Entities
{
    public class ProdukcjaDzial
    {
        public ProdukcjaDzial()
        {
            Robocizna = new HashSet<Robocizna>();
            KalendarzDniRoboczychDzialProd = new HashSet<KalendarzDniRoboczychDzialProd>();
            ProdukcjaBrygadzista = new HashSet<ProdukcjaBrygadzista>();

        }
        public int ProdukcjaDzialId { get; set; }
        public bool CzyTkaninaBelka { get; set; }
        public bool CzyPozycjaMagazynowa { get; set; }
        public string NadrzedneIds { get; set; }
        public string Nazwa { get; set; }
        public int PoziomProdukcji { get; set; }
        public string Uwagi { get; set; }

        public virtual ICollection<Robocizna> Robocizna { get; set; }
        public virtual ICollection<KalendarzDniRoboczychDzialProd> KalendarzDniRoboczychDzialProd { get; set; }
        public virtual ICollection<ProdukcjaBrygadzista> ProdukcjaBrygadzista { get; set; }


    }
}