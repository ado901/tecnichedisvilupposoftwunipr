using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace client1
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                var wcf = new ServiceReference1.Service1Client();
                Console.WriteLine("wcf creato");
                try
                {
                    Console.WriteLine("tentativo di connessione...");
                    wcf.Open();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Connessione fallita: " + ex.Message);
                }
                
                wcf.DoWork();
                wcf.Dowork1("ciao Andrea");
                Console.WriteLine("MENU'");
                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("1. Registrazione");
                    Console.WriteLine("2. LOGIN");
                    var key = Console.ReadKey();

                    switch (key.KeyChar)
                    {
                        case '1':
                            ServiceReference1.Utente ut = new ServiceReference1.Utente();
                            Console.WriteLine("Inserisci il email:");
                            ut.email = Console.ReadLine();
                            //if (IsValidEmail(ut.email))
                            //{
                            //    Console.WriteLine("email non valida");
                            //    break;
                            //}
                            Console.WriteLine("Inserisci il password:");
                            ut.password = Console.ReadLine();
                            Console.WriteLine("Inserisci il nome:");
                            ut.nome = Console.ReadLine();
                            Console.WriteLine("Inserisci il cognome:");
                            ut.cognome = Console.ReadLine();
                            Console.WriteLine("Inserisci  dataNascita: dd/mm/aaaa");
                            string dataNa = Console.ReadLine();
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
                                    throw new Exception("Inserire un valore per i mese compreso tra 1 e 12");
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


                            ut.nascita = new DateTime(anno, mese, giorni);
                            Console.WriteLine("Inserisci  l indirizzo ");
                            ut.indirizzo = Console.ReadLine();
                            ut.portafoglio = 0;
                            var registrazione = wcf.Registrazione(ut);
                            if (registrazione)
                            {
                                Console.WriteLine("registrazione avvenuta");
                            }
                            else
                            {
                                Console.WriteLine("registrazione fallita");
                            }
                            break;

                        case '2':
                            Console.WriteLine("tentativo di login");
                            ServiceReference1.Utente utenteregistrato = new ServiceReference1.Utente();
                            Console.WriteLine("inserire email:");
                            utenteregistrato.email = Console.ReadLine();
                            Console.WriteLine("inserire password:");
                            utenteregistrato.password = Console.ReadLine();
                            if (wcf.Login(utenteregistrato))
                            {
                                Console.WriteLine("login effettuato");
                            }
                            else
                            {
                                Console.WriteLine("login fallito");
                            }
                            break;

                        default:
                            loop= false;
                            break;
                    }

                }
                



                        
                        
                } catch( Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
            }

        }


        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
