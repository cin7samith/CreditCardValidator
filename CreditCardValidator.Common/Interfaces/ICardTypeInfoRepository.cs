using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Common.Interfaces
{
    public interface ICardTypeInfoRepository
    {
        List<ICardTypeInfo> GetAll();
    }
}
