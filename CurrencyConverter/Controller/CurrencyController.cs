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
        private double amountEntered;
        
        public CurrencyController(MainWindow newWindow)
        {
            window = newWindow;
        }

        public void UpdateValues()
        {
            baseCurrency = window.ExchangeFrom.Text;
            convertedCurrency = window.ExchangeTo.Text;
            amountEntered = double.Parse(window.Amount_Entered.Text);
        }

        public bool CheckCurrencies()
        {
            if (string.IsNullOrEmpty(window.ExchangeFrom.Text))
            {
                MessageBox.Show("You have not selected a currency to convert from");
                return false;
            }

            if (string.IsNullOrEmpty(window.ExchangeTo.Text))
            {
                MessageBox.Show("You have not selected a currency to convert to");
                return false;
            }

            try
            {
                double.Parse(window.Amount_Entered.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error Input !");
                return false;
            }

            if (double.Parse(window.Amount_Entered.Text) < 0)
            {
                MessageBox.Show("Cannot be negative number !");
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

        public void SetAmountResult(double amount)
        {
            window.Amount_Show.Text = Math.Round(amount, 3).ToString();
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
            double convertedAmount = 1;

            ConverterController convertCont = new ConverterController();

            if (IsNbuChosen())
            {
                convertedAmount = convertCont.NBUConvert(
                    baseCurrency.Substring(0, 3), convertedCurrency.Substring(0, 3), 
                    amountEntered
                    );
            } else if (IsPrivatBankChosen())
            {
                convertedAmount = convertCont.PrivatBankConvert(
                    baseCurrency.Substring(0, 3), convertedCurrency.Substring(0, 3),
                    amountEntered
                    );
            }

            SetAmountResult(convertedAmount);
        }
    }
}
