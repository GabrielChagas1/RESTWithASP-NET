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
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
           if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
           {
                var Sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(Sum.ToString());
           }
           return BadRequest("Invalid Input");

        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sub(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var Sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(Sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Mul(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var Mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(Mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var Div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(Div.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("root/{Number}")]
        public ActionResult<string> Root(string Number)
        {
            if (IsNumeric(Number))
            {
                return Ok(Math.Sqrt(ConvertToDouble(Number)).ToString());
            }
            return BadRequest("Invalid Input");
        }

        //Métodos de conversões 
        private Double ConvertToDouble(string Number)
        {
            if(Double.TryParse(Number, out Double Value))
            {
                return Value;
            }
            return 0;
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