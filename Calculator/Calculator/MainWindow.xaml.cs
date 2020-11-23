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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double  number1 = 0;
        double number2 = 0;
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                if (operation == "")
                {
                    number1 = (number1 * 10) + Convert.ToInt32(button.Content) ; 
                    Display.Text = number1.ToString();
                }
                else
                {
                    number2 = (number2 * 10) + Convert.ToInt32(button.Content);
                    Display.Text = number2.ToString();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                operation = button.Content.ToString();
                Display.Text = "0";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                switch (operation)
                {
                    case "+":
                        Display.Text = (number1 + number2).ToString();
                        break;
                    case "-":
                        Display.Text = (number1 - number2).ToString();
                        break;
                    case "x":
                        Display.Text = (number1 * number2).ToString();
                        break;
                    case "/":
                        Display.Text = (number1 / number2).ToString();
                        break;
                }

            }
        }
    }
}
