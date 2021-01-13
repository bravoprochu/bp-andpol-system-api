using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.Zamowienia.DTO
{
    public class ListaProdukcyjnaPostDTO
    {
        public ListaProdukcyjnaPostDTO()
        {
            this.ListaZamowien = new List<ZamowienieListaDTO>();
        }
        public bool isGrouped { get; set; }
        public List<ZamowienieListaDTO> ListaZamowien { get; set; }
    }
}