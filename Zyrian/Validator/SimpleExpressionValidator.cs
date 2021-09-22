using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator.Zyrian.Validator
{
    class SimpleExpressionValidator
    {
        private List<string> AllOperators = new List<string>() {
            "/", "*", "-", "+"
        };

        private string addableOperand = "0";

        public bool IsExpressionEmpty(string expression) => !expression.Any();

        public bool IsSecondOperandExist(string expression)
        {
            if (!IsExpressionEmpty(expression) && IsContainsOperator(expression))
            {
                string rightSide = "";
                int index = 0;
                int checkLength = 0;

                for (index = 0; !IsOperator(expression[index]); ++index) { }
                for (int i = index; !NextSymbolIsVoid(i, expression) && !IsNumericOperand(expression[i]); ++i)
                {
                    ++checkLength;
                }
                
                for (int i = index + checkLength; i < expression.Length; i++)
                {
                    rightSide += expression[i];
                }
                if (rightSide.Any() && IsNumericOperand(rightSide.First()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsOperator(char symbol) => AllOperators.Contains(symbol.ToString());

        public bool IsNumericOperand(char symbol) => !IsOperator(symbol);

        public bool IsContainsOperator(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsOperator(expression[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public string AddSecondOperand() => addableOperand;

        public string FillExpression() => addableOperand;

        private bool NextSymbolIsVoid(int i, string expression) => i >= expression.Length;
    }
}
