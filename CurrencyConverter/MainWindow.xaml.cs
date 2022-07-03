using System;
using System.Collections.Generic;
using System.Windows;

using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using CurrencyConverter.Model;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SetChartModelValues();
            this.DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public DateTime InitialDateTime { get; set; }
        public Func<double, string> Formatter { get; set; }
        private void SetChartModelValues()
        {
            var dayConfig = Mappers.Xy<DateCurrency>()
                           .X(dayModel => dayModel.DateTime.Ticks)
                           .Y(dayModel => dayModel.Value);


            DateTime now = new DateTime(2022, 6, 29);
            now = now.AddDays(-29);

            var saleCurrencies = new Dictionary<DateTime, double> {
                { now, 36.25 }, { now.AddDays(1), 36 }, { now.AddDays(2), 35.9 }, { now.AddDays(3), 35.9 },
                { now.AddDays(4), 35.8 }, { now.AddDays(5), 36 }, { now.AddDays(6), 35.8 }, { now.AddDays(7), 35.5 },
                { now.AddDays(8), 35.5 }, { now.AddDays(9), 35.5 }, { now.AddDays(10), 35.4 }, { now.AddDays(11), 35.4 },
                { now.AddDays(12), 35.4}, { now.AddDays(13), 35.5 }, { now.AddDays(14), 35.7 }, { now.AddDays(15), 35.7 },
                { now.AddDays(16), 35.8 }, { now.AddDays(17), 35.9 }, { now.AddDays(18), 35.9 }, { now.AddDays(19), 35.9 },
                { now.AddDays(20), 35.8 }, { now.AddDays(21), 35.7 }, { now.AddDays(22), 35.6 }, { now.AddDays(23), 35.55 },
                { now.AddDays(24), 35.6 }, { now.AddDays(25), 35.6 }, { now.AddDays(26), 35.6 }, { now.AddDays(27), 35.7 },
                { now.AddDays(28), 35.7 }, { now.AddDays(29), 35.65 }
            };

            var buyCurrencies = new Dictionary<DateTime, double> {
                { now, 35.25 }, { now.AddDays(1), 35 }, { now.AddDays(2), 35 }, { now.AddDays(3), 35 },
                { now.AddDays(4), 35 }, { now.AddDays(5), 35 }, { now.AddDays(6), 35 }, { now.AddDays(7), 34.675 },
                { now.AddDays(8), 34.7 }, { now.AddDays(9), 34.8 }, { now.AddDays(10), 34.8 }, { now.AddDays(11), 34.8 },
                { now.AddDays(12), 34.8 }, { now.AddDays(13), 34.8 }, { now.AddDays(14), 35 }, { now.AddDays(15), 35.1 },
                { now.AddDays(16), 35.2 }, { now.AddDays(17), 35.3 }, { now.AddDays(18), 35.2 }, { now.AddDays(19), 35.2 },
                { now.AddDays(20), 35.2 }, { now.AddDays(21), 35 }, { now.AddDays(22), 35 }, { now.AddDays(23), 35 },
                { now.AddDays(24), 35 }, { now.AddDays(25), 35 }, { now.AddDays(26), 35 }, { now.AddDays(27), 35.1 },
                { now.AddDays(28), 35.15 }, { now.AddDays(29), 35.2 }
            };

            this.SeriesCollection = new SeriesCollection(dayConfig);

            ChartValues<DateCurrency> saleValues = new ChartValues<DateCurrency>();
            ChartValues<DateCurrency> buyValues = new ChartValues<DateCurrency>();

            foreach (KeyValuePair<DateTime, double> saleCurrency in saleCurrencies)
            {
                saleValues.Add(new DateCurrency(saleCurrency.Key, saleCurrency.Value));
            }

            foreach (KeyValuePair<DateTime, double> buyCurrency in buyCurrencies)
            {
                buyValues.Add(new DateCurrency(buyCurrency.Key, buyCurrency.Value));
            }

            this.SeriesCollection = new SeriesCollection(dayConfig)
            {
                new LineSeries()
                {
                    Values = saleValues,
                    Title = "Sale"
                },
                new LineSeries()
                {
                    Values = buyValues,
                    Title = "Buy"
                }
            };

            this.InitialDateTime = now;
            this.Formatter = value => new DateTime((long)value).ToString("dd-MM-yyyy");

        }
    }
}
