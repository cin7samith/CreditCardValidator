using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditCardValidator.Business
{
    public class AllNumbersRule : IValidationRule
    {
        public ICardValidationResponse ValidateRule(string cardNumber)
        {
            CardValidationResponse cardValidationResponse = new CardValidationResponse();
            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(cardNumber))
            {
                cardValidationResponse.Success = false;
                cardValidationResponse.CreatedDateTime = DateTime.Now;
                cardValidationResponse.Message = "Invalid Characters in the Card Number";
                cardValidationResponse.CardNumber = cardNumber;
                return cardValidationResponse;
            }
            else
            {
                cardValidationResponse.Success = true;
                cardValidationResponse.CreatedDateTime = DateTime.Now;
                cardValidationResponse.Message = "Card Number is Valid";
                cardValidationResponse.CardNumber = cardNumber;
                return cardValidationResponse;
            }
        }
    }
}
