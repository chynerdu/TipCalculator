using Xunit;
using TipCalculator;

namespace TipCalculator.Test
{
    
public class TipsAndChequesaTests
{
     private readonly TipCalculator _tipsAndCheques = new TipCalculator();

        [Theory]
        [InlineData(100, 4, 25)]
        [InlineData(50, 2, 25)]
        [InlineData(200, 5, 40)]

        public void CalculateSplitAmount_ShouldReturnCorrectAmount(decimal amount, int numberOfPeople, decimal expectedResult)
        {
            var result = _tipsAndCheques.CalculateSplitAmount(amount, numberOfPeople);
            Assert.Equal(expectedResult, result);
        }



        [Fact]
        public void CalculateTipAmount_ShouldReturnCorrectTip()
        {
            var tipCalculator = new TipCalculator();
            var cost = new Dictionary<string, decimal>
            {
                { "Alice", 50m },
                { "Bob", 30m },
                { "Charlie", 20m }
            };
            var tipPercentage = 20f;
            var expectedTips = new Dictionary<string, decimal>
            {
                { "Alice", 10m },
                { "Bob", 6m },
                { "Charlie", 4m }
            };
            var actualTips = tipCalculator.CalculateTip(cost, tipPercentage);
            Assert.Equal(expectedTips, actualTips);
        }

        [Fact]
        public void CalculateTip_ShouldHandleEmptyDictionary()
        {
            var tipCalculator = new TipCalculator();
            var actualTips = tipCalculator.CalculateTip(new Dictionary<string, decimal>(), 20f);
            Assert.Empty(actualTips);
        }

        [Fact]
        public void CalculateTip_ShouldReturnArgumentExceptionForNegativeTipPercentage()
        {
            var tipCalculator = new TipCalculator();
            Assert.Throws<ArgumentException>(() => tipCalculator.CalculateTip(new Dictionary<string, decimal>(), -10f));
        }

        [Theory]
        [InlineData(100, 4, 20, 5)]
        [InlineData(200, 5, 15, 6)]
        [InlineData(150, 3, 10, 5)]
        public void CalculateIndividualTip_ShouldReturnCorrectAmount(decimal totalAmount, int numberOfPatrons, float tipPercentage, decimal expectedTipPerPerson)
        {
            var tipCalculator = new TipCalculator();
            decimal actualTipPerPerson = tipCalculator.IndividualTip(totalAmount, numberOfPatrons, tipPercentage);
            Assert.Equal(expectedTipPerPerson, actualTipPerPerson);
        }
}
}
