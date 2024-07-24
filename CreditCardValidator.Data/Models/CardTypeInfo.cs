using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Data.Models
{
    public class CardTypeInfo : ICardTypeInfo
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
        public int Digits { get; set; }
        public string RegEx { get ; set; }
    }
}
