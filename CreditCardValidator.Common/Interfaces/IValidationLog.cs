using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Common.Interfaces
{
    public interface IValidationLog
    {
        string CardNumber { get; set; }
        bool Status { get; set; }
        string Message { get; set; }
        DateTime CreateDateTime { get; set; }
    }
}
