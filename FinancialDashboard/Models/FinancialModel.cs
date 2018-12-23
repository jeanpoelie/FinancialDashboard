using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialDashboard.Models
{
    public class FinancialModel
    {
        public FinancialLineChartModel FinancialLineChartModel { get; set; }
    }

    public class FinancialLineChartModel
    {
        public List<string> Labels { get; set; }

        public List<decimal> PositivePayments { get; set; }
        
        public List<decimal> NegativePayments { get; set; }

    }
}