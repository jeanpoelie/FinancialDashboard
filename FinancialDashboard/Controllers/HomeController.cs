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

        public ActionResult Index()
        {
            var model = new FinancialModel();
            var payments = db.bank_payments.ToList();
            
            var unique_payment_dates = payments.Select(p => p.Datum).Distinct().OrderBy(p => p).ToList();
            var unique_payment_date_strings = new List<string>();
            var positivePayments = new List<decimal>();
            var negativePayments = new List<decimal>();
            foreach (var unique_payment_date in unique_payment_dates)
            {
                DateTime dtm = new DateTime();
                if (unique_payment_date != null)
                {
                    dtm = (DateTime) unique_payment_date;
                }

                unique_payment_date_strings.Add(dtm.ToLongDateString());

                positivePayments.Add(
                    payments
                        .Where(p => p.Af_Bij == "Bij" && 
                                    p.Datum == unique_payment_date)
                        .Select(p => p.Bedrag_EUR)
                        .Sum());

                negativePayments.Add(
                    payments
                        .Where(p => p.Af_Bij == "Af" &&
                                    p.Datum == unique_payment_date)
                        .Select(p => p.Bedrag_EUR)
                        .Sum());
            }
            
            
            model.FinancialLineChartModel = new FinancialLineChartModel
            {
                Labels = unique_payment_date_strings,
                PositivePayments = positivePayments,
                NegativePayments = negativePayments
            };
            
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