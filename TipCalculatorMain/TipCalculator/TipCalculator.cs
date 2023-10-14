

using System;
using System.Collections.Generic;

namespace TipCalculator
{
    public class TipCalculator
{
 public decimal CalculateSplitAmount(decimal amt, int noOfPeople)
 {
    if(noOfPeople<1){
        throw new ArgumentException("people must not be less than 1");
    }
    return Math.Round(amt/noOfPeople, 2);
 }

   public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> costs, float percentage)
        {
            if (percentage < 0) throw new ArgumentException("Tip percentage cannot be negative");
            
            var totalCost = 0m;
            foreach (var cost in costs.Values)
            {
                totalCost += cost;
            }
            
            var tipAmounts = new Dictionary<string, decimal>();
            foreach (var entry in costs)
            {
                var name = entry.Key;
                var cost = entry.Value;
                var individualTip = Math.Round(cost / totalCost * (decimal)percentage / 100 * totalCost, 2);
                tipAmounts[name] = individualTip;
            }
            
            return tipAmounts;
        }

        public decimal IndividualTip(decimal totalAmount, int numberOfPatrons, float Percentage)
        {
            if (numberOfPatrons <= 0) throw new ArgumentException("Number of patrons must be greater than 0");
            if (Percentage < 0) throw new ArgumentException("Tip percentage cannot be negative");

            decimal totalTip = totalAmount * (decimal)Percentage / 100;
            decimal tipPerPerson = totalTip / numberOfPatrons;
            
            return Math.Round(tipPerPerson, 2);
        }
    }


}