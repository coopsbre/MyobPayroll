//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyobPayroll
{
    using System;
    using System.Collections.Generic;
    
    public partial class IncomeTaxRule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IncomeTaxRule()
        {
            this.IncomeTaxRates = new HashSet<IncomeTaxRate>();
        }
    
        public int IncomeTaxRuleID { get; set; }
        public int StartAmount { get; set; }
        public decimal SeedAmount { get; set; }
        public int OverIncomeAmount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomeTaxRate> IncomeTaxRates { get; set; }
    }
}
