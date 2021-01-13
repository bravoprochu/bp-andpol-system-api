using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne
{
    public static partial class ZamowieniaHelpful
    {
        public static string ZamowienieKombinacjeNazwa(List<string> kombinacje)
        {
            
            if (kombinacje.Count == 0) return "";
            var result = "";

            for (int i = 0; i < kombinacje.Count; i++)
            {
                var k = kombinacje[i];
                if (k.StartsWith("-"))
                {
                    result += k;
                }
                else {
                    var withSpace = (i == 0) ? null : " | ";
                    result += $"{withSpace}{k}";
                }
            }

            return result;
        }


        public static string ValueKeyConcat(List<string> values, List<string> keys)
        {
            string result = "";
            if (values.Count != keys.Count) return null;
            for (int i = 0; i < values.Count; i++)
            {
                var v = values[i];
                var k = keys[i];

                if (i < values.Count-1)
                {
                    result += $"{v} ({k}) | ";
                }
                else
                {
                    result += $"{v} ({k})";
                }
            }
            return result;
        }


    }


}