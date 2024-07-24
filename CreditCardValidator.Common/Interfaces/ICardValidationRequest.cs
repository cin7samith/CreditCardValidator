using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CreditCardValidator.Common.Interfaces
{

    public interface ICardValidationRequest
    {
        string CardNumber { get; set; }
    }
}
