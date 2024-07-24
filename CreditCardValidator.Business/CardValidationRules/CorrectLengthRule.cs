using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Business
{
    public class CorrectLengthRule : IValidationRule
    {
        public ICardValidationResponse ValidateRule(string cardNumber)
        {
            CardValidationResponse cardValidationResponse = new CardValidationResponse();
            if (cardNumber.Length!=15 && cardNumber.Length!=16)
            {
                cardValidationResponse.Success = false;
                cardValidationResponse.CreatedDateTime = DateTime.Now;
                cardValidationResponse.Message = "Invalid Card Number Length";
                cardValidationResponse.CardNumber = cardNumber;
                return cardValidationResponse;
            }
            else
            {
                cardValidationResponse.Success = true;
                cardValidationResponse.CreatedDateTime = DateTime.Now;
                cardValidationResponse.Message = "Card Number Length is Valid";
                cardValidationResponse.CardNumber = cardNumber;
                return cardValidationResponse;
            }
        }
    }
}
