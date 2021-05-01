using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wcftestserver
{
    public class Utente
    {
        public string password { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public DateTime nascita { get; set; }
        public string email { get; set; }
        public string indirizzo { get; set; }
        public double? portafoglio { get; set; }

        public void loginEffettuato(dati_anagrafici login)
        {
            try
            {
                this.email = login.email;
                this.password = login.password;
                this.nome = login.nome;
                this.cognome = login.cognome;
                int i = 20140820;
                DateTime dt;
                if (DateTime.TryParseExact(login.nascita.ToString(), "yyyyMMdd",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None, out dt))
                {
                    Console.WriteLine(dt);
                }
                this.nascita = dt;
                this.indirizzo = login.indirizzo;
                this.portafoglio = login.portafoglio;
                if (this.portafoglio == null)
                {
                    this.portafoglio = 0;
                }
            }catch(Exception ex)
            {
                throw new Exception("metodo loginEffettuato: " + ex.Message);
            }
            
            
        }
    }
}
