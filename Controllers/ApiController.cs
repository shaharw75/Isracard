using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isracard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// Do calculation
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="secondNum"></param>
        /// <param name="what"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Calc")]
        public DTO.CalcResult Calc(int firstNum, int secondNum, string what)
        {
            return Isracard.Calc.DoCalc(firstNum,secondNum,what);
        }
        
        /// <summary>
        /// Get the history list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHistory")]
        public List<DTO.CalcItem> GetHistory()
        {
            return Isracard.Calc.GetHistory();
        }
        
        /// <summary>
        /// Remove specific calculation from the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Remove")]
        public List<DTO.CalcItem> Remove(int index)
        {
            return Isracard.Calc.Remove(index);
        }
    }
}