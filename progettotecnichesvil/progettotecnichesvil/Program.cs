using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progettotecnichesvil
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loggato = false;
            try
            {
                var wcf = new ServiceReference1.Service1Client();
                Console.WriteLine("wcf creato");
                try
                {
                    Console.WriteLine("tentativo di connessione...");
                    wcf.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connessione fallita: " + ex.Message);
                }

                wcf.DoWork();
                wcf.Dowork1("ciao Andrea");
                Console.WriteLine("MENU'");
                bool loop = true;
                ServiceReference1.Utente ut = new ServiceReference1.Utente();
                while (loop)
                {
                    
                        switch (loggato)
                    {
                        case false:
                            
                            Console.WriteLine("1. Registrazione");
                            Console.WriteLine("2. LOGIN");
                            
                            var key = Console.ReadKey();
                            Console.WriteLine("\n");
                            try
                            {
                                switch (key.KeyChar)
                                {
                                    //REGISTRAZIONE
                                    case '1':

                                        Console.WriteLine("Inserisci il email:");
                                        string email = Console.ReadLine();

                                        //se non va lancia eccezione
                                        Utility.IsValidEmail(email);
                                        ut.email = email;

                                        Console.WriteLine("Inserisci il password:");
                                        string inputString = Console.ReadLine();

                                        //criptazione sha256
                                        byte[] data = Encoding.ASCII.GetBytes(inputString);
                                        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                                        ut.password = Encoding.ASCII.GetString(data);

                                        Console.WriteLine("Inserisci il nome:");
                                        ut.nome = Console.ReadLine();

                                        Console.WriteLine("Inserisci il cognome:");
                                        ut.cognome = Console.ReadLine();

                                        Console.WriteLine("Inserisci  dataNascita: dd/mm/aaaa");
                                        string dataNa = Console.ReadLine();
                                        var datanascita = Utility.checkData(dataNa);
                                        ut.nascita = new DateTime(datanascita.Item1, datanascita.Item2, datanascita.Item3);

                                        Console.WriteLine("Inserisci  l indirizzo ");
                                        ut.indirizzo = Console.ReadLine();

                                        ut.portafoglio = 0;
                                        var registrazione = wcf.Registrazione(ut);
                                        if (registrazione.Item1)
                                        {
                                            Console.WriteLine("registrazione avvenuta");
                                            loggato = true;
                                            ut = registrazione.Item2;
                                        }
                                        else
                                        {
                                            Console.WriteLine("registrazione fallita");
                                        }
                                        break;


                                    //LOGIN
                                    case '2':
                                        Console.WriteLine("tentativo di login");
                                        ServiceReference1.Utente utenteregistrato = new ServiceReference1.Utente();
                                        Console.WriteLine("inserire email:");
                                        utenteregistrato.email = Console.ReadLine();
                                        Console.WriteLine("inserire password:");
                                        //criptazione sha256
                                        string inputString1 = Console.ReadLine();
                                        byte[] data1 = Encoding.ASCII.GetBytes(inputString1);
                                        data1 = new System.Security.Cryptography.SHA256Managed().ComputeHash(data1);
                                        utenteregistrato.password = Encoding.ASCII.GetString(data1);
                                        var login = wcf.Login(utenteregistrato);
                                        if (login.Item1)
                                        {
                                            Console.WriteLine("login effettuato");
                                            loggato = true;
                                            ut = login.Item2;
                                        }
                                        else
                                        {
                                            throw new Exception("Login fallito, email o password errati");
                                        }
                                        break;

                                    default:
                                        loop = false;
                                        break;
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Errore: " + ex.Message + "\npremere un tasto per continuare");
                                Console.ReadKey();
                            }

                            
                            break;



                        case true:
                            Console.WriteLine("Utente " + ut.nome + " " + ut.cognome+", benvenuto");
                            Console.ReadLine();
                            loop = false;
                            break;

                    }
                    

                }






            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                Console.ReadLine();
            }

        }


    
}
}
