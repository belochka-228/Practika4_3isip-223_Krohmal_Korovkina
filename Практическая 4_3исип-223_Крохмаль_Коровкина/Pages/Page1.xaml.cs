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

        /// <summary>
        /// выполняет вычисление и отображает результат
        /// </summary>
        private void CalculateAndDisplay()
        {
            if (!TryGetInputValues(out double x, out double y, out double z))
                return;

            try
            {
                double result = CalculateFunction(x, y, z);
                txtResult.Text = result.ToString("F4");
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычислений: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// вычисляет значение функции
        /// </summary>
        /// <param name="x">Параметр x</param>
        /// <param name="y">Параметр y</param>
        /// <param name="z">Параметр z (в радианах)</param>
        /// <returns>Результат вычисления</returns>
        public static double CalculateFunction(double x, double y, double z)
        {
            double sinZ = Math.Sin(z);
            if (Math.Abs(sinZ) < 1e-10)
                throw new DivideByZeroException("sin(z) не должен быть равен нулю.");

            double term1 = Math.Pow(2, -x);
            double absY = Math.Abs(y);
            double root4Y = Math.Pow(absY, 1.0 / 4.0);
            double exponent = (x - 1) / sinZ;
            double expValue = Math.Exp(exponent);
            double root3Exp = Math.Pow(expValue, 1.0 / 3.0);
            double underSqrt = x + root4Y * root3Exp;

            if (underSqrt < 0)
                throw new ArgumentOutOfRangeException(nameof(underSqrt), "Подкоренное выражение отрицательно.");

            return term1 * Math.Sqrt(underSqrt);
        }

        /// <summary>
        /// получает значения из текстовых полей ввода
        /// </summary>
        /// <returns>true, если все значения успешно получены</returns>
        private bool TryGetInputValues(out double x, out double y, out double z)
        {
            x = y = z = 0;

            if (string.IsNullOrWhiteSpace(txtX.Text) ||
                string.IsNullOrWhiteSpace(txtY.Text) ||
                string.IsNullOrWhiteSpace(txtZ.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!double.TryParse(txtX.Text, out x))
            {
                MessageBox.Show("x должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!double.TryParse(txtY.Text, out y))
            {
                MessageBox.Show("y должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!double.TryParse(txtZ.Text, out z))
            {
                MessageBox.Show("z должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
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
