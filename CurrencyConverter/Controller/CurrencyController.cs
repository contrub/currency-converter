using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CurrencyConverter.Controller
{
    class CurrencyController
    {
        private MainWindow window;
        private string baseCurrency;
        private string convertedCurrency;
        private double amountEntered = 0;
        public CurrencyController(MainWindow newWindow)
        {
            window = newWindow;
        }
        public void UpdateValues()
        {
            baseCurrency = window.ExchangeFrom.Text.Substring(0, 3);
            convertedCurrency = window.ExchangeTo.Text.Substring(0, 3);
            amountEntered = double.Parse(window.AmountEntered.Text);
        }
        public void ResetValues()
        {
            window.AmountShow.Text = "";
            window.NBURateInfo.Content = "";
            window.PrivatRateInfo.Content = "";
        }
        public bool CheckCurrencies()
        {
            if (string.IsNullOrEmpty(window.ExchangeFrom.Text))
            {
                MessageBox.Show("Ви не обрали базову валюту для конвертації");
                return false;
            }

            if (string.IsNullOrEmpty(window.ExchangeTo.Text))
            {
                MessageBox.Show("Ви не обрали конвертовану валюту для конвертації");
                return false;
            }

            try
            {
                double.Parse(window.AmountEntered.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка парсингу введеної суми");
                return false;
            }

            if (double.Parse(window.AmountEntered.Text) < 0)
            {
                MessageBox.Show("Конвертована сума не може бути від'ємною");
                return false;
            }

            return true;
        }

        public string GetBaseCurrency()
        {
            return baseCurrency;
        }
        public string GetConvertedCurrency()
        {
            return convertedCurrency;
        }
        public double GetAmountEntered()
        {
            return amountEntered;
        }

        public void SetResult(double amount)
        {
            window.AmountShow.Text = amount.ToString();
        }
        public void SetCourse(double NBUCourse, double PrivatCourse)
        {
            window.NBURateInfo.Content = $"1 {baseCurrency} = {NBUCourse} {convertedCurrency}";
            window.PrivatRateInfo.Content = $"1 {baseCurrency} = {PrivatCourse} {convertedCurrency}";
        }
        public bool IsNbuChosen()
        {
            return (bool)window.NBUCB.IsChecked;
        }
        public bool IsPrivatBankChosen()
        {
            return (bool)window.PrivatCB.IsChecked;
        }

        public void MakeConvert()
        {
            ConverterController converter = new ConverterController();
            ParserController parser = new ParserController();

            parser.FillCurrencyRatesNbu();
            parser.FillCurrencyRatesPrivat();

            double convertResult = 0;

            if (IsNbuChosen())
            {
                convertResult = converter.NBUConvert(baseCurrency, convertedCurrency, amountEntered);
            }
            else if (IsPrivatBankChosen())
            {
                convertResult = converter.PrivatBankConvert(baseCurrency, convertedCurrency, amountEntered);
            }

            SetResult(convertResult);

            SetCourse(parser.GetCurrencyRateNBU(baseCurrency, convertedCurrency), parser.GetCurrencyRatePrivat(baseCurrency, convertedCurrency));
        }
    }
}
