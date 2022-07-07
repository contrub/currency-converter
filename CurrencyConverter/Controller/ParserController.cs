using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using CurrencyConverter.Model;
using System;

namespace CurrencyConverter
{
    class ParserController
    {
        private List<NBURate> currencyRateNbu;
        private List<PrivatBankRate> currencyRatePrivat;

        public void FillCurrencyRatesNbu()
        {
            ApiController API = new ApiController();
            string jsonResponse;

            API.MakeNBURequest();
            
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

        public void FillCurrencyRatesPrivat()
        {
            ApiController API = new ApiController();
            string jsonResponse;

            API.MakePrivatRequest();

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

            if (!baseCurrency.Equals("UAH") && !convertedCurrency.Equals("UAH"))
            {
                return GetCurrencyCrossRateNBU(baseCurrency, convertedCurrency);
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

            return Math.Round(curerncyRate, 3);
        }

        public double GetCurrencyCrossRateNBU(string baseCurrency, string currency_to)
        {
            double curerncyRate = 1;
            double c1 = 1;
            double c2 = 1;

            if (baseCurrency.Equals(currency_to))
            {
                return curerncyRate;
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

            curerncyRate = c1 / c2;

            return Math.Round(curerncyRate, 3);
        }

        public double GetCurrencyRatePrivat(string baseCurrency, string convertedCurrency)
        {
            double curerncyRate = 1;

            if (baseCurrency.Equals(convertedCurrency))
            {
                return curerncyRate;
            }

            if (!baseCurrency.Equals("UAH") && !convertedCurrency.Equals("UAH"))
            {
                return GetCurrencyCrossRatePrivat(baseCurrency, convertedCurrency);
            }

            foreach (PrivatBankRate rate in currencyRatePrivat)
            {
                if (rate.ccy == baseCurrency)
                {
                    curerncyRate = rate.buy;
                    break;
                } else if (rate.ccy == convertedCurrency)
                {
                    curerncyRate = 1 / rate.sale;
                    break;
                }
            }

            return Math.Round(curerncyRate, 3);
        }

        public double GetCurrencyCrossRatePrivat(string baseCurrency, string convertedCurrency)
        {
            double curerncyRate = 1; 
            double c1 = 1;
            double c2 = 1;

            if (baseCurrency.Equals(convertedCurrency))
            {
                return curerncyRate;
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

            curerncyRate = c1 / c2;

            return Math.Round(curerncyRate, 3);
        }
    }
}
