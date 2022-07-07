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
            LogController logger = new LogController();
            DateTime dateTime = DateTime.Now;
            double currencyRate;

            parser.FillCurrencyRateNbu();

            currencyRate = parser.GetCurrencyRateNBU(baseCurrency, convertedCurrency);

            string value = string.Format("{0} - {1} - {2} - {3} - {4} - {5}",
                    dateTime.ToShortDateString(), dateTime.TimeOfDay,
                    baseCurrency, convertedCurrency,
                    "NBU", currencyRate
                    );
            logger.Write(value);

            return currencyRate * amount;
        }

        public double PrivatBankConvert(string baseCurrency, string convertedCurrency, double amount)
        {
            ParserController parser = new ParserController();
            LogController logger = new LogController();
            DateTime dateTime = DateTime.Now;
            double currencyRate;

            parser.FillCurrencyRatePrivat();

            currencyRate = parser.GetCurrencyRatePrivat(baseCurrency, convertedCurrency);

            string value = string.Format("{0} - {1} - {2} - {3} - {4} - {5}",
                    dateTime.ToShortDateString(), dateTime.TimeOfDay,
                    baseCurrency, convertedCurrency,
                    "PrivatBank", currencyRate
                    );
            logger.Write(value);

            return currencyRate * amount;
        }
    }
}
