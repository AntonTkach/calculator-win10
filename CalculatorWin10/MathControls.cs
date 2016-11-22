using System;
using System.Globalization;
// ReSharper disable ComplexConditionExpression

namespace CalculatorWin10
{
    internal static class MathControls
    {
        public static string firstOperator = "";
        public static string currentOperator = "";
        public static string mathFunction = "";
        public static string functionInput="";
        public static bool isMultiInput;
        public static string multiInputValue;
        public static int multiInputTimes;

        // ReSharper disable once MethodTooLong
        public static void WriteOperator(string selectedOperator)
        {
            if (currentOperator == firstOperator)
            {
                multiInputTimes += 1;
            }
            else
            {
                multiInputTimes = 0;
            }
            isMultiInput = currentOperator == firstOperator;

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
                    mathFunction = "  ";
                    ExecuteFunction(selectedOperator);
                    break;
                case "squareRoot":
                    mathFunction = "√()";
                    AddComplexOperator();
                    ExecuteFunction(selectedOperator);
                    break;
                case "powerOfTwo":
                    mathFunction = "sqr()";
                    AddComplexOperator();
                    ExecuteFunction(selectedOperator);
                    break;
                case "oneOver":
                    mathFunction = "1/()";
                    AddComplexOperator();
                    ExecuteFunction(selectedOperator);
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
#endregion
            
            if (DisplayInfo.IsSecondOperatorShown)
            {
                // ReSharper disable once ComplexConditionExpression
                if (selectedOperator == "percent" |
                    selectedOperator == "squareRoot" |
                    selectedOperator == "powerOfTwo" |
                    selectedOperator == "oneOver")
                {
                    DisplayInfo.secondVarValue = DisplayInfo.expressionValue.ToString(CultureInfo.InvariantCulture);
                    if (selectedOperator == "percent")
                    {
                        DisplayInfo.currentExpression += DisplayInfo.secondVarValue;
                    }
                    return;
                }
                
            }
            DisplayInfo.firstVarValue = DisplayInfo.expressionValue.ToString(CultureInfo.InvariantCulture);

            
        }

        #region Writing / Replacing Operators
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
            if (isMultiInput)
            {
                RemoveCharacters(multiInputTimes +
                    multiInputValue
                    //.ToString(CultureInfo.InvariantCulture)
                    .Length);
                //AddOperator();
                //DisplayInfo.currentExpression = "1/(";
                DisplayInfo.currentExpression += mathFunction;
                RemoveCharacters(1);
                DisplayInfo.currentExpression += multiInputValue;
                //isMultiInput = false;
                //AddComplexOperator();
                //isMultiInput = true;
                for (int i = 0; i <= multiInputTimes; i++)
                {
                    DisplayInfo.currentExpression += ")";
                }
            }
            else
            {
                AddOperator();
                RemoveCharacters(1);
                if (currentOperator == "percent") return;
                if (DisplayInfo.IsFirstOperatorShown & DisplayInfo.IsSecondOperatorShown)
                {
                    DisplayInfo.currentExpression +=
                        DisplayInfo.secondVarValue + ")";
                    return;
                }
                DisplayInfo.currentExpression +=
                    DisplayInfo.firstVarValue + ")";
            }
        }
        private static void RemoveCharacters(int charAmount)
        {
            DisplayInfo.currentExpression =
                        DisplayInfo.currentExpression.Remove(
                            DisplayInfo.currentExpression.Length - charAmount);
        }
        #endregion
        private static void DetermineVariable()
        {
            if (DisplayInfo.IsSecondOperatorShown)
            {
                functionInput = DisplayInfo.secondVarValue;
                //if (firstOperator == currentOperator)
                //    functionInput = DisplayInfo.firstVarValue;
                //else
                //    
            }
            else
                functionInput = DisplayInfo.firstVarValue;

        }

        // ReSharper disable once MethodTooLong
        public static void ExecuteFunction(string selectedOperator)
        {
            if (selectedOperator == "squareRoot" |
                selectedOperator == "powerOfTwo" |
                selectedOperator == "oneOver")
            {
                DetermineVariable();
            }
            //DetermineVariable();
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

        #region Sipmle And Complex Functions
        private static void Addition()
        {
            //if (DisplayInfo.IsEqualPressed)
            //{
            //    if (DisplayInfo.secondVarValue == "")
            //        DisplayInfo.secondVarValue = functionInput;
            //}
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.firstVarValue)
                + decimal.Parse(DisplayInfo.secondVarValue);
            functionInput = DisplayInfo.secondVarValue;
            DisplayInfo.secondVarValue = "";
        }
        private static void Subtraction()
        {
            //if (DisplayInfo.IsEqualPressed)
            //{
            //    if(DisplayInfo.secondVarValue=="")
            //    DisplayInfo.secondVarValue = functionInput;
            //}
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.firstVarValue)
                - decimal.Parse(DisplayInfo.secondVarValue);
            functionInput = DisplayInfo.secondVarValue;
            DisplayInfo.secondVarValue = "";
        }
        private static void Multiplication()
        {
            if (DisplayInfo.IsEqualPressed)
                DisplayInfo.secondVarValue = functionInput;
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.firstVarValue)
                * decimal.Parse(DisplayInfo.secondVarValue);
            functionInput = DisplayInfo.secondVarValue;
            DisplayInfo.secondVarValue = "";
        }
        private static void Division()
        {
            #region DivByZeroError

            // ReSharper disable once ComplexConditionExpression
            if (DisplayInfo.firstVarValue == "0" |
                DisplayInfo.secondVarValue == "0")
            {
                DisplayInfo.ErrorOccured = true;
                return;
            }

            #endregion
            if (DisplayInfo.IsEqualPressed)
                DisplayInfo.secondVarValue = functionInput;
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.firstVarValue)
                / decimal.Parse(DisplayInfo.secondVarValue);
            functionInput = DisplayInfo.secondVarValue;
            DisplayInfo.secondVarValue = "";
        }
        private static void Percentage(string input)
        {
            DisplayInfo.expressionValue =
                decimal.Parse(DisplayInfo.firstVarValue)
                * decimal.Parse(input) / 100m;
            
        }
        private static void SquareRoot(string input)
        {
            DisplayInfo.expressionValue = decimal
                .Parse(Math
                .Sqrt(double.Parse(input))
                .ToString(CultureInfo.InvariantCulture));

            
        }
        private static void PowerOfTwo(string input)
        {
            DisplayInfo.expressionValue =
                decimal.Parse(input)
                * decimal.Parse(input);
            firstOperator = "";

        }
        private static void OneOver(string input)
        {
            #region DivByZeroError

            // ReSharper disable once ComplexConditionExpression
            if (DisplayInfo.firstVarValue == "0" |
                DisplayInfo.secondVarValue == "0")
            {
                DisplayInfo.ErrorOccured = true;
                return;
            }

            #endregion

            DisplayInfo.expressionValue =
                1m/ decimal.Parse(input);
            
            if (isMultiInput) DisplayInfo.secondVarValue =
                    DisplayInfo.expressionValue.
                    ToString(CultureInfo.InvariantCulture);
            else
            {
                multiInputValue = input;
            }
        }
        #endregion
    }
}
