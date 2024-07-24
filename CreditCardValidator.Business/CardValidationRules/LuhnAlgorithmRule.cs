using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Business
{
    public class LuhnAlgorithmRule : IValidationRule
    {
        public ICardValidationResponse ValidateRule(string cardNumber)
        {
            CardValidationResponse cardValidationResponse = null;
            int nDigits = cardNumber.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = int.Parse(cardNumber[i].ToString());

                if (isSecond == true)
                    d = d * 2;

                //// We add two digits to handle
                //// cases that make two digits after
                //// doubling
                //nSum += d / 10;
                //nSum += d % 10;

                if (d > 9)
                    d -= 9;
                nSum += d;

                isSecond = !isSecond;
            }
            if (nSum % 10 == 0)
            {
                cardValidationResponse = new CardValidationResponse()
                {
                    CardNumber = cardNumber,
                    CreatedDateTime = DateTime.Now,
                    Message = "Card Number is Valid",
                    Success = true
                };
                return cardValidationResponse;
            }
            else
            {
                cardValidationResponse = new CardValidationResponse()
                {
                    CardNumber = cardNumber,
                    CreatedDateTime = DateTime.Now,
                    Message = "Card Number is Invalid",
                    Success = false
                };
                return cardValidationResponse;
             }           
        }
    }
}
