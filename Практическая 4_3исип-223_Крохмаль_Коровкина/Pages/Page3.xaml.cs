using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace Практическая_4_3исип_223_Крохмаль_Коровкина.Pages
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX0.Text) ||
                    string.IsNullOrWhiteSpace(txtXk.Text) ||
                    string.IsNullOrWhiteSpace(txtDx.Text) ||
                    string.IsNullOrWhiteSpace(txtB.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!double.TryParse(txtX0.Text, out double x0) ||
                    !double.TryParse(txtXk.Text, out double xk) ||
                    !double.TryParse(txtDx.Text, out double dx) ||
                    !double.TryParse(txtB.Text, out double b))
                {
                    MessageBox.Show("Некорректные числа! Используйте запятую (,) как разделитель.",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (dx == 0)
                {
                    MessageBox.Show("Шаг не может быть равен нулю!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if ((dx > 0 && x0 > xk) || (dx < 0 && x0 < xk))
                {
                    MessageBox.Show("Направление шага не соответствует движению от x₀ к xк!",
                                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                txtTable.Clear();
                myChart.Series[0].Points.Clear();

                int pointCount = 0;
                double yMin = double.MaxValue;
                double yMax = double.MinValue;
                double xMin = x0;
                double xMax = x0;

                for (double x = x0; (dx > 0) ? x <= xk : x >= xk; x += dx)
                {
                    double underSqrt = x + b - 0.0084;
                    if (underSqrt < 0)
                    {
                        MessageBox.Show($"При x = {x:F4} выражение под корнем отрицательно (x + b - 0.0084 = {underSqrt:F4}).\nРасчёт остановлен.",
                                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    double y = x * Math.Sin(Math.Sqrt(underSqrt));

                    txtTable.AppendText($"x = {x:F4}\t y = {y:F4}\r\n");
                    myChart.Series[0].Points.AddXY(x, y);

                    if (x < xMin) xMin = x;
                    if (x > xMax) xMax = x;
                    if (y < yMin) yMin = y;
                    if (y > yMax) yMax = y;

                    pointCount++;
                }

                if (pointCount == 0)
                {
                    MessageBox.Show("Не добавлено ни одной точки! Проверьте интервал и шаг.",
                                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                myChart.Series[0].Color = System.Drawing.Color.Blue;
                myChart.Series[0].BorderWidth = 2;
                myChart.ChartAreas[0].AxisX.Title = "x";
                myChart.ChartAreas[0].AxisY.Title = "y";
                myChart.ChartAreas[0].AxisX.Minimum = xMin;
                myChart.ChartAreas[0].AxisX.Maximum = xMax;

                double yRange = yMax - yMin;
                if (yRange > 0)
                {
                    myChart.ChartAreas[0].AxisY.Minimum = yMin - yRange * 0.05;
                    myChart.ChartAreas[0].AxisY.Maximum = yMax + yRange * 0.05;
                }

                myChart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX0.Clear();
            txtXk.Clear();
            txtDx.Clear();
            txtB.Clear();
            txtTable.Clear();
            myChart.Series[0].Points.Clear();
        }


    }
}
