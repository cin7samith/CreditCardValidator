using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditCardValidator.Business
{
    public class IdentifiableTypeRule : IValidationRule
    {
        private readonly IList<ICardTypeInfo> _cardTypeInfos;

        public IdentifiableTypeRule(IList<ICardTypeInfo> cardTypeInfos)
        {
            _cardTypeInfos = cardTypeInfos;
        }
        public ICardValidationResponse ValidateRule(string cardNumber)
        {
            string cardType=string.Empty;
            CardValidationResponse cardValidationResponse = new CardValidationResponse();
            foreach (var cardInfo in _cardTypeInfos)
            {
                if(cardInfo.Digits==cardNumber.Length && Regex.IsMatch(cardNumber, cardInfo.RegEx))
                {
                    cardType = cardInfo.Name;
                    
                    cardValidationResponse.Success = true;
                    cardValidationResponse.CreatedDateTime = DateTime.Now;
                    cardValidationResponse.Message = $"Card Number is a {cardType} type card";
                    cardValidationResponse.CardNumber = cardNumber;
                    cardValidationResponse.CardType = cardType;
                    return cardValidationResponse;
                }
            }
            cardValidationResponse.Success = false;
            cardValidationResponse.CreatedDateTime = DateTime.Now;
            cardValidationResponse.Message = "Invalid Characters in the Card Number";
            cardValidationResponse.CardNumber = cardNumber;
            return cardValidationResponse;
        }

    

    }
}
