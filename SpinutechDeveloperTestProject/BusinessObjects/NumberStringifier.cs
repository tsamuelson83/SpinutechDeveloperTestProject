using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpinutechDeveloperTestProject.BusinessObjects
{
    public class NumberStringifier
    {
        private string NumToConvert { get; set; }
        public bool Error { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public string StringifiedValue { get; internal set; }

        public NumberStringifier(string val)
        {
            NumToConvert = val;
        }

        public bool Convert()
        {
            StringifiedValue = "";

            //Try to convert the string value coming into a double and if the value is not a valid decimal number that return an error
            if (!double.TryParse(NumToConvert, out double test_value))
            {
                Error = true;
                ErrorMessage = "String can not be converted.";
                return false;
            }


            //  Get the integer value of the number to left of the decimal
            int intVal = (int)Math.Floor(test_value);

            //  Pass the integer value to the conversion function and get back the stringified text for the integer part of the value
            StringifiedValue = NumberToText(intVal).Replace("- ", "-");

            //  Get the two digits to the right of the parsed double.
            var cents = (int)(((decimal)test_value % 1) * 100);

            //  And add the last part of formatted string to the stringified text.
            StringifiedValue += String.Format("and {0:d2}/100 dollars", Math.Abs(cents));

            return true;
        }

        //  with help from stackoverflow code shown here
        //  https://stackoverflow.com/questions/794663/net-convert-number-to-string-representation-1-to-one-2-to-two-etc
        private string NumberToText(int n)
        {
            if (n < 0)
                return "Minus " + NumberToText(-n);
            else if (n == 0)
                return "";
            else if (n <= 19)
                return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
         "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
            else if (n <= 99)
                return new string[] {"Twenty-", "Thirty-", "Forty-", "Fifty-", "Sixty-", "Seventy-",
         "Eighty-", "Ninety-"}[n / 10 - 2] + " " + NumberToText(n % 10);
            else if (n <= 199)
                return "One Hundred " + NumberToText(n % 100);
            else if (n <= 999)
                return NumberToText(n / 100) + "Hundred " + NumberToText(n % 100);
            else if (n <= 1999)
                return "One Thousand " + NumberToText(n % 1000);
            else if (n <= 999999)
                return NumberToText(n / 1000) + "Thousand " + NumberToText(n % 1000);
            else if (n <= 1999999)
                return "One Million " + NumberToText(n % 1000000);
            else if (n <= 999999999)
                return NumberToText(n / 1000000) + "Million " + NumberToText(n % 1000000);
            else if (n <= 1999999999)
                return "One Billion " + NumberToText(n % 1000000000);
            else
                return NumberToText(n / 1000000000) + "Billion " + NumberToText(n % 1000000000);
        }
    }
}