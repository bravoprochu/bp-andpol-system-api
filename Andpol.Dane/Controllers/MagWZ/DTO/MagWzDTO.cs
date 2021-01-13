using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.MagWZ.DTO
{
    public class MagWzBasicInfoDTO
    {
        public int MagWzId { get; set; }
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
    }
}