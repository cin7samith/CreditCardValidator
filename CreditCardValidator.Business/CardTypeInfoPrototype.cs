using CreditCardValidator.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Business
{
    public class CardTypeInfoPrototype
    {
        public List<ICardTypeInfo> CardTypeInfos { get; set; }

        public List<ICardTypeInfo> Clone()
        {
            var serialized = JsonConvert.SerializeObject(CardTypeInfos);
            return JsonConvert.DeserializeObject<List<ICardTypeInfo>>(serialized);
        }
    }
}
