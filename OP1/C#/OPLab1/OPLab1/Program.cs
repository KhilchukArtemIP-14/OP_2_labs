using System;
using System.IO;
using System.Collections.Generic;
namespace OPLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input file directory");
            string directory = Console.ReadLine();
            Console.WriteLine("Please, input file name");
            string name1 = Console.ReadLine();
            string fullDirectory1 = String.Concat(directory, '\\', name1, ".txt");
            FileStream fs = new FileStream(fullDirectory1, FileMode.OpenOrCreate, FileAccess.Write);
            string input;
            using(StreamWriter sw= new StreamWriter(fs))
            {
                Console.WriteLine("You are filling your file now. To stop, enter ctrl+b");
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == Convert.ToString(Convert.ToChar(2))) break;
                    sw.WriteLine(input);
                }
            }
            string[] allStrings = File.ReadAllLines(fullDirectory1);
            string tempStr;
            for (int i = 0; i < allStrings.Length - 1; i++)
            {
                for (int j = 0; j < allStrings.Length - 1 - i; j++)
                {
                    if (allStrings[j].Length < allStrings[j + 1].Length)
                    {
                        tempStr = allStrings[j];
                        allStrings[j] = allStrings[j + 1];
                        allStrings[j + 1] = tempStr;
                    }
                }
            }
            Console.WriteLine("Array of strings after sorting:");
            foreach (string num in allStrings)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("Please, input name for output file:");
            string name2 = Console.ReadLine();
            string fullDirectory2 = String.Concat(directory, '\\', name2, ".txt");
            fs = new FileStream(fullDirectory2, FileMode.OpenOrCreate, FileAccess.Write);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < allStrings.Length; i++)
                {
                    sw.WriteLine(String.Concat(allStrings[i].Length, " ",allStrings[i]));
                }
            }
            Console.WriteLine("Execution ended successfully. Check your file");
            Console.WriteLine("Initial state of file:");
            foreach (string num in File.ReadAllLines(fullDirectory1))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("Final state of file:");
            foreach (string num in File.ReadAllLines(fullDirectory2))
            {
                Console.WriteLine(num);
            }
        }
    }
}
