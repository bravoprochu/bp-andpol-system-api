using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class KombinacjaRobociznaGrupaRobocza
    {
        public int KombinacjaRobociznaGrupaRoboczaId { get; set; }

        public int KombinacjaRobociznaRefId { get; set; }
        [ForeignKey("KombinacjaRobociznaRefId")]
        public virtual KombinacjaRobocizna KombinacjaRobocizna {get;set;}

        public int RobociznaRefId { get; set; }
        [ForeignKey("RobociznaRefId")]
        public virtual Robocizna Robocizna { get; set; }
        public int Wartosc { get; set; }


    }
}