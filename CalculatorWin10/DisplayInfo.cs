using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CalculatorWin10
{
    class DisplayInfo
    {
        public static string currentExpression = "";
        public static string currentVarValue = "";
        public static string secondVarValue = "";
        public static decimal expressionValue = 0;
        public static bool IsEqualPressed = false;
        public static bool IsOperatorShown = false;
        public static bool IsSecondOperatorShown = true;
        public static bool IsDotShown = false;
        public static void DisplayToScreen(string tempChar)
        {
            currentVarValue += tempChar;
            bool tempBool = decimal.TryParse(currentVarValue, out expressionValue);
        }

        internal static void InfoHandler(string buttonValue)
        {
            switch (buttonValue)
            {
                case "clearEverything":
                    ClearEverything();
                    break;
                case "clear":
                    if (IsOperatorShown==false)
                    {
                        currentVarValue = "";
                    }
                    else
                        secondVarValue = "";
                    
                    expressionValue = 0;
                    IsDotShown = false;
                    break;
                case "erase":
                    
                    if (currentVarValue.Length <= 1)
                    {
                        expressionValue = 0;
                        currentVarValue = "";
                        break;
                    }
                    if (currentVarValue[currentVarValue.Length - 1]
                        .ToString() == ".")
                    {
                        IsDotShown = false;
                    }
                    currentVarValue = 
                        currentVarValue.Remove(
                            currentVarValue.Length - 1);
                    if (currentVarValue == "") currentVarValue = "0";
                    expressionValue = decimal.Parse(currentVarValue);
                    
                    
                    break;
                default:
                    break;
            }
        }

        public static void EqualHandler()
        {
            MathControls.ExecuteFunction(MathControls.firstOperator);
            //expressionValue = MathHandler.result;
            currentVarValue = expressionValue.ToString();
            if (IsOperatorShown)
            {
                currentExpression = "";
                IsDotShown = false;
                IsOperatorShown = false;
                if (MainPage.myObj.ToString() == "equals")
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
                currentVarValue = "";
                IsEqualPressed = false;
            }
            if (!IsOperatorShown)
            {
                if ((!IsDotShown) && buttonValue == ".")
                {
                    //DisplayInfo.DisplayToScreen(buttonValue);
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
            
            string s = expressionValue
                .ToString("G16", CultureInfo.InvariantCulture);
            return s;
        }
        private static void ClearEverything()
        {
            currentExpression = "";
            currentVarValue = "";
            secondVarValue = "";
            expressionValue = 0;
            IsEqualPressed = false;
            IsOperatorShown = false;
            IsSecondOperatorShown = true;
            IsDotShown = false;
            MathControls.firstOperator = "";
            MathControls.currentOperator = "";
            MathControls.mathOperator = "";
        }
    }
}
