using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMSoft
{
   class MMSoftHelper
   {
      public static String DateToConvertibleString(DateTime Date_O)
      {
         String Date_st = Date_O.Year.ToString();

         if (Date_O.Month < 10)
            Date_st += "0";

         Date_st += Date_O.Month.ToString();

         if (Date_O.Day < 10)
            Date_st += "0";

         Date_st += Date_O.Day.ToString();

         return Date_st;
      }
   }
}
