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

namespace WpfEsercizioTask
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

        private void bntEsegui_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txtA.Text);
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = 100;
            ProgressBar.Value = 0;
            Multipli(a);
        }

        private async Task Multipli(int a)
        {
            await Task.Run(() =>
            {
                int d = 200000000;
                int m = 0;
                for (int i = 1; i <= d; i++)
                {
                    if ((i % a) == 0)
                    {
                        m++;
                    }
                    if (i % 2000000 == 0)
                    {
                        ProgressBar.Dispatcher.Invoke(() =>
                        ProgressBar.Value++);
                    };
                }

                lblMultipli.Dispatcher.Invoke(() =>
                    lblMultipli.Content = m
                );
            });
        }

        private void btnPrimo_Click(object sender, RoutedEventArgs e)
        {
            lblPrimo.Content = "";
            bool primo = true;
            int a = int.Parse(txtA.Text);
            for (int i = 2; i <= a / 2; i++)
            {
                if (a % i == 0)
                    primo = false;
            }
            if (primo == false)
            {
                lblPrimo.Content = "Non è primo!";
            }
            else
            {
                lblPrimo.Content = "E' primo!";
            }
        }
    }
}
