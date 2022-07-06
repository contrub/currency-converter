using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;

using CurrencyConverter.Model;

namespace CurrencyConverter
{
    class ParserController
    {
        private List<NBURate> currencyRateNbu;
        private List<PrivatBankRate> currencyRatePrivat;

        public void FillCurrencyRateNbu()
        {
            ApiController API = new ApiController();
            string jsonResponse;

            API.MakeRequestToCurrentDay();

            using (WebResponse webResponse = API.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(dataStream);
                    jsonResponse = streamReader.ReadToEnd();
                }
            }

            currencyRateNbu = JsonConvert.DeserializeObject<List<NBURate>>(jsonResponse);
        }

        public void FillCurrencyRatePrivat()
        {
            ApiController API = new ApiController();
            string jsonResponse;

            API.MakeRequestToCurrentDatePrivat();

            using (WebResponse webResponse = API.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(dataStream);
                    jsonResponse = streamReader.ReadToEnd();
                }
            }

            currencyRatePrivat = JsonConvert.DeserializeObject<List<PrivatBankRate>>(jsonResponse);
        }

        public List<NBURate> GetCurrencyRatesNbu()
        {
            return currencyRateNbu;
        }

        public List<PrivatBankRate> GetCurrencyRatesPrivat()
        {
            return currencyRatePrivat;
        }

        public double GetCurrencyRateNBU(string baseCurrency, string convertedCurrency)
        {
            double curerncyRate = 1;

            if (baseCurrency.Equals(convertedCurrency))
            {
                return curerncyRate;
            }

            foreach (NBURate rate in currencyRateNbu)
            {
                if (rate.cc == baseCurrency)
                {
                    curerncyRate = rate.rate;
                    break;
                } 
                else if (rate.cc == convertedCurrency)
                {
                    curerncyRate = 1 / rate.rate;
                    break;
                }
            }

            return curerncyRate;
        }

        public double GetCurrencyCrossRateNBU(string baseCurrency, string currency_to)
        {
            double result = 1;
            double c1 = 1;
            double c2 = 1;

            if (baseCurrency.Equals(currency_to))
            {
                return result;
            }

            foreach (NBURate rate in currencyRateNbu)
            {
                if (rate.cc == baseCurrency)
                {
                    c1 = rate.rate;
                } else if (rate.cc == currency_to)
                {
                    c2 = rate.rate;
                }
            }

            result = c1 / c2;

            return result;
        }

        public double GetCurrencyRatePrivat(string baseCurrency, string convertedCurrency)
        {
            double result = 1;

            if (baseCurrency.Equals(convertedCurrency))
            {
                return result;
            }

            foreach (PrivatBankRate rate in currencyRatePrivat)
            {
                if (rate.ccy == baseCurrency)
                {
                    result = rate.buy;
                    break;
                } else if (rate.ccy == convertedCurrency)
                {
                    result = 1 / rate.sale;
                    break;
                }
            }

            return result;
        }

        public double GetCurrencyCrossRatePrivat(string baseCurrency, string convertedCurrency)
        {
            double result = 1; 
            double c1 = 1;
            double c2 = 1;

            if (baseCurrency.Equals(convertedCurrency))
            {
                return result;
            }

            foreach (PrivatBankRate rate in currencyRatePrivat)
            {
                if (rate.ccy == baseCurrency)
                {
                    c1 = rate.buy;
                }
                else if (rate.ccy == convertedCurrency)
                {
                    c2 = rate.sale;
                }
            }

            result = c1 / c2;

            return result;
        }
    }
}
