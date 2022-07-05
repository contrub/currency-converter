using System;
using System.Net;

namespace CurrencyConverter
{
    class APIRequest
    {
        private static string NBURequestToCurrentDay = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        private static string PrivatRequestToDate = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";

        private WebRequest request;
        private WebResponse response;

        public void MakeRequestToCurrentDay()
        {
            request = WebRequest.Create(NBURequestToCurrentDay);
        }
        public void MakeRequestToCurrentDatePrivat()
        {
            request = WebRequest.Create(PrivatRequestToDate);
        }
        public WebResponse GetResponse()
        {
            response = request.GetResponse();
            return response;
        }
    }
}
