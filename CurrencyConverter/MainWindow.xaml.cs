using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            string s = "Current rate is ";
            RemoteRequest rr = new RemoteRequest();
            string latestRate = rr.GetLatestRate(baseCurrency.Text, targetCurrency.Text);
            rate.Content = s + latestRate + @" @ " + DateTime.Now;
            try
            {
                targetedAmount.Text = (double.Parse(baseAmount.Text) * double.Parse(latestRate)).ToString();
                List<Rates> rates = rr.GetRatesForLastMonth(baseCurrency.Text, targetCurrency.Text);
            }
            catch
            {
                MessageBox.Show("Please input a numeric value.", "Invalid input");
            }
        }
    }
}
