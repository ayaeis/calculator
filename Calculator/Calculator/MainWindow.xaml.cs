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
        int  number1 = 0; // det första numret man skriver in
        int number2 = 0; // det andra numret man skriver in
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

        private void equal(object sender, RoutedEventArgs e)
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
                    number1 = (number1 / 10);
                    Display.Text = number1.ToString();
                }
                else
                {
                    number2 = (number2 / 10);
                    Display.Text = number2.ToString();
                }
            }
        }
    }
}
