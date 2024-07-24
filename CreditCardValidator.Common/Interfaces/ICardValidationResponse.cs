using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Common.Interfaces
{
    public interface ICardValidationResponse
    {
        string CardNumber { get; set; }
        string CardType { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
        DateTime CreatedDateTime { get; set; }
    }
}
