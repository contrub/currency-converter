using System;
using System.Windows;
using CurrencyConverter.Controller;

namespace CurrencyConverter
{
    public partial class MainWindow : Window
    {
        private CurrencyController currencyController;
        public MainWindow()
        {
            InitializeComponent();
            currencyController = new CurrencyController(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            if (!currencyController.CheckCurrencies()) return;

            currencyController.UpdateValues();

            currencyController.MakeConvert();
        }
    }
}