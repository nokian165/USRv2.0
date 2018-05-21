//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USRv2
{
    using System;
    using System.Collections.Generic;
    
    public partial class MainTables
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainTables()
        {
            this.NumericSamples = new HashSet<NumericSamples>();
        }
    
        public int Id { get; set; }
        public int PlcId { get; set; }
        public int LabelId { get; set; }
        public int TitleId { get; set; }
        public int UnitId { get; set; }
        public int IdAsc { get; set; }
        public bool IsContainer { get; set; }
        public string Container { get; set; }
        public bool IsOutOfView { get; set; }
    
        public virtual Labels Labels { get; set; }
        public virtual MainTableProperties MainTableProperties { get; set; }
        public virtual Plcs Plcs { get; set; }
        public virtual Titles Titles { get; set; }
        public virtual Units Units { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NumericSamples> NumericSamples { get; set; }
    }
}