using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Model
{
    class DateCurrency
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }

        public DateCurrency(DateTime dateTime, double value)
        {
            this.DateTime = dateTime;
            this.Value = value;
        }
    }
}
