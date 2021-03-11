using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            String testo = "CIAO A TUTTI";
            Console.WriteLine(testo);
            List<String> result= testo.Split(' ').ToList();
            List<String> inverted = new List<string>();
            result.ForEach(delegate (String x) {
                char[] array = x.ToCharArray();
                Array.Reverse(array);
                String parolainv = new String(array);
                inverted.Add(parolainv);
            });
            Console.WriteLine(System.String.Join(" ",inverted));

        }
    }
}
