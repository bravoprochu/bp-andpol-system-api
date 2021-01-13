using Andpol.Dane.Pomocne.FakturaSprzedazy.DTO;
using Andpol.Dane.Entities;
using Andpol.Dane.ModelsDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzDetailDTO
    {
        public int MagWzId { get; set; }
        public MagWzDetailDTO()
        {
            this.ZamowieniaWybrane = new HashSet<FakturaSprzedazZamowieniaBazaDTO>();
            this.PozycjeMagazynowe = new HashSet<MagWzPozycjeMagazynoweDTO>();
        }
        public int BaseMagWzId { get; set; }
        public bool CzyKorekta { get; set; }
        public bool CzyZaksiegowana { get; set; }
        public CreatedInfoDTO CreatedInfo { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string NumerDokumentu { get; set; }
        public Byte TypDanychDokumentu { get; set; }
        public KontrahentInfoDTO Kontrahent { get; set; }
        public string Uwagi { get; set; }
        public int MagWzIdKorekta { get; set; }
        public string NumerDokumentuZrodlowego { get; set; }


        public ICollection<FakturaSprzedazZamowieniaBazaDTO> ZamowieniaWybrane { get; set; }
        public ICollection<MagWzPozycjeMagazynoweDTO> PozycjeMagazynowe { get; set; }


    }
}