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
            string name = Console.ReadLine();
            string fullDirectory = String.Concat(directory, '\\', name, ".txt");
            FileStream fs = new FileStream(fullDirectory, FileMode.OpenOrCreate, FileAccess.Write);
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
            string[] allStrings = File.ReadAllLines(fullDirectory);
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
            name = Console.ReadLine();
            fullDirectory = String.Concat(directory, '\\', name, ".txt");
            fs = new FileStream(fullDirectory, FileMode.OpenOrCreate, FileAccess.Write);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < allStrings.Length; i++)
                {
                    sw.WriteLine(String.Concat(allStrings[i].Length, " ",allStrings[i]));
                }
            }
            Console.WriteLine("Execution ended successfully. Check your file");
        }
    }
}
