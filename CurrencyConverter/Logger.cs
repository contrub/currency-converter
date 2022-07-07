using System;
using System.IO;
using System.Text;

namespace CurrencyConverter.Controller
{
    class Logger
    {
        private static string path = "logs.txt";

        public static void Write(
            string baseCurrency, string convertedCurrency, 
            double currencyRate, string sourceConversion,
            string sourceConversionUrl
            )
        {
            DateTime dateTime = DateTime.Now;

            string newLine = string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}",
                dateTime.ToShortDateString(), dateTime.TimeOfDay,
                baseCurrency, convertedCurrency,
                currencyRate, sourceConversion,
                sourceConversionUrl
                );

            using (StreamWriter file = new StreamWriter(path, true, Encoding.Default))
            {
                file.WriteLine(newLine);
            }
        }
    }
}
