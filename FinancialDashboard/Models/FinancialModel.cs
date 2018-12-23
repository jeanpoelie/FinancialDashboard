using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialDashboard.Models
{
    public class FinancialModel
    {
        public FinancialLineChartModel FinancialLineChartModel { get; set; }

        public FinancialBarChartModel FinancialBarChartModel { get; set; }

        public FinancialOutgoingModel FinancialOutgoingModel { get; set; }

        public RadarChartModel RadarChartModel { get; set; }
    }

    public class FinancialLineChartModel
    {
        public List<string> Labels { get; set; }

        public List<decimal> PositivePayments { get; set; }
        
        public List<decimal> NegativePayments { get; set; }

    }

    public class FinancialBarChartModel
    {

        public List<string> Labels { get; set; }

        public List<decimal> Amounts { get; set; }
    }

    public class FinancialOutgoingModel
    {

        public List<string> Labels { get; set; }

        public List<decimal> Amounts { get; set; }
    }

    public class RadarChartModel
    {

        public List<string> Labels { get; set; }

        public List<decimal> Amounts { get; set; }
    }
}