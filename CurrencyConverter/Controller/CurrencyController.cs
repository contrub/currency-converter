using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Controller
{
    class CurrencyController
    {
        private MainWindow window;
        private string baseCurrency;
        private string convertedCurrency;
        private double amountEntered = 0;
        public CurrencyController(MainWindow window_e)
        {
            window = window_e;
        }
        public void UpdateValues()
        {
            baseCurrency = window.ExchangeFrom.Text;
            convertedCurrency = window.ExchangeTo.Text;
            amountEntered = double.Parse(window.AmountEntered.Text);
        }
        public void ResetValues()
        {
            amountEntered = 0;
            window.AmountShow.Text = "0";
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

        public void SetResult(double r)
        {
            window.AmountShow.Text = Math.Round(r, 3).ToString();
        }
        public void SetCourse(double amount1, double amount2)
        {
            window.NBURateInfo.Content = $"1 {baseCurrency.Substring(0, 3)} = {Math.Round(amount1, 3)} {convertedCurrency.Substring(0, 3)}";
            window.PrivatRateInfo.Content = $"1 {baseCurrency.Substring(0, 3)} = {Math.Round(amount2, 3)} {convertedCurrency.Substring(0, 3)}";
        }
        public bool IsNbuChosen()
        {
            return (bool)window.checkBox1.IsChecked;
        }
        public bool IsPrivatBankChosen()
        {
            return (bool)window.checkBox2.IsChecked;
        }

        public void MakeConvert()
        {
            ConverterController convertCont = new ConverterController();

            double result = convertCont.NBUConvert(
                    baseCurrency.Substring(0, 3), convertedCurrency.Substring(0, 3),
                    amountEntered
                    );
            double alt = convertCont.PrivatBankConvert(
                baseCurrency.Substring(0, 3), convertedCurrency.Substring(0, 3),
                amountEntered
                );

            if (IsNbuChosen())
            {
                SetResult(result);
            }
            else if (IsPrivatBankChosen())
            {
                SetResult(alt);
            }

            SetCourse(result / amountEntered, alt / amountEntered);
        }
    }
}
