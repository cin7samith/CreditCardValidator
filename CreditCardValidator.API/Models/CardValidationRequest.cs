using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardValidator.API.Models
{
    public class CardValidationRequest
    {
        public string CardNumber { get; set; }
    }
}