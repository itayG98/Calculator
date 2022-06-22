using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{

    public sealed partial class MainPage : Page
    {
        double a = 0, b = 0, result = 0, memory;
        char operation='1'; /*will alert if operation is not good*/
        bool AOrB = true;       /*Insert a than b than a , rotation*/
        bool validation=true;
        bool Last_Was_Equal = false;  /*This bool alow the calc to make multiply fast calcutations wich are the same*/
        public MainPage()
        {

            this.InitializeComponent();
            Calc_box.Text = String.Empty;
        }

/*Basic numerical operators*/
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber();
            operation = '+';
            Last_Was_Equal=false;
        }
        private void minus_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber();
            operation = '-';
            Last_Was_Equal = false;
        }
        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber();
            operation = '*';
            Last_Was_Equal = false;
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber();
            operation = '/';
            Last_Was_Equal = false;
        }

        private void percentage_Click(object sender, RoutedEventArgs e) /*Modulo*/
        {
            InsertNumber();
            operation = '%';
            Last_Was_Equal = false;
        }

        private void power_Click(object sender, RoutedEventArgs e)
        {
            InsertNumber();
            operation = '^';
            Last_Was_Equal = false;
        }
/*Calculates and print value or pops alert*/
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!Last_Was_Equal)
            {
                InsertNumber();
            }
            else if (b != 1)
            {
                a = result;
            }
            else 
            {
                b = result;
            }
            switch (operation)
            {
                case '+':
                    {
                        result = a + b;
                        break;
                    }
                case '-':
                    {
                        result = a - b;
                        break;
                    }
                case '*':
                    {
                        result = a * b;
                        break;
                    }
                case '/':
                    {
                        if (b != 0)
                        {
                            result = a / b;
                            break;
                        }
                        alert("Divide by zero");
                        ClearAll();
                        break;
                    }
                case '^':
                    {
                        result = (Math.Pow(a, b));
                        break;
                    }
                case '%':
                    {
                        result = a % b;
                        break;
                    }
                case '1':
                    {
                        alert("No operator detected");
                        ClearAll();
                        break;
                    }

            }
            Calc_box.Text = Convert.ToString(result);
            Last_Was_Equal = true;

            /*alert($"a is = {a} operator is {operation} b is {b} result is {result}");     A line to check the caclutation*/
        }
        private void InsertNumber()
        {
            if (Calc_box.Text.LastIndexOf('.') != Calc_box.Text.IndexOf('.'))  /*Check if there multiple dots*/
            {
                alert("Two dot's or more are not allowed");
                ClearAll();
            }
            else if (AOrB) /*Insert a than b than a , rotation*/
            {
                validation = double.TryParse(Calc_box.Text, out a);
                Calc_box.Text = String.Empty;
            }
            else
            {
                validation = double.TryParse(Calc_box.Text, out b);
                Calc_box.Text = String.Empty;
            }
            AOrB = !AOrB;
            if (!validation) 
            {
                alert("Invalid input");
                ClearAll();
            }
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            Last_Was_Equal = false;
        }
        private void point_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '.';
            Last_Was_Equal = false;
        }

        private void lasl_Click(object sender, RoutedEventArgs e)
        {
            memory = result;
            ClearAll();
            Calc_box.Text = Convert.ToString(memory);
            InsertNumber();  
            Calc_box.Text = Convert.ToString(a);  /*a =memory = last result*/
            Last_Was_Equal = false;
        }

        private void ClearAll() 
        {
            a = b = result = 0;
            operation = '1'; /*will alert if operation is not good*/
            AOrB = true;
            validation = true;
            Last_Was_Equal = false;
            Calc_box.Text = String.Empty;
        }

        private async void alert(String errorMessege) 
        {
            await new MessageDialog($"Cleard calc. \n{errorMessege}.").ShowAsync();
        }

/*Number buttons function*/
        private void zero_Click(object sender, RoutedEventArgs e)
        {
                Calc_box.Text += '0';
            Last_Was_Equal = false;
        }


        private void one_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '1';
            Last_Was_Equal = false;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '2';
            Last_Was_Equal = false;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '3';
            Last_Was_Equal = false;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '4';
            Last_Was_Equal = false;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '5';
            Last_Was_Equal = false;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '6';
            Last_Was_Equal = false;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '7';
            Last_Was_Equal = false;
        }
        private void eight_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '8';
            Last_Was_Equal = false;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            Calc_box.Text += '9';
            Last_Was_Equal = false;
        }
    }
}
