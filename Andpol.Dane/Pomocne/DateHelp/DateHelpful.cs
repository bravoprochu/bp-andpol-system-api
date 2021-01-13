using Andpol.Dane.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andpol.Dane.Pomocne
{
    public static partial class DateHelpful
    {
            public static DateTime dataStalaGodzina(DateTime d, int godz = 9)
            {
                return new DateTime(d.Year, d.Month, d.Day, godz, 0, 0);
            }

            public static DateTime kwartal()
            {
                DateTime kwartalTemu = DateTime.Now.AddMonths(-3);
                return new DateTime(kwartalTemu.Year, kwartalTemu.Month, 1);
            }

            public static DateRangeDTO DateRangeOstKwartal()
            {
                return new DateRangeDTO
                {
                    DateEnd = DateTime.Now,
                    DateStart = kwartal()
                };
            }
    }
}