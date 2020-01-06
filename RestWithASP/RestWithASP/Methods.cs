using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP
{
    public class Methods
    {
        //Métodos de conversões 
        public Decimal ConvertToDecimal(string Number)
        {
            decimal DecimalValue;
            if (decimal.TryParse(Number, out DecimalValue))
            {
                return DecimalValue;
            }
            return 0;
        }

        public bool IsNumeric(string StrNumber)
        {
            bool isNumber = double.TryParse(StrNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double Number);
            return isNumber;
        }
    }
}
