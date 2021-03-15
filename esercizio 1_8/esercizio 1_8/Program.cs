using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_1_8
{


    class Program
    {

        static void Main(string[] args)
        {
            Random rand = new Random();
            DateTime start = new DateTime(2021, 1, 1);
            int range = (DateTime.Today - start).Days;
            List<DateTime> lista = new List<DateTime>();
            for (int i= 0; i<10; i++)
            {
                lista.Add(start.AddDays(rand.Next(range)));
            }
            IEnumerable<DateTime> query = lista.Select(date => date);
            Console.WriteLine("LISTA NORMALE");
            Console.WriteLine(string.Join(" | ", query.ToArray()));
            List<DateTime> listaordinata = lista.OrderBy(data => data).ToList();
            query =listaordinata.Select(data => data);
            Console.WriteLine("LISTA ORDINATA");
            Console.WriteLine(string.Join(" | ", query.ToArray()));
            for (int i=1; i< listaordinata.Count; i++)
            {
                Console.WriteLine("{0} - {1} in giorni = {2}", listaordinata[i].ToString(), listaordinata[i-1].ToString(), differenzadate(listaordinata[i], listaordinata[i-1]));
            }
        }

         private static int differenzadate(DateTime data1, DateTime data2)
        {
            int differenza = (data1 - data2).Days;
            return differenza;
        }
        
    }
}
