using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Business
{
    public class CardValidationResponse:ICardValidationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }     
        public string CardNumber { get; set; }
        public string CardType { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
    }
}
