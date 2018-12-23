using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialDashboard.Models;

namespace FinancialDashboard.Controllers
{
    public class FinancialBusinessRules
    {
        public FinancialLineChartModel CreateFinancialLineChartModel(List<bank_payments> payments)
        {
            var uniquePaymentDates = payments.Select(p => p.Datum).Distinct().OrderBy(p => p).ToList();
            var uniquePaymentDateStrings = new List<string>();
            var positivePayments = new List<decimal>();
            var negativePayments = new List<decimal>();
            foreach (var uniquePaymentDate in uniquePaymentDates)
            {
                DateTime dtm = new DateTime();
                if (uniquePaymentDate != null)
                {
                    dtm = (DateTime)uniquePaymentDate;
                }

                uniquePaymentDateStrings.Add(dtm.ToLongDateString());

                positivePayments.Add(
                    payments
                        .Where(p => p.Af_Bij == "Bij" &&
                                    p.Datum == uniquePaymentDate)
                        .Select(p => p.Bedrag_EUR)
                        .Sum());

                negativePayments.Add(
                    payments
                        .Where(p => p.Af_Bij == "Af" &&
                                    p.Datum == uniquePaymentDate)
                        .Select(p => p.Bedrag_EUR)
                        .Sum());
            }

            return new FinancialLineChartModel
            {
                Labels = uniquePaymentDateStrings,
                PositivePayments = positivePayments,
                NegativePayments = negativePayments
            };
        }

        public FinancialBarChartModel CreateFinancialBarChartModel(List<bank_payments> payments)
        {
            var uniqueCategoryIds = payments.Select(p => p.Category_Id).Distinct().OrderBy(p => p).ToList();
            var uniqueCategoryNames = new List<string>();
            var amountList = new List<decimal>();

            foreach (var uniqueCategoryId in uniqueCategoryIds)
            {
                if (!uniqueCategoryNames.Contains(
                        payments.Where(p => p.Category_Id == uniqueCategoryId)
                                .Select(p => p.bank_categories.bank_category_name)
                                .FirstOrDefault()))
                {
                    uniqueCategoryNames.Add(
                        payments.Where(p => p.Category_Id == uniqueCategoryId)
                            .Select(p => p.bank_categories.bank_category_name)
                            .FirstOrDefault());
                }

                amountList.Add(
                    payments
                        .Where(p => p.Category_Id == uniqueCategoryId)
                        .Select(p => 
                                p.Af_Bij == "Af" ? 
                                    p.Bedrag_EUR * -1 : 
                                    p.Bedrag_EUR
                                )
                        .Sum());
            }

            return new FinancialBarChartModel
            {
                Labels = uniqueCategoryNames,
                Amounts = amountList
            };
        }

        public FinancialOutgoingModel CreateFinancialOutgoingModel(List<bank_payments> payments)
        {
            var uniqueCategoryIds = payments.Select(p => p.Category_Id).Distinct().OrderBy(p => p).ToList();
            var uniqueCategoryNames = new List<string>();
            var amountList = new List<decimal>();

            foreach (var uniqueCategoryId in uniqueCategoryIds)
            {
                if (!uniqueCategoryNames.Contains(
                    payments.Where(p => p.Category_Id == uniqueCategoryId)
                        .Select(p => p.bank_categories.bank_category_name)
                        .FirstOrDefault()))
                {
                    uniqueCategoryNames.Add(
                        payments.Where(p => p.Category_Id == uniqueCategoryId)
                            .Select(p => p.bank_categories.bank_category_name)
                            .FirstOrDefault());
                }

                amountList.Add(
                    payments
                        .Where(p => p.Category_Id == uniqueCategoryId)
                        .Where(p => p.Af_Bij == "Af")
                        .Select(p => p.Bedrag_EUR * -1)
                        .Sum());
            }

            return new FinancialOutgoingModel
            {
                Labels = uniqueCategoryNames,
                Amounts = amountList
            };
        }



        public RadarChartModel CreateRadarChartModel(List<bank_payments> payments)
        {
            var uniqueCategoryIds = payments.Select(p => p.Category_Id).Distinct().OrderBy(p => p).ToList();
            var uniqueCategoryNames = new List<string>();
            var amountList = new List<decimal>();

            foreach (var uniqueCategoryId in uniqueCategoryIds)
            {
                if (!uniqueCategoryNames.Contains(
                    payments.Where(p => p.Category_Id == uniqueCategoryId)
                        .Select(p => p.bank_categories.bank_category_name)
                        .FirstOrDefault()))
                {
                    uniqueCategoryNames.Add(
                        payments.Where(p => p.Category_Id == uniqueCategoryId)
                            .Select(p => p.bank_categories.bank_category_name)
                            .FirstOrDefault());
                }

                amountList.Add(
                    payments
                        .Where(p => p.Category_Id == uniqueCategoryId)
                        .Where(p => p.Af_Bij == "Af")
                        .Select(p => p.Bedrag_EUR)
                        .Sum());
            }

            return new RadarChartModel
            {
                Labels = uniqueCategoryNames,
                Amounts = amountList
            };
        }
    }
}