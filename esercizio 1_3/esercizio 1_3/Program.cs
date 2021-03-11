using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> dizionario = new Dictionary<int, List<int>>();
            Random rand = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                List<int> listainteri = new List<int>();
                for (int k=0; k<10; k++)
                {
                    listainteri.Add(rand.Next(10));
                }
                dizionario.Add(i, listainteri);
                
            }

           
            for ( int i=0; i<dizionario.Count(); i++)
            {
                Console.WriteLine("CHIAVE {0}", i);
                dizionario[i].ForEach(delegate (int x) {
                    Console.WriteLine(x);
                });
                if (i % 2 == 0)
                {
                    dizionario[i].Sort(); 
                }
                else
                {
                     dizionario[i]= dizionario[i].OrderByDescending(s=>s).ToList();
                }
            }
            for (int i=0; i< dizionario.Count(); i++)
            {
                Console.WriteLine("CHIAVE {0}", i);
                dizionario[i].ForEach(delegate (int x) {
                    Console.WriteLine(x);
                });
            }
        }
    }
}
