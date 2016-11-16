using System;
using System.Globalization;

namespace CalculatorWin10
{
    public static class MathControls
    {
        public static string firstOperator = "";
        public static string currentOperator = "";
        public static string mathOperator = "";
        private static string functionInput;
        //public static decimal result;
        
        public static void WriteOperator(string selectedOperator)
        {
            switch (selectedOperator)
            {
                case "addition":
                    mathOperator = " + ";
                    AddOperator();
                    break;
                case "subtraction":
                    mathOperator = " - ";
                    AddOperator();
                    break;
                case "multiplication":
                    mathOperator = " ╳ ";
                    AddOperator();
                    break;
                case "division":
                    mathOperator = " ÷ ";
                    AddOperator();
                    break;
                case "percent":
                    break;
                case "squareRoot":
                    mathOperator = " √() ";
                    AddComplexOperator();
                    break;
                case "powerOfTwo":
                    mathOperator = " sqr() ";
                    AddComplexOperator();
                    break;
                case "oneOver":
                    mathOperator = " 1/() ";
                    AddComplexOperator();
                    break;
                default:
                    break;
            }

            #region MyRegion

            //if (!DisplayInfo.IsOperatorShown)
            //{
            //    DisplayInfo.currentExpression += DisplayInfo.currentVarValue;
            //    AddOperator();
            //}
            //if (DisplayInfo.IsOperatorShown & DisplayInfo.secondVarValue == "")
            //{
            //    RemoveCharacters(3);
            //    AddOperator();
            //}
            //if (DisplayInfo.IsOperatorShown & DisplayInfo.secondVarValue != "")
            //{
            //    DisplayInfo.currentExpression += DisplayInfo.secondVarValue;
            //    AddOperator();
            //    ExecuteFunction(firstOperator);
            //    firstOperator = currentOperator; currentOperator = "";
            //}
            //DisplayInfo.currentVarValue = DisplayInfo.expressionValue.ToString(CultureInfo.InvariantCulture);


            #endregion
            
        }

        private static void AddOperator()
        {
            DisplayInfo.currentExpression += mathOperator;
            DisplayInfo.IsOperatorShown = true;
        }

        private static void AddComplexOperator()
        {
            AddOperator();
            RemoveCharacters(2);
            DisplayInfo.currentExpression += 
                DisplayInfo.currentVarValue + ") ";
        }

        private static void RemoveCharacters(int charNumber)
        {
            DisplayInfo.currentExpression =
                        DisplayInfo.currentExpression.Remove(
                            DisplayInfo.currentExpression.Length - charNumber);
        }

        private static void DetermineVariable()
        {
            if (DisplayInfo.IsOperatorShown)
                functionInput = DisplayInfo.secondVarValue;
            else
                functionInput = DisplayInfo.currentVarValue;

        }

        public static void ExecuteFunction(string selectedOperator)
        {
            DetermineVariable();
            switch (selectedOperator)
            {
                case "addition":
                    Addition();
                    break;
                case "subtraction":
                    Subtraction();
                    break;
                case "multiplication":
                    Multiplication();
                    break;
                case "division":
                    Division();
                    break;
                case "percent":
                    Percentage(functionInput);
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
                default:
                    break;
            }
        }

        private static void Addition()
        {
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.currentVarValue)
                + decimal.Parse(DisplayInfo.secondVarValue);
            DisplayInfo.secondVarValue = "";
        }
        private static void Subtraction()
        {
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.currentVarValue)
                - decimal.Parse(DisplayInfo.secondVarValue);
            DisplayInfo.secondVarValue = "";
        }
        private static void Multiplication()
        {
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.currentVarValue)
                * decimal.Parse(DisplayInfo.secondVarValue);
            DisplayInfo.secondVarValue = "";
        }
        private static void Division()
        {
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.currentVarValue)
                / decimal.Parse(DisplayInfo.secondVarValue);
            DisplayInfo.secondVarValue = "";
        }
        private static void Percentage(string input)
        {
            DisplayInfo.expressionValue =
                decimal.Parse(input)
                * decimal.Parse(input) / 100m;
            DisplayInfo.secondVarValue = "";
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
                1/ decimal.Parse(input);
            //DisplayInfo.secondVarValue = "";
        }
    }
}
