using System;
using System.Net;

namespace CurrencyConverter
{
    class ApiController
    {
        private static string NBURequestUrl = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        private static string PrivatRequestUrl = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";

        private WebRequest request;
        private WebResponse response;
        public static string GetNBUUrl()
        {
            return NBURequestUrl;
        }
        public static string GetPrivatUrl()
        {
            return PrivatRequestUrl;
        }
        public void MakeNBURequest()
        {
            request = WebRequest.Create(NBURequestUrl);
        }
        public void MakePrivatRequest()
        {
            request = WebRequest.Create(PrivatRequestUrl);
        }
        public WebResponse GetResponse()
        {
            response = request.GetResponse();
            return response;
        }
    }
}
