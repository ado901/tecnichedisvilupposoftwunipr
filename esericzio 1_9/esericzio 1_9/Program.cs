using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace esericzio_1_9
{
    class Program
    {
        private static Random random = new Random();
        public static void CreateText(string path)
        {
            for (int i = 0; i < 20; i++)
            {
                string newpath = Path.Combine(path, ("test" + i+".txt"));
                if (File.Exists(newpath))
                {
                    File.Delete(newpath);
                }
                using (FileStream fs = File.Create(newpath))
                {
                    // Add some text to file    
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    char[] randomstr = Enumerable.Repeat(chars, random.Next(100000, 1799999)).Select(s => s[random.Next(s.Length)]).ToArray();
                    string[] prova= Enumerable.Repeat(chars, random.Next(100000, 1799999)).ToArray();
                    Byte[] title = new UTF8Encoding(true).GetBytes(randomstr);
                    fs.Write(title, 0, title.Length);
                }
            }
        }
        static void Main(string[] args)
        {
            const string PATH = @"C:\prova";
            if (!Directory.EnumerateFileSystemEntries(PATH).Any())
            {
                CreateText(PATH);
            }
            
            string[] files = Directory.GetFiles(PATH);
            List<Datofile> listaminori = new List<Datofile>();
            List<Datofile> listatotali = new List<Datofile>();
            foreach (string file in files)
            {
                if (file.EndsWith(".txt"))
                {

                
                    int text;
                    using (var stream = File.OpenRead(file))
                    {
                        text = (int) stream.Length;
                        if (text< 1000000)
                        {
                            listaminori.Add(new Datofile(file,text));

                        }
                        listatotali.Add(new Datofile(file, text));

                }
                }
            }
            Console.WriteLine("NUMERO FILE: " + listatotali.Count() + "\n" + "Lista dei file: ");
            foreach (Datofile file in listatotali)
            {
                Console.WriteLine(file.nome + " con dimensione: " + (float)file.dimensione / 1000000f + "MB");
            }
            Console.WriteLine("NUMERO FILE MINORI DI 1 MB: " + listaminori.Count()+ "\n" + "Lista dei file: ");
            foreach (Datofile file in listaminori)
            {
                Console.WriteLine(file.nome + " con dimensione: " + (float)file.dimensione / 1000000f + "MB");
            }
        }
    }
    class Datofile
    {
        public string nome { get; }
        public int dimensione { get; }
        public Datofile(string nome, int dimensione)
        {
            this.nome = nome;
            this.dimensione = dimensione;
        }
    }
}
