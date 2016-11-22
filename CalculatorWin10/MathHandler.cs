using System;
using System.Globalization;

namespace CalculatorWin10
{
    public static class MathControls
    {
        public static string firstOperator = "";
        public static string currentOperator = "";
        public static string mathFunction = "";
        private static string functionInput;
        //public static decimal result;
        
        // ReSharper disable once MethodTooLong
        public static void WriteOperator(string selectedOperator)
        {
            switch (selectedOperator)
            {
                case "addition":
                    mathFunction = " + ";
                    AddSimpleOperator();
                    break;
                case "subtraction":
                    mathFunction = " - ";
                    AddSimpleOperator();
                    break;
                case "multiplication":
                    mathFunction = " ╳ ";
                    AddSimpleOperator();
                    break;
                case "division":
                    mathFunction = " ÷ ";
                    AddSimpleOperator();
                    break;
                case "percent":
                    ExecuteFunction();
                    break;
                case "squareRoot":
                    mathFunction = " √() ";
                    AddComplexOperator();
                    ExecuteFunction();
                    break;
                case "powerOfTwo":
                    mathFunction = " sqr() ";
                    AddComplexOperator();
                    ExecuteFunction();
                    break;
                case "oneOver":
                    mathFunction = " 1/() ";
                    AddComplexOperator();
                    ExecuteFunction();
                    break;
            }

            #region MyRegion
            
            //if (DisplayInfo.IsFirstOperatorShown & DisplayInfo.secondVarValue == "")
            //{
            //    RemoveCharacters(3);
            //    AddSimpleOperator();
            //}
            //if (DisplayInfo.IsFirstOperatorShown & DisplayInfo.secondVarValue != "")
            //{
            //    DisplayInfo.currentExpression += DisplayInfo.secondVarValue;
            //    AddOperator();
            //    ExecuteFunction(firstOperator);
            //    firstOperator = currentOperator; currentOperator = "";
            //}
            DisplayInfo.firstVarValue = DisplayInfo.expressionValue.ToString(CultureInfo.InvariantCulture);

            #endregion
        }

        private static void AddOperator()
        {
            DisplayInfo.currentExpression += mathFunction;
            
            if (DisplayInfo.IsFirstOperatorShown)
            {
                DisplayInfo.IsSecondOperatorShown = true;
            }
            DisplayInfo.IsFirstOperatorShown = true;
        }
        private static void AddSimpleOperator()
        {
            if (!DisplayInfo.IsFirstOperatorShown)
            {
                DisplayInfo.currentExpression += DisplayInfo.firstVarValue;
                AddOperator();
                
            }
            else
            {
                if(DisplayInfo.secondVarValue != "")
                {
                    DisplayInfo.currentExpression += DisplayInfo.secondVarValue;
                    AddOperator();
                    ExecuteFunction(firstOperator);
                    firstOperator = currentOperator; currentOperator = "";

                }
            }
            //DisplayInfo.currentExpression += mathFunction;
            DisplayInfo.IsFirstOperatorShown = true;
        }
        private static void AddComplexOperator()
        {
            AddOperator();
            RemoveCharacters(2);
            if (DisplayInfo.IsFirstOperatorShown & DisplayInfo.IsSecondOperatorShown)
            {
                DisplayInfo.currentExpression += 
                    DisplayInfo.secondVarValue + ") ";
            }
            DisplayInfo.currentExpression += 
                DisplayInfo.firstVarValue + ") ";
        }

        private static void RemoveCharacters(int charAmount)
        {
            DisplayInfo.currentExpression =
                        DisplayInfo.currentExpression.Remove(
                            DisplayInfo.currentExpression.Length - charAmount);
        }

        private static void DetermineVariable()
        {
            if (!DisplayInfo.IsFirstOperatorShown)
                functionInput = DisplayInfo.secondVarValue;
            else
                functionInput = DisplayInfo.firstVarValue;

        }

        // ReSharper disable once MethodTooLong
        public static void ExecuteFunction(
            string selectedOperator, 
            decimal num1, 
            decimal num2)
        {
            if (selectedOperator!="percent")
            {
                DetermineVariable();
            }
            //DetermineVariable();
            switch (selectedOperator)
            {
                case "addition":
                    Addition(num1, num2);
                    break;
                case "subtraction":
                    Subtraction(num1, num2);
                    break;
                case "multiplication":
                    Multiplication(num1, num2);
                    break;
                case "division":
                    Division(num1, num2);
                    break;
                case "percent":
                    Percentage(
                        DisplayInfo.IsFirstOperatorShown ? 
                        DisplayInfo.secondVarValue
                        : 0.ToString());
                    AddComplexOperator();
                    break;
                case "squareRoot":
                    SquareRoot(functionInput);
                    break;
                case "powerOfTwo":
                    PowerOfTwo(functionInput);
                    break;
                case "oneOver":
                    OneOver(functionInput);
                    break;
            }
        }

        #region Functions
        
        private static void Addition(decimal num1, decimal num2)
        {
            DisplayInfo.expressionValue =
                num1 + num2;
                
            DisplayInfo.secondVarValue = "";
        }
        private static void Subtraction(decimal num1, decimal num2)
        {
            DisplayInfo.expressionValue =
                num1 - num2;
            DisplayInfo.secondVarValue = "";
        }
        private static void Multiplication(decimal num1, decimal num2)
        {
            DisplayInfo.expressionValue =
                num1 * num2;
            DisplayInfo.secondVarValue = "";
        }
        private static void Division(decimal num1, decimal num2)
        {
            DisplayInfo.expressionValue =
                num1 / num2;
            DisplayInfo.secondVarValue = "";
        }
        private static void Percentage(string input)
        {
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.firstVarValue)
                * decimal.Parse(input) / 100m;
            //DisplayInfo.secondVarValue = "";
        }
        private static void SquareRoot(string input)
        {
            DisplayInfo.expressionValue = decimal
                .Parse(Math
                .Sqrt(double.Parse(input))
                .ToString(CultureInfo.InvariantCulture));

            //DisplayInfo.secondVarValue = "";
        }
        private static void PowerOfTwo(string input)
        {
            DisplayInfo.expressionValue =
                decimal.Parse(input)
                * decimal.Parse(input);
            //DisplayInfo.secondVarValue = "";
        }
        private static void OneOver(string input)
        {
            DisplayInfo.expressionValue =
                1m/ decimal.Parse(input);
            //DisplayInfo.secondVarValue = "";
        }
        #endregion
    }
}
