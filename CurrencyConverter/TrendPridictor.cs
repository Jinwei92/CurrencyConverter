using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class TrendPridictor
    {
        private Rates rates;
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public TrendPridictor(Rates rates, string baseCurrency, string targetCurrency)
        {
            this.rates = rates;
            BaseCurrency = baseCurrency;
            TargetCurrency = targetCurrency;
        }
        public void Analyser()
        {

        }
    }
}
