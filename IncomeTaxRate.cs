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
    
    public partial class IncomeTaxRate
    {
        public int IncomeTaxRateID { get; set; }
        public int IncomeYear { get; set; }
        public int LowBand { get; set; }
        public Nullable<int> HighBand { get; set; }
        public Nullable<int> IncomeTaxRuleId { get; set; }
    
        public virtual IncomeTaxRule IncomeTaxRule { get; set; }
    }
}
