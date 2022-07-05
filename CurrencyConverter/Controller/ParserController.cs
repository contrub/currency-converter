using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;

using CurrencyConverter.Model;

namespace CurrencyConverter
{
    public class ParserController
    {
        private string jsonResponse;
        private List<NBURate> currencyRatesNBU;
        private List<PrivatBankRate> currencyRatePrivat;

        public void FillListFromJSONToCurrentDayNBU()
        {
            ApiController API = new ApiController();

            API.MakeRequestToCurrentDay();

            using (WebResponse webResponse = API.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(dataStream);
                    jsonResponse = streamReader.ReadToEnd();
                }
            }
            currencyRatesNBU = JsonConvert.DeserializeObject<List<NBURate>>(jsonResponse);
        }
        public void FillCurrencyRateToCurrentDayPrivat()
        {
            ApiController API = new ApiController();

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

        private List<NBURate> GetCurrencyRatesNBU()
        {
            return currencyRatesNBU;
        }

        private List<PrivatBankRate> GetCurrencyRatePrivat()
        {
            return currencyRatePrivat;
        }
    }
}
