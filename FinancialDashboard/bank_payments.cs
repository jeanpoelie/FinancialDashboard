//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancialDashboard
{
    using System;
    using System.Collections.Generic;
    
    public partial class bank_payments
    {
        public int Id { get; set; }
        public string Datum_txt { get; set; }
        public string Naam_Omschrijving { get; set; }
        public string Rekening { get; set; }
        public string Tegenrekening { get; set; }
        public string Code { get; set; }
        public string Af_Bij { get; set; }
        public decimal Bedrag_EUR { get; set; }
        public string MutatieSoort { get; set; }
        public string Mededelingen { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
    }
}
