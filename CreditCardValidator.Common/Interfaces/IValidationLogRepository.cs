using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Common.Interfaces
{
    public interface IValidationLogRepository
    {
        bool Add(string cardNumber,bool status, string message,DateTime createDateTime);
    }
}
