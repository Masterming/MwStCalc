using System;
using System.Windows;

namespace Clientside
{
    /// <summary>
    /// GUI-Aufruf einer MwSt-Rechnung (Eingabe per Textbox)
    /// Client-Server-Architektur mit MwSt-Satz gelesen aus SQLite-Tabelle mit C#-TCP/WS-binding
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Client client;
        public MainWindow()
        {
            InitializeComponent();
            client = new Client("net.tcp://localhost", 31227);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double amm = Convert.ToDouble(this.amm.Text);
            int id = r19.IsChecked == true ? 1 : r16.IsChecked == true ? 2 : r7.IsChecked == true ? 3 : 4;
            double perc = client.RequestPercentage(id) + 1.0;

            double final = netto.IsChecked == true ? amm * perc : amm / perc;
            double diff = Math.Abs(final - amm);

            steuer.Text = $"{diff:0.00} €";
            betrag.Text = $"{final:0.00} €";
        }

        private void Radio_Click(object sender, RoutedEventArgs e)
        {
            if (netto.IsChecked == true)
                start.Text = "Nettobetrag (ohne MwSt.):";
            else
                start.Text = "Bruttobetrag (mit MwSt.):";

        }
    }
}
