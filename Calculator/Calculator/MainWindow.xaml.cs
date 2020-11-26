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
        int number11;
        int number22;
        double result;
        double  number1 = 0; // det första numret man skriver in
        double number2 = 0; // det andra numret man skriver in
        string operation = ""; // operationen 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                // Först skriver man första numret, sedan operationen. Seda skriver man andra talet
                // Alltså då operationen = "", har man fortfarande inte skrivit andra numret, och istälet håller på att skriva första
                if (operation == "")
                {
                    if (Display.Text == "0")
                    {
                        Display.Text = "";
                    }
                    Display.Text += button.Content;
                    number1 = Convert.ToDouble(Display.Text);
                }
                else
                {
                    if (Display.Text == "0")
                    {
                        Display.Text = "";
                    }
                    Display.Text += button.Content;
                    number2 = Convert.ToDouble(Display.Text);

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                // ifall ma vill använda resultatet man fick sista gången , blir resultatet "första talet "
                // 
                if (operation != "")
                {
                    number1 = result;
                    operation = button.Content.ToString();
                    number2 = 0;
                    Display.Text = "";
                }
                else
                {
                    operation = button.Content.ToString();
                    Display.Text = "0";
                }

            }
        }

        private void equal(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                switch (operation)
                {
                    case "+":
                        Display.Text = (number1 + number2).ToString();
                        result = Convert.ToDouble(Display.Text);
                        break;
                    case "-":
                        Display.Text = (number1 - number2).ToString();
                        result = Convert.ToDouble(Display.Text);
                        break;
                    case "x":
                        Display.Text = (number1 * number2).ToString();
                        result = Convert.ToDouble(Display.Text);
                        break;
                    case "/":
                        Display.Text = (number1 / number2).ToString();
                        result = Convert.ToDouble(Display.Text);
                        break;
                }

            }
        }

        private void clearEntry(object sender, RoutedEventArgs e)
        {
            // clear entry är att man tar bort antingen första eller andra, alltså det sista man har skrivit
            // om operationen = "", det är första numret man vill ta bort, då man har inte ens börjat med andra numret ( den kommer efter man har skrivit operationen)
            if (operation == "")
            {
                number1 = 0;
            }
            else
            {
                number2 = 0;
            }
            Display.Text = "0";
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            operation = "";
            Display.Text = "0";
        }

        private void backSpace(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                if (operation == "")
                {
                    // om numret delas med 10, blir det ett decimal tal. Sista numret tas då bort eftersom en int är ett heltal
                    
                    number11 = Convert.ToInt32((number1 / 10));
                    number1 = number11;
                    Display.Text = number1.ToString();
                }
                else
                {
                    number22 = Convert.ToInt32((number2 / 10) - 1);
                    number2 = number22;
                    Display.Text = number2.ToString();
                }
            }
        }
    }
}
