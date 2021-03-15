using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista1 = new List<int>() { 1, 2, 3 };
            List<int> lista2 = new List<int>() { 4, 5, 6 };
            List<int> lista3 = new List<int>() { 7, 8, 9 };
            List<int> lista4 = new List<int>() { 10, 11, 12 };

            List<List<int>> lista = new List<List<int>>() { lista1,lista2,lista3,lista4};

            List<int> unione = new List<int>();
            IEnumerable<int> query= null;
            for (int i = 0; i < lista.Count(); i++)
            {

                query = unione.Union(lista[i]);
                foreach (int numero in lista[i])
                {
                    unione.Add(numero);
                }
            }
            unione = query.ToList();
            foreach(int numero in query)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
