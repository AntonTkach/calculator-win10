using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWin10
{
    class MemoryHandler
    {
        private static decimal memory = 0;
        public static void ActionMemory(string buttonValue)
        {
            decimal tempMemory = 0;
            if (decimal.TryParse(DisplayInfo.firstVarValue, out tempMemory))
            {
                switch (buttonValue)
                {
                    case "memoryAdd":
                        memory += DisplayInfo.expressionValue;
                        break;
                    case "memorySubstract":
                        memory -= DisplayInfo.expressionValue;
                        break;
                    case "memorySave":
                        memory = DisplayInfo.expressionValue;
                        break;
                    default:
                        break;
                }
            }
            switch (buttonValue)
            {
                case "memoryClear":
                    memory = 0;
                    break;
                case "memoryRetrieve":
                    DisplayInfo.DisplayToScreen(memory.ToString());
                    break;
                case "memory":
                    // TODO: popup or slide window with the current item stored
                    break;
                default:
                    break;
            }
        }
    }
}
