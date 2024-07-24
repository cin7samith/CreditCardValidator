using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Common.Interfaces
{
    public interface ICardTypeInfo
    {
        int Id { get; set; }
        string Name { get; set; }
        int Digits { get; set; }
        string RegEx { get; set; }
    }
}
