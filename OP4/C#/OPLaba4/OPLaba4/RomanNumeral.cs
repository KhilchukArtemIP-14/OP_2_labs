using System;
using System.Collections.Generic;
namespace RomanNumbers
{
    public class Roman_numerals
    {
        private string romanValue;

        public Roman_numerals(int temp)
        {
            SetValue(DecimalToRoman(temp));
        }
        public Roman_numerals(string temp)
        {
            SetValue(temp);
        }
        public Roman_numerals(Roman_numerals temp)
        {
            romanValue = temp.romanValue;
        }

        public string GetRomanValue()
        {
            return romanValue;
        }
        public int GetDecimalValue()
        {
            return RomanToDecimal(romanValue);
        }
        public void SetValue(int valueInDeicmal)
        {
            romanValue = DecimalToRoman(valueInDeicmal);
        }
        public void SetValue(string valueInRoman)
        {

            romanValue = valueInRoman;
        }
        public static string DecimalToRoman(int number)
        {
            if (number >= 1000) return "M" + DecimalToRoman(number - 1000);
            if (number >= 900) return "CM" + DecimalToRoman(number - 900);
            if (number >= 500) return "D" + DecimalToRoman(number - 500);
            if (number >= 400) return "CD" + DecimalToRoman(number - 400);
            if (number >= 100) return "C" + DecimalToRoman(number - 100);
            if (number >= 90) return "XC" + DecimalToRoman(number - 90);
            if (number >= 50) return "L" + DecimalToRoman(number - 50);
            if (number >= 40) return "XL" + DecimalToRoman(number - 40);
            if (number >= 10) return "X" + DecimalToRoman(number - 10);
            if (number >= 9) return "IX" + DecimalToRoman(number - 9);
            if (number >= 5) return "V" + DecimalToRoman(number - 5);
            if (number >= 4) return "IV" + DecimalToRoman(number - 4);
            if (number >= 1) return "I" + DecimalToRoman(number - 1);
            return "";
        }

        public static int RomanToDecimal(string number)
        {
            Dictionary<Char, Int32> values = new Dictionary<char, int>
            {{'I', 1 },
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}};

            int result = 0;
            for (int i = number.Length - 1, last = 0; i >= 0; i--)
            {
                int current = values[number[i]];
                if (current < last)
                {
                    result -= current;
                }
                else
                {
                    result += current;
                }
                last = current;
            }

            return result;
        }
        public static Roman_numerals operator ++(Roman_numerals number)
        {
            int value = RomanToDecimal(number.romanValue);
            string newOne = DecimalToRoman(value + 1);
            return new Roman_numerals(newOne);
        }
        public static Roman_numerals operator +(Roman_numerals number1,Roman_numerals number2)
        {
            int first = RomanToDecimal(number1.romanValue);
            int second= RomanToDecimal(number2.romanValue);
            string result = DecimalToRoman(first + second);
            return new Roman_numerals(result);
        }
        public string FormattedOutput()
        {
            return String.Format("{0}({1})",romanValue,GetDecimalValue());
        }
    }
}
