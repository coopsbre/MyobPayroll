﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyobPayrollEntitiesTwo : DbContext
    {
        public MyobPayrollEntitiesTwo()
            : base("name=MyobPayrollEntitiesTwo")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IncomeTaxRate> IncomeTaxRates { get; set; }
        public virtual DbSet<IncomeTaxRule> IncomeTaxRules { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<PaySlip> PaySlips { get; set; }
        public virtual DbSet<MonthYear> MonthYears { get; set; }
        public virtual DbSet<CalendarMonth> CalendarMonths { get; set; }
        public virtual DbSet<CalendarYear> CalendarYears { get; set; }
    }
}
