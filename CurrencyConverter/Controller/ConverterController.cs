using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverter.Model;

namespace CurrencyConverter.Controller
{
    class ConverterController
    {
        public double NBUConvert(string baseCurrency, string convertedCurrency, double amount)
        {
            ParserController parser = new ParserController();

            parser.FillCurrencyRateNbu();

            if (baseCurrency.Equals("UAH") || convertedCurrency.Equals("UAH"))
            {
                return parser.GetCurrencyRateNBU(baseCurrency, convertedCurrency) * amount;
            }
            
            return parser.GetCurrencyCrossRateNBU(baseCurrency, convertedCurrency) * amount;
        }

        public double PrivatBankConvert(string baseCurrency, string convertedCurrency, double amount)
        {
            ParserController parser = new ParserController();

            parser.FillCurrencyRatePrivat();

            if (baseCurrency.Equals("UAH") || convertedCurrency.Equals("UAH"))
            {
                return parser.GetCurrencyRatePrivat(baseCurrency, convertedCurrency) * amount;
            }
            
            return parser.GetCurrencyCrossRatePrivat(baseCurrency, convertedCurrency) * amount;
        }
    }
}
