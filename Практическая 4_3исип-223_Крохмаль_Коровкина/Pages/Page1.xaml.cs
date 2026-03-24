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
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplay();
        }

        private void CalculateAndDisplay()
        {
            if (string.IsNullOrWhiteSpace(txtX.Text) ||
                string.IsNullOrWhiteSpace(txtY.Text) ||
                string.IsNullOrWhiteSpace(txtZ.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!double.TryParse(txtX.Text, out double x))
            {
                MessageBox.Show("x должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!double.TryParse(txtY.Text, out double y))
            {
                MessageBox.Show("y должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!double.TryParse(txtZ.Text, out double z))
            {
                MessageBox.Show("z должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            double sinZ = Math.Sin(z);
            if (Math.Abs(sinZ) < 1e-10)
            {
                MessageBox.Show("sin(z) не должен быть равен нулю!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            double term1 = Math.Pow(2, -x);
            double absY = Math.Abs(y);
            double root4Y = Math.Pow(absY, 1.0 / 4.0);
            double exponent = (x - 1) / sinZ;
            double expValue = Math.Exp(exponent);
            double root3Exp = Math.Pow(expValue, 1.0 / 3.0);
            double underSqrt = x + root4Y * root3Exp;
            if (underSqrt < 0)
            {
                MessageBox.Show("Подкоренное выражение (x + ...) не может быть отрицательным!",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double result = term1 * Math.Sqrt(underSqrt);
            txtResult.Text = result.ToString("F4");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            txtResult.Clear();
        }
    }
}
