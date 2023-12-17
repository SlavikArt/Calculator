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
        private CalculatorViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CalculatorViewModel();
            DataContext = viewModel;
        }

        public void NumberButtonClicked(object sender, RoutedEventArgs e)
        {
            string buttonContent = (sender as Button).Content.ToString();
            if (!viewModel.isOperatorClicked)
            {
                if (viewModel.LeftOperand == "0" && buttonContent != ",")
                {
                    viewModel.LeftOperand = buttonContent;
                }
                else if (buttonContent == "," && !viewModel.LeftOperand.Contains(","))
                {
                    viewModel.LeftOperand += ",";
                }
                else
                {
                    viewModel.LeftOperand += buttonContent;
                }
            }
            else
            {
                if (viewModel.RightOperand == "0" && buttonContent != ",")
                {
                    viewModel.RightOperand = buttonContent;
                }
                else if (buttonContent == "," && !viewModel.RightOperand.Contains(","))
                {
                    viewModel.RightOperand += ",";
                }
                else
                {
                    viewModel.RightOperand += buttonContent;
                }
            }
        }

        public void OperatorButtonClicked(object sender, RoutedEventArgs e)
        {
            viewModel.Operator = (sender as Button).Content.ToString()[0];
            viewModel.isOperatorClicked = true;
        }

        public void ClearButtonClicked(object sender, RoutedEventArgs e)
        {
            viewModel.ClearOperandsAndOperator();
        }

        public void ClearLastNumberButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!viewModel.isOperatorClicked)
            {
                if (viewModel.LeftOperand.Length > 1)
                {
                    viewModel.LeftOperand = viewModel.LeftOperand.Remove(viewModel.LeftOperand.Length - 1);
                }
                else
                {
                    viewModel.LeftOperand = "0";
                }
            }
            else
            {
                if (viewModel.RightOperand.Length > 1)
                {
                    viewModel.RightOperand = viewModel.RightOperand.Remove(viewModel.RightOperand.Length - 1);
                }
                else
                {
                    viewModel.RightOperand = "0";
                }
            }
        }

        public void EqualsButtonClicked(object sender, RoutedEventArgs e)
        {
            viewModel.Calculate();
            viewModel.LeftOperand = viewModel.Result.ToString();
            viewModel.RightOperand = "0";
        }
    }
}
