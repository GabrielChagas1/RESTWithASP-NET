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

        Methods Methods = new Methods();
        // GET api/values/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secondNumber)
        {
           if(Methods.IsNumeric(firstNumber) && Methods.IsNumeric(secondNumber))
           {
                var Sum = Methods.ConvertToDecimal(firstNumber) + Methods.ConvertToDecimal(secondNumber);
                return Ok(Sum.ToString());
           }
           return BadRequest("Invalid Input");

        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Subtraction(string firstNumber, string secondNumber)
        {
            if(Methods.IsNumeric(firstNumber) && Methods.IsNumeric(secondNumber))
            {
                var Sub = Methods.ConvertToDecimal(firstNumber) - Methods.ConvertToDecimal(secondNumber);
                return Ok(Sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Multiplication(string firstNumber, string secondNumber)
        {
            if (Methods.IsNumeric(firstNumber) && Methods.IsNumeric(secondNumber))
            {
                var Mult = Methods.ConvertToDecimal(firstNumber) * Methods.ConvertToDecimal(secondNumber);
                return Ok(Mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult<string> Division(string firstNumber, string secondNumber)
        {
            if (Methods.IsNumeric(firstNumber) && Methods.IsNumeric(secondNumber))
            {
                var Div = Methods.ConvertToDecimal(firstNumber) / Methods.ConvertToDecimal(secondNumber);
                return Ok(Div.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public ActionResult<string> AverageNumbers(string firstNumber, string secondNumber)
        {
            if (Methods.IsNumeric(firstNumber) && Methods.IsNumeric(secondNumber))
            {
                var avarage = (Methods.ConvertToDecimal(firstNumber) + Methods.ConvertToDecimal(secondNumber) /2);
                return Ok(avarage.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("root/{Number}")]
        public ActionResult<string> Root(string Number)
        {
            if (Methods.IsNumeric(Number))
            {
                return Ok(Math.Sqrt((double)Methods.ConvertToDecimal(Number)).ToString());
            }
            return BadRequest("Invalid Input");
        }
    }
}