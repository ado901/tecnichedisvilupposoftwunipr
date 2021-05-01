using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progettotecnichesvil
{
    class Utility
    {
        public static (int,int,int) checkData(string dataNa)
        {
            if (dataNa.Substring(2, 1) != "/" || dataNa.Substring(5, 1) != "/")
            {
                throw new Exception("Formato della data non valido! inserire una data nel formato dd/mm/aaaa");
            }
            int giorni = 0;
            if (int.TryParse(dataNa.Substring(0, 2), out giorni))
            {
                if (giorni < 0 || giorni > 31)
                {
                    throw new Exception("Inserire un valore per i giorni compreso tra 1 e 31");
                }
            }
            else
            {
                throw new Exception("Giorni errato");
            }
            int mese = 0;
            if (int.TryParse(dataNa.Substring(3, 2), out mese))
            {
                if (mese < 0 || mese > 12)
                {
                    throw new Exception("Inserire un valore per i mesi compreso tra 1 e 12");
                }
            }
            else
            {
                throw new Exception("mese errato");
            }
            int anno = 0;
            if (int.TryParse(dataNa.Substring(6, 4), out anno))
            {

            }
            else
            {
                throw new Exception("anno errato");
            }

            return (anno, mese, giorni);
        }

    }
}
