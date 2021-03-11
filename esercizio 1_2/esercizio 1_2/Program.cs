using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> listaparole = new List<String>() { "ciao","amore", "come", "va","anziano", "tutto", "bene", "ahahahah", "sillaba", "lama", "malafede" };
            List<String> listaa = new List<String>();
            List<String> listala = new List<String>();
            listaparole.ForEach(delegate (String parola)
            {
                if (parola.ElementAt(0)=='a')
                {
                    listaa.Add(parola);
                }
                if (parola.Contains("la"))
                {
                    listala.Add(parola);
                }
            });
            Console.WriteLine("lista a:");
            listaa.ForEach(delegate (String element)
            {
                Console.WriteLine(element);
            });
            listala.Sort();
            Console.WriteLine("lista la ordinata:");
            listala.ForEach(delegate (String element)
            {
                Console.WriteLine(element);
            });
        }
    }
}
