using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listanumeri = new List<int>();
            Random rand = new Random();
            for (int i=0; i<10; i++)
            {
                listanumeri.Add(rand.Next(10));
              
            }
            Console.WriteLine("il massimo è: {0}, il minimo è: {1}, la somma è {2} ",listanumeri.Max(), listanumeri.Min(), listanumeri.Sum());
            listanumeri.ForEach(delegate (int x)
            {
                Console.WriteLine("l'elemento è: {0}",x);
            });
            for (int i= 0; i<listanumeri.Count(); i++){
                Console.WriteLine(i);
                if (i % 2 == 0 || i==0){
                    int tmp = listanumeri[i];
                    listanumeri[i] = listanumeri[i + 1];
                    listanumeri[i + 1] = tmp;

                }

                    
            }
            listanumeri.ForEach(delegate (int x)
            {
                Console.WriteLine("l'elemento è: {0}", x);
            });
        }
    }
}
