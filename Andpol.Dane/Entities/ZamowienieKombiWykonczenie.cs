using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Entities
{
    public class ZamowienieKombiWykonczenie
    {
        public int ZamowienieKombiWykonczenieId { get; set; }
        public int KombinacjaWykonczenieRefId { get; set; }

        [ForeignKey("KombinacjaWykonczenieRefId")]
        public virtual KombinacjaWykonczenie KombinacjaWykonczenie { get; set; }
        public int ZamowienieKombiRefId { get; set; }
        [ForeignKey("ZamowienieKombiRefId")]
        public virtual ZamowienieKombi ZamowienieKombi { get; set; }

    }
}