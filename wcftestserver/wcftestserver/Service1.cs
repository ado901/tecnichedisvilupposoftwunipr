using System;
using System.Data.SqlClient;
using System.Linq;

namespace wcftestserver
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice e nel file di configurazione contemporaneamente.
    public class Service1 : IService1
    {
        public const string CONNECTIONSTRING = "Data Source=LAPTOP-VMPHGDB0\\TECNICHESVIL;Initial Catalog=tecnichedisvil;Integrated Security=True";
        public void DoWork()
        {
            Console.WriteLine("PROVA SERVER WCF");
        }

        public void Dowork1(string arg)
        {
            Console.WriteLine(arg);

        }

        public bool Login(Utente ut)

        {
            using (tecnichedisvilEntities db = new tecnichedisvilEntities())
            {
                try
                {
                    dati_anagrafici utente = db.dati_anagrafici.Where((x) => x.email == ut.email && x.password == ut.password).First();

                    ut.loginEffettuato(utente);

                    return true;
                }catch(Exception ex)
                {
                    Console.WriteLine("login fallito: "+ ex.Message);
                    return false;
                }
                
            }
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection())
            //    {
            //        conn.ConnectionString = CONNECTIONSTRING;
            //        conn.Open();
                    
            //        SqlCommand command = new SqlCommand("SELECT email, password FROM dbo.dati_anagrafici WHERE email='" + ut.email + "'and password='" + ut.password + "'", conn);
            //        var resultSet = command.ExecuteReader();
            //        if (resultSet.HasRows)
            //        {
            //            Console.WriteLine(ut.email);
            //            Console.WriteLine(ut.password);
            //            conn.Close();
            //            return true;
            //        }
            //        conn.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            return false;

        }

        public bool Registrazione(Utente ut)
        {
            using (tecnichedisvilEntities db = new tecnichedisvilEntities())
            {
                try
                {
                    long datanascita = long.Parse(ut.nascita.ToString("yyyyMMdd"));
                    dati_anagrafici utente = new dati_anagrafici()
                    {
                        email = ut.email,
                        password = ut.password,
                        nome = ut.nome,
                        cognome = ut.cognome,
                        nascita = datanascita,
                        indirizzo = ut.indirizzo,
                        portafoglio = ut.portafoglio
                    };
                    if(db.dati_anagrafici.Where((x) => x.email == ut.email).Any()){
                        throw new Exception("Email già presente nel sistema");
                    }
                    
                    db.dati_anagrafici.Add(utente);
                    db.SaveChanges();

                    ut.loginEffettuato(utente);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("registrazione fallita: " + ex.Message);
                    return false;
                }

            }
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection())
            //    {
            //        conn.ConnectionString = CONNECTIONSTRING;
            //        conn.Open();
            //        long datanascita = long.Parse(ut.nascita.ToString("yyyyMMdd"));
            //        ut.portafoglio = 0;
            //        SqlCommand command = new SqlCommand("INSERT INTO dbo.dati_anagrafici (cognome, nome, nascita, password, email, indirizzo, portafoglio) values " +
            //            "('" + ut.cognome + "','" + ut.nome + "','" + datanascita + "','" + ut.password + "','" + ut.email + "', '" + ut.indirizzo + "','" + ut.portafoglio + "')", conn);
            //        var prova = command.ExecuteNonQuery();
            //        if (prova != 0)
            //        {
            //            Console.WriteLine("registrazione effettuata");
            //            conn.Close();
            //            return true;
            //        }

            //        else
            //        {
            //            Console.WriteLine("registrazione fallita");
            //            conn.Close();
            //            return false;
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            return false;
        }
    }
}
