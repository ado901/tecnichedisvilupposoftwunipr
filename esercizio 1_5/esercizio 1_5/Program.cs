using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int k;
            int m;
            List<int> lista = new List<int>() { 20, 30, 50, 12, 3345, 2, 1, 0, 44, 54, 366, 246, 853, 267, 22, 666 };
            k = 3;
            int nliste = lista.Count() / k+ lista.Count%k;
            List<List<int>> elencoliste = new List<List<int>>();
            for (int i=0; i<nliste; i++)
            {
                List<int> listak = new List<int>();
                for(int n=k*i; n<k*i+3 && n< lista.Count(); n++)
                {
                    listak.Add(lista[n]);
                    

                }
                elencoliste.Add(listak);

            }
            int index = 0;
            foreach (List<int> elemento in elencoliste)
            {
                Console.WriteLine("indice {0}", index);
                elemento.ForEach(delegate (int x)
                {
                    Console.WriteLine(x);
                });
                index++;
            }

        }
    }
}
