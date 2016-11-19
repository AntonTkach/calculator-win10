using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CalculatorWin10
{
    internal static class DisplayInfo
    {
        public static string currentExpression = "";
        public static string firstVarValue = "";
        public static string secondVarValue = "";
        public static decimal expressionValue = 0;
        public static bool IsEqualPressed = false;
        public static bool IsFirstOperatorShown = false;
        public static bool IsSecondOperatorShown = false;
        public static bool IsDotShown = false;
        public static bool ErrorOccured = false;
        public static void DisplayToScreen(string tempChar)
        {
            firstVarValue += tempChar;
            bool tempBool = decimal.TryParse(firstVarValue, out expressionValue);
        }

        public static void InfoHandler(string buttonValue)
        {
            switch (buttonValue)
            {
                case "clearEverything":
                    ClearEverything();
                    break;
                case "clear":
                    if (IsFirstOperatorShown==false)
                    {
                        firstVarValue = "";
                    }
                    else
                        secondVarValue = "";
                    
                    expressionValue = 0;
                    IsDotShown = false;
                    break;
                case "erase":
                    Erase(IsFirstOperatorShown ? secondVarValue : firstVarValue);

                    break;
                default:
                    break;
            }
        }

        public static void EqualHandler()
        {
            if (ErrorOccured)
            {
                InfoHandler("clearEverything");
            }
            if (!(IsFirstOperatorShown&IsSecondOperatorShown))return;
            if (secondVarValue=="")
            {
                secondVarValue = expressionValue.
                    ToString(CultureInfo.InvariantCulture);
            }
            MathControls.ExecuteFunction(MathControls.firstOperator);
            //expressionValue = MathHandler.result;
            firstVarValue = expressionValue.ToString(CultureInfo.InvariantCulture);
            if (IsFirstOperatorShown)
            {
                currentExpression = "";
                IsDotShown = false;
                IsFirstOperatorShown = false;
                IsSecondOperatorShown = false;
                //if (MainPage.myObj.ToString() == "equals")
                    IsEqualPressed = true;
            }
            else
            {
                IsDotShown = false;
            }
            
        }
        public static void DisplayNumbers(string buttonValue)
        {
            if (currentExpression=="" & IsEqualPressed)
            {
                firstVarValue = "";
                IsEqualPressed = false;
            }
            if (!IsFirstOperatorShown)
            {
                if ((!IsDotShown) & buttonValue == ".")
                {
                    IsDotShown = true;
                }
                DisplayToScreen(buttonValue);
            }
            else
            {
                secondVarValue += buttonValue;
                expressionValue = decimal.Parse(secondVarValue);
            }
        }
        public static string ExpressionToSuitable()
        {
            
            var s = expressionValue
                .ToString("G16", CultureInfo.InvariantCulture);
            return s;
        }
        private static void ClearEverything()
        {
            currentExpression = "";
            firstVarValue = "";
            secondVarValue = "";
            expressionValue = 0;
            IsEqualPressed = false;
            IsFirstOperatorShown = false;
            IsSecondOperatorShown = false;
            IsDotShown = false;
            ErrorOccured = false;
            MathControls.firstOperator = "";
            MathControls.currentOperator = "";
            MathControls.mathFunction = "";
            
        }

        private static void Erase(string variable)
        {
            if (variable.Length == 0) return;
            if (variable[variable.Length - 1]
                .ToString() == ".")
            {
                IsDotShown = false;
            }
            variable =
                variable.Remove(
                    variable.Length - 1);
            if (variable.Length == 0) variable = "0";
            expressionValue = decimal.Parse(variable);


        }
    }
}
