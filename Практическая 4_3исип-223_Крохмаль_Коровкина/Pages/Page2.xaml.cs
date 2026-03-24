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

namespace Практическая_4_3исип_223_Крохмаль_Коровкина.Pages
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplay();
        }

        private void CalculateAndDisplay()
        {
            if (string.IsNullOrWhiteSpace(txtX.Text) || string.IsNullOrWhiteSpace(txtQ.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!double.TryParse(txtX.Text, out double x))
            {
                MessageBox.Show("x должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!double.TryParse(txtQ.Text, out double q))
            {
                MessageBox.Show("q должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            double fx;
            if (rbSh.IsChecked == true)
                fx = Math.Sinh(x);
            else if (rbSquare.IsChecked == true)
                fx = x * x;
            else
                fx = Math.Exp(x);

            double absXq = Math.Abs(x * q);
            double k;

            if (absXq > 10)
            {
                k = Math.Log(Math.Abs(fx) + Math.Abs(q));
            }
            else if (absXq < 10)
            {
                k = Math.Exp(fx + q);
            }
            else
            {
                k = fx + q;
            }

            txtResult.Text = k.ToString("F4");
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtQ.Clear();
            txtResult.Clear();
        }
    }
}
