using dev.budget.business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Models
{
    public class BudgetModel
    {
        public decimal Calculate(Budget budget)
        {
            var result = CalculateDev(budget.DevCount);
            result += CalculateDesigner(budget.DesignerCount);
            result += CalculatePO(budget.POCount);
            result += CalculateSM(budget.SMCount);
            result += CalculateDuration(budget.Duration);
            return result;
        }

        public decimal CalculateDev(decimal count)
        {
            var devPrice = Decimal.Multiply( 1000, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.15);
            return devPrice + add;
        }

        public decimal CalculateDesigner(decimal count)
        {
            var devPrice = Decimal.Multiply(1000, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.05);
            return devPrice + add;
        }

        public decimal CalculateSM(decimal count)
        {
            var devPrice = Decimal.Multiply(900, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.12);
            return devPrice + add;
        }

        public decimal CalculatePO(decimal count)
        {
            var devPrice = Decimal.Multiply(1500, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.1);
            return devPrice + add;
        }

        public decimal CalculateDuration(decimal count)
        {
            return Decimal.Multiply(200,count);
        }
    }
}
