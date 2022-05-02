using System;
using TextAbstractionClass;

namespace OP3Laba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input the amount of members of array");
            int number =Convert.ToInt32(Console.ReadLine());
            TText[] array = new TText[number];
            GetArray(array);
            Console.WriteLine("Your array:");
            OutputStrings(array);
            Console.WriteLine("Array succesfully created");
            AddFewLines(array);
            OutputStrings(array);
            string shortest = GetShortestOfArray(array);
            Console.WriteLine("Shortest longest string of array:\n{0}",shortest);
        }
        public static string GetShortestOfArray(TText[] inputArray)
        {
            string shortest = inputArray[0].GetLongestString();
            for(int i = 1; i < inputArray.Length; i++)
            {
                string temp = inputArray[i].GetLongestString();
                if (shortest.Length>temp.Length)
                {
                    shortest = temp;
                }
            }
            return shortest;
        }
        public static void AddFewLines(TText[] array)
        {
            int min = 0, max = array.Length - 1;
            Console.WriteLine("Starting the procces of adding lines to classes\nEnter index of your member in range [{0};{1}]\nTo exit, enter index out of range",min,max);
            int index = Convert.ToInt32(Console.ReadLine());
            while ((index < max+1) & (index > min-1))
            {
                Console.WriteLine("Enter your string");
                string temp = Console.ReadLine();
                array[index].AppendString(temp);
                Console.WriteLine("Addition executed succesfully\nEnter index");
                index = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Array modified successfully\nResulting look:");
        }

        public static void OutputStrings(TText[] array)
        {
            Console.WriteLine("------------------------------------------------------");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0}-th member of array:",i+1);
                foreach(string str in array[i].GetStrings())
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("------------------------------------------------------");
            }
        }
        public static void GetArray(TText[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Initiating creation of {0}-th member of array",i+1);
                array[i] = new TText();
            }
        }
    }

}
