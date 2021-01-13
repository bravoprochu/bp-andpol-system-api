using Andpol.Dane.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne.Zamowienia.DTO
{
    public class ListaProdukcyjnaDTO
    {
        //public ListaProdukcyjnaDTO()
        //{
        //    this.ZamowienieKombi = new List<Entities.ZamowienieKombi>();
        //    this.ZamowienieKombiObszycie = new List<Entities.ZamowienieKombiObszycie>();
        //}
        //public List<ZamowienieKombi> ZamowienieKombi { get; set; }
        //public Zamowienie Zamowienie { get; set; }
        //public List<ZamowienieKombiObszycie> ZamowienieKombiObszycie {get;set;}
        public int Pos { get; set; }
        public string Model { get; set; }
        public string Combination { get; set; }
        public int Quantity { get; set; }
        public string Fabric { get; set; }
        public string Feet { get; set; }
        public string Reference { get; set; }
        public string OrderNumber { get; set; }
        public string Commission { get; set; }
        public int Quantity2 { get; set; }
        public double Price { get; set; }
        public string Customer { get; set; }
        public string DebNumber { get; set; }
        public string PlaceOfDelivery { get; set; }
        public string OrderDate { get; set; }
        public bool RequireDelivery { get; set; }
        public string DeliveryTimeConfirmed { get; set; }
        public string Payment { get; set; }
        public string ConsumpPerUnit { get; set; }
        public string ConsumpAtAll { get; set; }
        public string Status { get; set; }
        public string ProductionOrderNo { get; set; }
        public string TranportDate { get; set; }
        public string VatInvoice { get; set; }
        public string Others { get; set; }
    }



    public class ListaProdukcyjnaGroupedByFeet
    {
        public ListaProdukcyjnaGroupedByFeet(List<int> chronologiaKombinacji)
        {
            this.ChronologiaKombinacji = chronologiaKombinacji;
            this.ZamowienieKombi = new List<Entities.ZamowienieKombi>();
        }
        private List<int> ChronologiaKombinacji { get; set; }
        public List<string> KombiNazwaIdx
        {
            get
            {
                List<string> result = new List<string>();

                foreach (var z in this.ZamowienieKombi)
                {
                    var kombiIdx = ChronologiaKombinacji.IndexOf(z.ZamowienieKombiId) + 1;
                    result.Add(z.Kombinacja.NazwaKombinacji.Nazwa + $" ({kombiIdx})");
                }

                return result;
            }
        }
        public int WykonczenieId { get; set; }
        public string WykonczenieNazwa { get; set; }
        public List<ZamowienieKombi> ZamowienieKombi{ get; set; }
        public string FeetResult
        {
            get
            {
                return "["+this.KombiNazwaIdx.Aggregate((curr, next) => curr + " | " + next)+"]";
            }
        }
    }





    public class ListaProdukcyjnaGroupedByMaterial
    {
        public ListaProdukcyjnaGroupedByMaterial()
        {
            this.KombiGroupedByObszycie = new List<ListProdukcyjnaGroupByObszycie>();
        }

        public int MaterialId { get; set; }

        public Material Material { get; set; }
        public List<ListProdukcyjnaGroupByObszycie> KombiGroupedByObszycie { get; set; }

        public string MaterialResult
        {
            get
            {
                return KombiGroupedByObszycie.Select(s => string.Format(s.ObszycieResult)).Aggregate((curr, next) => curr + " || " + next);
            }
        }
    }


    public class ListProdukcyjnaGroupByObszycie
    {
        public ListProdukcyjnaGroupByObszycie(List<int> chronologiaKombinacji)
        {
            this.ChronologiaKombinacji = chronologiaKombinacji;
            this.ZamowienieKombi = new List<Entities.ZamowienieKombi>();
        }
        private List<int> ChronologiaKombinacji { get; set; }
        public int ObszycieId { get; set; }
        public string ObszycieNazwa { get; set; }
        public List<ZamowienieKombi> ZamowienieKombi { get; set; }
        public List<string> KombiNazwaIdx
        {
            get
            {
                List<string> result = new List<string>();

                foreach (var z in this.ZamowienieKombi)
                {
                    var kombiIdx = ChronologiaKombinacji.IndexOf(z.ZamowienieKombiId) + 1;
                    result.Add(z.Kombinacja.NazwaKombinacji.Nazwa + $" ({kombiIdx})");
                }

                return result;
            }
        }
        public string ObszycieResult
        {
            get
            {
                return this.ObszycieNazwa + "[" + this.KombiNazwaIdx.Aggregate((curr, next) => curr + " | " + next) + "]";
            }
        }
    }
}