using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Common.Interfaces
{
    public interface IValidationRule
    {
        ICardValidationResponse ValidateRule(string cardNumber);
    }
}
