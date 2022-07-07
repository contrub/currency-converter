using System;
using System.Collections.Generic;
using System.IO;
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
            double currencyRate;

            parser.FillCurrencyRatesNbu();

            currencyRate = parser.GetCurrencyRateNBU(baseCurrency, convertedCurrency);

            Logger.Write(baseCurrency, convertedCurrency, currencyRate, "NBU", ApiController.GetNBUUrl());

            return currencyRate * amount;
        }

        public double PrivatBankConvert(string baseCurrency, string convertedCurrency, double amount)
        {
            ParserController parser = new ParserController();
            double currencyRate;

            parser.FillCurrencyRatesPrivat();

            currencyRate = parser.GetCurrencyRatePrivat(baseCurrency, convertedCurrency);

            Logger.Write(baseCurrency, convertedCurrency, currencyRate, "PrivatBank", ApiController.GetPrivatUrl());

            return currencyRate * amount;
        }
    }
}
