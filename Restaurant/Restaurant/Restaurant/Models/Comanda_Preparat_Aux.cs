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
    
    public partial class Comanda_Preparat_Aux
    {
        public int id_comanda_preparat { get; set; }
        public int comanda_id { get; set; }
        public int preparat_id { get; set; }
    
        public virtual Comanda Comanda { get; set; }
        public virtual Preparat Preparat { get; set; }
    }
}