using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.ModelsDTO
{
    public enum ZamowienieStatusEnum
    {
        Zlozone=0, 
        Planning=1,
        Produkcja=2,
        GotoweDoWysylki=3,
        Transport=4,
        Zrealizowane=5,
    }
}