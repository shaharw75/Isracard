using System.Collections.Generic;
using System.Linq;
using Isracard.DTO;

namespace Isracard
{
    public static class Calc
    {
        // The history list that is saved in memory
        public static List<CalcItem> History { get; set; } = new List<CalcItem>();

        /// <summary>
        /// Get the history list to the client
        /// </summary>
        /// <returns></returns>
        public static List<CalcItem> GetHistory()
        {
            return History;
        }
        
        /// <summary>
        /// Remove a specific calculation from the history list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static List<DTO.CalcItem> Remove(int index)
        {
            var find = History.Skip(index).FirstOrDefault();
            History.Remove(find);

            return History;
        }
        /// <summary>
        /// Do the calculation and return the result + the updated history list
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="secondNum"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static DTO.CalcResult DoCalc(int firstNum, int secondNum, string action)
        {
            var result = 0;
            
            // Do the calculation
            switch (action)
            {
                case "add":
                    try
                    {
                        result = firstNum + secondNum;
                    }
                    catch
                    {
                        
                    }
                    break;
                case "sub":
                    try
                    {
                        result = firstNum - secondNum;
                    }
                    catch
                    {
                    }

                    break;
                case "mul":
                    try
                    {
                        result = firstNum * secondNum;
                    }
                    catch
                    {
                    }

                    break;
                case "div":
                    try
                    {
                        result = firstNum / secondNum;
                    }
                    catch
                    {
                        
                    }

                    break;                
            }

            // Add the new calculation to the history list if not exists
            var check = History.FirstOrDefault(x =>
                x.Action == action && x.FirstNum == firstNum && x.SecondNum == secondNum);
            if (check == null)
            {
                History.Add(new CalcItem()
                {
                    Action = action,
                    Result = result,
                    FirstNum = firstNum,
                    SecondNum = secondNum
                });
            }

            // prepare the result DTO
            var calcResult = new DTO.CalcResult()
            {
                History = History,
                Result = result
            };
            return calcResult;
        }

        
    }
}