using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista1 = new List<int>();
            List<int> lista2 = new List<int>();
            Random rand = new Random();
            for (int i=0; i<10; i++)
            {
                lista1.Add(rand.Next(100));
                lista2.Add(rand.Next(100));
            }
            IEnumerable<int> query = lista1.Select(numero => numero);
            Console.WriteLine("LISTA1: {0}", string.Join(",", query.ToArray()));
            
            query = lista2.Select(numero => numero);
            Console.WriteLine("LISTA2: {0}", string.Join(",", query.ToArray()));

            query = lista1.Union(lista2);
            Console.WriteLine("UNIONE: {0}", string.Join(",", query.ToArray()));
            query = lista1.Intersect(lista2);
            Console.WriteLine("Intersezione: {0}", string.Join(",", query.ToArray()));
        }
    }
}
