//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace server
{
    using System;
    using System.Collections.Generic;
    
    public partial class commesso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public commesso()
        {
            this.transazioni = new HashSet<transazioni>();
        }
    
        public long codice_commesso { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public int nprenotazioni { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transazioni> transazioni { get; set; }
    }
}
