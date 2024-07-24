using System;
using System.Linq;
using Xunit;
using CreditCardValidator.Business;

namespace CreditCardValidator.Business.Test
{
    public class AllNumbersRuleTests
    {
        [Fact]
        public void ValidateRule_ValidNumericCardNumber_ReturnsValidResponse()
        {
            // Arrange
            var rule = new AllNumbersRule();
            string validCardNumber = "1234567890123457";

            // Act
            var response = rule.ValidateRule(validCardNumber);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal("Card Number is Valid", response.Message);
            Assert.Equal(validCardNumber, response.CardNumber);           
        }

        [Fact]
        public void ValidateRule_InvalidAlphaNumericCardNumber_ReturnsErrorResponse()
        {
            // Arrange
            var rule = new AllNumbersRule();
            string invalidCardNumber = "1234abcd56789092";

            // Act
            var response = rule.ValidateRule(invalidCardNumber);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.Equal("Invalid Characters in the Card Number", response.Message);
            Assert.Equal(invalidCardNumber, response.CardNumber);
        }
        
    }
}
