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

namespace WpfAppCalculytor_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool TrueFalse { get; set; }
        int count_command, count_plus, count_negative, count_multiplication, count_division, count_minus, count_sqrt; //определение типов данных в логике
        private double X { get; set; }
        private double Resultcopy { get; set; }
        private double Y { get; set; }
        private string Symbol { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)  // результат текста
        {
            if (result.Text == "Invalid input")
            {
                btnDivision.IsEnabled = true;
                btnMinus.IsEnabled = true;
                btnMultiplication.IsEnabled = true;
                btnSqrt.IsEnabled = true;
                btnSumm.IsEnabled = true;
                btnComman.IsEnabled = true;
                btnNegative.IsEnabled = true;
                btnSqr.IsEnabled = true;
                btnFract.IsEnabled = true;
                btnPercent.IsEnabled = true;
            }
            if (TrueFalse)
            {
                result.Text = null;
            }
            if (sender is Button btn)
            {
                if (result.Text == "0" || result.Text == "-0") result.Text = btn.Content.ToString();
                else
                {
                    result.Text += btn.Content;
                }
            }
            if (TrueFalse) Y = Convert.ToDouble(result.Text);
            TrueFalse = false;
        }
        private void btnComman_Click(object sender, RoutedEventArgs e) // запись после точки
        {
            if (count_command == 0)
            {
                result.Text += ".";
                ++count_command;
            }
        }
        private void btnC_Click(object sender, RoutedEventArgs e) //вычисления будут очищены:

        {
            if (result.Text == "Invalid input")
            {
                btnDivision.IsEnabled = true;
                btnMinus.IsEnabled = true;
                btnMultiplication.IsEnabled = true;
                btnSqrt.IsEnabled = true;
                btnSumm.IsEnabled = true;
                btnComman.IsEnabled = true;
                btnNegative.IsEnabled = true;
                btnSqr.IsEnabled = true;
                btnFract.IsEnabled = true;
                btnPercent.IsEnabled = true;
            }
            result.Text = null;
            count_command = 0;
            count_negative = 0;
        }
        private void btnCE_Click(object sender, RoutedEventArgs e) //очищает самую последнюю запись
        {
            if (result.Text == "Invalid input")
            {
                btnDivision.IsEnabled = true;
                btnMinus.IsEnabled = true;
                btnMultiplication.IsEnabled = true;
                btnSqrt.IsEnabled = true;
                btnSumm.IsEnabled = true;
                btnComman.IsEnabled = true;
                btnNegative.IsEnabled = true;
                btnSqr.IsEnabled = true;
                btnFract.IsEnabled = true;
                btnPercent.IsEnabled = true;
            }
            result.Text = null;
            count_command = 0;
            count_negative = 0;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e) //стирает краюнюю цифру
        {
            if (result.Text.Length == 1)
            {
                result.Text = "0";
            }
            else
            {
                result.Text = result.Text.Remove(result.Text.Length - 1, 1);

                if (result.Text[result.Text.Length - 1] == '.')
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1, 1);
                    count_command = 0;

                }
                if (result.Text[result.Text.Length - 1] == '-')
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1, 1);
                    count_negative = 0;
                }
            }
        }
        private void btnNegative_Click(object sender, RoutedEventArgs e) //+- положительное/отрицательное число
        {
            if (count_negative == 0)
            {
                result.Text = result.Text.Insert(0, "-");
                ++count_negative;
            }
            else if (count_negative == 1)
            {
                result.Text = result.Text.Remove(0, 1);
                count_negative = 0;
            }
        }
        private void btn_operation_Click(object sender, RoutedEventArgs e) //действия первой итерации.
        {
            if (sender is Button btn)
            {
                switch (btn.Content.ToString())
                {
                    case "+":
                        {
                            Resultcopy = Convert.ToDouble(result.Text);
                            Symbol = "+";
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            count_plus = 0;
                            break;
                        }
                    case "-":
                        {
                            Resultcopy = Convert.ToDouble(result.Text);
                            Symbol = "-";
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            count_minus = 0;
                            break;
                        }
                    case "*":
                        {
                            Resultcopy = Convert.ToDouble(result.Text);
                            Symbol = "*";
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            count_multiplication = 0;
                            break;
                        }
                    case "/":
                        {
                            Resultcopy = Convert.ToDouble(result.Text);
                            Symbol = "/";
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            count_division = 0;
                            break;
                        }
                    case "%":
                        {
                            Symbol = "%";
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            Resultcopy = Convert.ToDouble(result.Text);
                            result.Text = (Resultcopy * 0.01).ToString();
                            break;
                        }

                    case "x²":
                        {
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            Resultcopy = Convert.ToDouble(result.Text);

                            result.Text = (Resultcopy * Resultcopy).ToString();
                            break;
                        }
                    case "⅟×":
                        {
                            Symbol = "⅟×";
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            Resultcopy = Convert.ToDouble(result.Text);
                            if (Resultcopy == 0)
                            {
                                result.Text = "Invalid input";
                                btnDivision.IsEnabled = false;
                                btnMinus.IsEnabled = false;
                                btnMultiplication.IsEnabled = false;
                                btnSqrt.IsEnabled = false;
                                btnSumm.IsEnabled = false;
                                btnComman.IsEnabled = false;
                                btnNegative.IsEnabled = false;
                                btnSqr.IsEnabled = false;
                                btnFract.IsEnabled = false;
                                btnPercent.IsEnabled = false;
                            }
                            else
                            {
                                result.Text = (1 / Resultcopy).ToString();
                            }
                            break;
                        }
                    case "√x":
                        {
                            TrueFalse = true;
                            count_command = 0;
                            count_negative = 0;
                            Resultcopy = Convert.ToDouble(result.Text);
                            if (Resultcopy > 0)
                            {
                                result.Text = Math.Sqrt(Resultcopy).ToString();
                            }
                            else if (Resultcopy < 0)
                            {
                                result.Text = "Invalid input";
                                btnDivision.IsEnabled = false;
                                btnMinus.IsEnabled = false;
                                btnMultiplication.IsEnabled = false;
                                btnSqrt.IsEnabled = false;
                                btnSumm.IsEnabled = false;
                                btnComman.IsEnabled = false;
                                btnNegative.IsEnabled = false;
                                btnSqr.IsEnabled = false;
                                btnFract.IsEnabled = false;
                                btnPercent.IsEnabled = false;
                            }
                            break;
                        }

                }

               
            }
        }
        private void Result_Click(object sender, RoutedEventArgs e) // окончание действий
        {
            if (result.Text == "Invalid input")
            {
                btnDivision.IsEnabled = true;
                btnMinus.IsEnabled = true;
                btnMultiplication.IsEnabled = true;
                btnSqrt.IsEnabled = true;
                btnSumm.IsEnabled = true;
                btnComman.IsEnabled = true;
                btnNegative.IsEnabled = true;
                btnSqr.IsEnabled = true;
                btnFract.IsEnabled = true;
                btnPercent.IsEnabled = true;
                result.Text = "0";
            }
            ++count_plus;
            ++count_minus;
            ++count_multiplication;
            ++count_division;
            ++count_sqrt;

            X = Convert.ToDouble(result.Text);
            if (Symbol == "+")
            {
                if (count_plus == 1)
                {
                    result.Text = (Resultcopy + X).ToString();
                }
                else if (count_plus != 1)
                {
                    result.Text = (Y + X).ToString();
                }
            }
            else if (Symbol == "-")
            {
                if (count_minus == 1)
                {
                    result.Text = (Resultcopy - X).ToString();
                }
                else if (count_minus != 1)
                {
                    result.Text = (X - Y).ToString();
                }
            }
            else if (Symbol == "*")
            {
                if (count_multiplication == 1)
                {
                    result.Text = (Resultcopy * X).ToString();
                }
                else if (count_multiplication != 1)
                {
                    result.Text = (X * Y).ToString();
                }
            }
            else if (Symbol == "/")
            {
                if (count_division == 1)
                {
                    if (X == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else result.Text = (Resultcopy / X).ToString();
                }
                else if (count_division != 1)
                {
                    if (Y == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else result.Text = (X / Y).ToString();
                }
            }
        }
    }
}
