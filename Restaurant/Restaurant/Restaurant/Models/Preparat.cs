//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Preparat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Preparat()
        {
            this.Comanda_Preparat_Aux = new HashSet<Comanda_Preparat_Aux>();
            this.Meniu_Preparat_Aux = new HashSet<Meniu_Preparat_Aux>();
            this.Preparat_Alergen_Aux = new HashSet<Preparat_Alergen_Aux>();
        }
    
        public int id_preparat { get; set; }
        public string nume_preparat { get; set; }
        public double pret { get; set; }
        public double cantitate_meniu { get; set; }
        public double cantitate_totala { get; set; }
        public string fotografie { get; set; }
        public int categorie_id { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comanda_Preparat_Aux> Comanda_Preparat_Aux { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meniu_Preparat_Aux> Meniu_Preparat_Aux { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Preparat_Alergen_Aux> Preparat_Alergen_Aux { get; set; }
    }
}
