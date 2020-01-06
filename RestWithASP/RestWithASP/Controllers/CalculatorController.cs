using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DO.Validation.Codes;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASP.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/values/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
           if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
           {
                var Sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(Sum.ToString());
           }

            return BadRequest("Invalid Input");

        }

        private Decimal ConvertToDecimal(string Number)
        {
            decimal DecimalValue;
            if (decimal.TryParse(Number, out DecimalValue))
            {
                return DecimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string StrNumber)
        {
            bool isNumber = double.TryParse(StrNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double Number);
            return isNumber;
        }
    }
}