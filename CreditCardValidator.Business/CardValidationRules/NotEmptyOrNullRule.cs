using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Business
{
    public class NotEmptyOrNullRule : IValidationRule
    {
        public ICardValidationResponse ValidateRule(string cardNumber)
        {
            CardValidationResponse cardValidationResponse = new CardValidationResponse();
            if (string.IsNullOrEmpty(cardNumber))
            {
                cardValidationResponse.Success = false;
                cardValidationResponse.CreatedDateTime = DateTime.Now;
                cardValidationResponse.Message = "Card Number is Empty";
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
