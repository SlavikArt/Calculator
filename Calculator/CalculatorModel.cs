using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalculatorModel
    {
        public double LeftOperand { get; set; }
        public double RightOperand { get; set; }
        public char Operator { get; set; }
        
        public CalculatorModel() 
        {
            LeftOperand = 0;
            RightOperand = 0;
            Operator = '+';
        }

        public double Result
        {
            get
            {
                switch (Operator)
                {
                    case '+':
                        return LeftOperand + RightOperand;
                    case '-':
                        return LeftOperand - RightOperand;
                    case '×':
                        return LeftOperand * RightOperand;
                    case '÷':
                        return LeftOperand / RightOperand;
                }
                return -1;
            }
        }
    }
}
