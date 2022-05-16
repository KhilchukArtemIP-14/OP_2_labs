using System;
using RomanNumbers;

namespace OP4Laba
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Roman_numerals R1 = new Roman_numerals(rand.Next(20)), R2 = new Roman_numerals("X"), R3 = new Roman_numerals(R2);
            Console.WriteLine("Inital state of variables:");
            ShowNumeralsBeforeOperations(R1,R2,R3);
            ++R1;
            Console.WriteLine("\nPlease, input the decimal value, that R2 what would be incremented with");
            int temp = Convert.ToInt32(Console.ReadLine());
            R2 += new Roman_numerals(Roman_numerals.DecimalToRoman(temp));
            R3 = R1 + R2;
            Console.WriteLine("Values after operations:");
            ShowNumeralsAfterOperations(R1, R2, R3, temp);
            Console.WriteLine("\nAnd so, N3 is: {0}", R3.GetDecimalValue());
        }
        public static void ShowNumeralsBeforeOperations(Roman_numerals R1, Roman_numerals R2, Roman_numerals R3)
        {
            Console.WriteLine("\nFirst numeral value:");
            Console.WriteLine(R1.FormattedOutput());
            Console.WriteLine("\nSecond numeral value");
            Console.WriteLine(R2.FormattedOutput());
            Console.WriteLine("\nThird numeral");
            Console.WriteLine(R3.FormattedOutput());
        }
        public static void ShowNumeralsAfterOperations(Roman_numerals R1, Roman_numerals R2, Roman_numerals R3, int temp)
        {
            Console.WriteLine("\n(++R1)=++{0}:",(new Roman_numerals(R1.GetDecimalValue()-1)).FormattedOutput());
            Console.WriteLine(R1.FormattedOutput());
            Console.WriteLine("\n(R2+={0})={1} + {2}:", temp, (new Roman_numerals(R2.GetDecimalValue() - temp)).FormattedOutput(), (new Roman_numerals(temp)).FormattedOutput());
            Console.WriteLine(R2.FormattedOutput());
            Console.WriteLine("\nR3=R1+R2={0}({2}) + {1}({3}):",R1.GetRomanValue(),R2.GetRomanValue(),R1.GetDecimalValue(),R2.GetDecimalValue());
            Console.WriteLine(R3.FormattedOutput() ); 
        }
    }
}
