using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel model;
        public bool isOperatorClicked { get; set; }

        public CalculatorViewModel() 
        { 
            model = new CalculatorModel();
            isOperatorClicked = false;
        }

        public string LeftOperand
        {
            get => model.LeftOperand.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue))
                {
                    model.LeftOperand = parsedValue;
                    OnPropertyChanged(nameof(LeftOperand));
                    OnPropertyChanged(nameof(CurrentOperation));
                }
            }
        }

        public string RightOperand
        {
            get => model.RightOperand.ToString();
            set
            {
                if (double.TryParse(value, out double parsedValue))
                {
                    model.RightOperand = parsedValue;
                    OnPropertyChanged(nameof(RightOperand));
                    OnPropertyChanged(nameof(CurrentOperation));
                }
            }
        }

        public char Operator
        {
            get => model.Operator;
            set
            {
                model.Operator = value;
                isOperatorClicked = true;
                OnPropertyChanged(nameof(CurrentOperation));
            }
        }

        public double Result
        {
            get => model.Result;
            set => OnPropertyChanged(nameof(Result));
        }

        public void Calculate()
        {
            OnPropertyChanged(nameof(Result));
            isOperatorClicked = false;
        }

        public void ClearOperandsAndOperator()
        {
            LeftOperand = "0";
            RightOperand = "0";
            isOperatorClicked = false;
            Calculate();
        }


        public string CurrentOperation
        {
            get
            {
                if (isOperatorClicked)
                {
                    return $"{LeftOperand} {Operator} {RightOperand}";
                }
                else
                {
                    return LeftOperand;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
