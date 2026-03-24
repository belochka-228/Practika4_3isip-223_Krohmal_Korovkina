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

            string functionType;
            if (rbSh.IsChecked == true)
                functionType = "sh";
            else if (rbSquare.IsChecked == true)
                functionType = "square";
            else
                functionType = "exp";

            try
            {
                double result = CalculateFunction(x, q, functionType);
                txtResult.Text = result.ToString("F4");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка вычислений: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// вычисляет значение функции k в зависимости от |x*q|
        /// </summary>
        /// <param name="x">Параметр x</param>
        /// <param name="q">Параметр q</param>
        /// <param name="functionType">тип функции</param>
        /// <returns>Результат вычисления</returns>
        public static double CalculateFunction(double x, double q, string functionType)
        {
            double fx;
            if (functionType == "sh")
                fx = Math.Sinh(x);
            else if (functionType == "square")
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

            return k;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtQ.Clear();
            txtResult.Clear();
        }
    }
}