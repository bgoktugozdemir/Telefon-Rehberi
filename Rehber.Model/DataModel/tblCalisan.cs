//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rehber.Model.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCalisan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCalisan()
        {
            this.tblCalisan1 = new HashSet<tblCalisan>();
        }
    
        public int ID { get; set; }
        public string Telefon { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<int> DepartmanID { get; set; }
        public Nullable<int> YoneticiID { get; set; }
    
        public virtual tblDepartman tblDepartman { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCalisan> tblCalisan1 { get; set; }
        public virtual tblCalisan tblCalisan2 { get; set; }
    }
}
