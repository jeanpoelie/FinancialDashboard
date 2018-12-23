using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinancialDashboard.Models;
using WebGrease.Css.Extensions;

namespace FinancialDashboard.Controllers
{
    public class HomeController : Controller
    {
        private test_paymentsEntities db = new test_paymentsEntities();
        private FinancialBusinessRules fbr = new FinancialBusinessRules();

        public ActionResult Index()
        {
            var model = new FinancialModel();
            var payments = db.bank_payments.ToList();

            // Calculate the line chart values
            model.FinancialLineChartModel = fbr.CreateFinancialLineChartModel(payments);

            // Calculate the bar chart values
            model.FinancialBarChartModel = fbr.CreateFinancialBarChartModel(payments);

            // Calculate the outgoing values
            model.FinancialOutgoingModel = fbr.CreateFinancialOutgoingModel(payments);

            // Calculate the radar chart values
            model.RadarChartModel = fbr.CreateRadarChartModel(payments);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}