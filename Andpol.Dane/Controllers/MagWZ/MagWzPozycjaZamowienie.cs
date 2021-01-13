using Andpol.Dane.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andpol.Dane.Pomocne.MagWZ
{
    public class MagWzPozycjaZamowienie
    {
        public int MagWzPozycjaZamowienieId { get; set; }
        public int MagWzRefId { get; set; }
        [ForeignKey("MagWzRefId")]
        public virtual MagWz MagWz { get; set; }
        public int ZamowienieRefId { get; set; }
        [ForeignKey("ZamowienieRefId")]
        public virtual Zamowienie Zamowienie { get; set; }
    }
}