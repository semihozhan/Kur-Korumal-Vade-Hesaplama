using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRate.Models
{
    public class GetDateandExchangeRateList
    {
        public GetDateandExchangeRateList(GetExchangeRateStart getExchangeRateStart, GetExchangeRateFinish getExchangeRateFinish)
        {
            GetDateandExchangeFinish = getExchangeRateFinish;
            GetDateandExchangeStart = getExchangeRateStart;
        }
        public GetExchangeRateFinish GetDateandExchangeFinish { get; set; }
        public GetExchangeRateStart GetDateandExchangeStart{ get; set; }
    }
}
