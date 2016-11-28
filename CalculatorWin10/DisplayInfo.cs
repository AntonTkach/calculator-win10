using System.Globalization;
// ReSharper disable RedundantDefaultMemberInitializer
// ReSharper disable ComplexConditionExpression

namespace CalculatorWin10
{
    internal static class DisplayInfo
    {
        #region DisplayVars
        public static string currentExpression = "";
        public static string firstVarValue = "";
        public static string secondVarValue = "";
        public static decimal expressionValue = 0;
        public static bool IsEqualPressed = false;
        public static bool IsFirstOperatorShown = false;
        public static bool IsSecondOperatorShown = false;
        public static bool IsDotShown = false;
        public static bool ErrorOccured = false;
        #endregion
        public static void DisplayToScreen(string tempChar)
        {
            firstVarValue += tempChar;
            //decimal.TryParse(firstVarValue, out expressionValue);
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
            //if (!(IsFirstOperatorShown&IsSecondOperatorShown))return;
            if (secondVarValue=="")
            {
                if (IsFirstOperatorShown)
                    secondVarValue = expressionValue.
                        ToString(CultureInfo.InvariantCulture);
                else
                    secondVarValue = MathControls.functionInput;
                    //return;
            }
            //if (IsEqualPressed)
            //{
            //    if (secondVarValue == "")
            //        secondVarValue = MathHandler.functionInput;
            //}
            MathControls.ExecuteFunction(MathControls.firstOperator);
            //expressionValue = MathHandler.result;
            firstVarValue = ExpressionToSuitable(expressionValue);
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
            if (IsDotShown & buttonValue == ".") return;
            if (currentExpression=="" & IsEqualPressed)
            {
                firstVarValue = "";
                IsEqualPressed = false;
            }
            if (!IsFirstOperatorShown)
            {
                if ((!IsDotShown) &
                    buttonValue == ".")
                {
                    InputDot(ref firstVarValue);
                    expressionValue = decimal.Parse(firstVarValue);
                    return;
                }
                if (firstVarValue != "")
                {
                    if (IsDotShown &
                    firstVarValue
                    [firstVarValue.Length - 1]
                    .ToString() == "0")
                    {
                        if (buttonValue != "0")
                            firstVarValue = firstVarValue.Remove(firstVarValue.Length - 1);
                        //else
                        //    return;
                    }
                }
                
                firstVarValue += buttonValue;
                expressionValue = decimal.Parse(firstVarValue);
            }
            else
            {
                if ((!IsDotShown) &
                    buttonValue == ".")
                {
                    InputDot(ref secondVarValue);
                    expressionValue = decimal.Parse(secondVarValue);
                    return;

                }
                secondVarValue += buttonValue;
                expressionValue = decimal.Parse(secondVarValue);
            }
        }
        public static string ExpressionToSuitable(decimal arg0)
        {
            return arg0.ToString("G16", CultureInfo.InvariantCulture);
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
            MathControls.functionInput = "";
            MathControls.isMultiInput = false;
            MathControls.multiInputValue = null;
            MathControls.multiInputTimes = 0;
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

        private static void InputDot(ref string variable)
        {
            
            {
                if (variable == "")
                    variable += "0";

                if (variable == "0")
                    variable += ".0";
                IsDotShown = true;
            }
        }

        public static void PlusMinus()
        {
            expressionValue = expressionValue - (2*expressionValue);
            if (IsFirstOperatorShown)
            {
                ConvertNegative(ref secondVarValue);
            }
            else
            {
                ConvertNegative(ref firstVarValue);
            }
        }

        private static void ConvertNegative(ref string input)
        {
            if (MathControls.currentOperator=="minus")
            input = "negative(" + input + ")";
            else
            {
                input = "-" + input;
            }
        }
    }
}
