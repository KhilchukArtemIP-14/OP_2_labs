using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using OP_laba2Library;

namespace OPLaba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = GetPath();
            FillTheFile(directory);
        }
        public static string GetPath()
        {
            Console.WriteLine("Please, input the name of your file:");
            return string.Concat("C:\\Users\\Artem\\Desktop\\forOP\\", Console.ReadLine(),".bin");
        }
        
        public static string GetName()
        {
            Console.WriteLine("Please, enter the name of your para");
            Console.WriteLine("To exit addition of items to your file, enter ctrl+b");
            return Console.ReadLine();
        }

        public static string GetTime(int lastPara)
        {
            int time;
            string altogether;
            if (lastPara != -1)
            {
                do
                {
                    Console.WriteLine("Please, input correct time of start of para:");
                    altogether = Console.ReadLine().Trim();
                    time = ConvertTimeToMins(altogether);
                } while ((time - lastPara < 5) || (time - lastPara > 45));
                return altogether;
            }

            else
            {
                Console.WriteLine("Enter time of start of first lecture:");
                return Console.ReadLine();
            }
        }

        public static string GetEndOfPara(string start)
        {
            int timeInMins = ConvertTimeToMins(start)+105;
            return string.Format("{0:d2}:{1:d2}", timeInMins / 60, timeInMins % 60);
        }

        public static int ConvertTimeToMins(string altogether)
        {
            altogether = altogether.Trim();
            int hours = Convert.ToInt32(altogether.Substring(0, altogether.IndexOf(":")));
            int minutes = Convert.ToInt32(altogether.Substring(1 + altogether.IndexOf(":")));
            return hours * 60 + minutes;
        }

        public static List<Para> GetDeserializedData(string path)
        {
            List<Para> pari = new List<Para>();
            var formatter = new BinaryFormatter();
            using (var stream = File.OpenRead(path))
            {
                while (stream.Position < stream.Length)
                {
                    pari.Add((Para)formatter.Deserialize(stream));
                }
            }
            return pari;
        }

        public static void FillTheFile(string path)
        {
            List<Para> oldPari = new List<Para>();
            int endOfLastParaInMinutes = -1;

            if (File.Exists(path))
            {
                var previosData =GetDeserializedData(path);
                oldPari = previosData;
                endOfLastParaInMinutes = ConvertTimeToMins(previosData[previosData.Count-1].endTime);
            }

            PrintOutRozklad(oldPari);
            List<Para> newPari = new List<Para>();
            string startTime, endTime, name;
            while ((name = GetName()) != Convert.ToString('\u0002'))
            {
                  startTime = GetTime(endOfLastParaInMinutes);
                  endTime = GetEndOfPara(startTime);
                  Console.WriteLine("End of this lecture:{0}", endTime);
                  endOfLastParaInMinutes = ConvertTimeToMins(endTime);
                  newPari.Add(new Para(name, startTime, endTime));
            }
            
            var formatter = new BinaryFormatter();
            using (var stream = File.Open(path,FileMode.Append,FileAccess.Write))
            {
                foreach(Para lecture in newPari)
                {
                    formatter.Serialize(stream, lecture);
                }
            }
        }

        public static void PrintOutRozklad(List<Para> pari)
        {
            if (pari.Count != 0)
            {
                Console.WriteLine("List of previously assigned lectures:\n");
                Console.WriteLine("Name of lecture---------Start-----End\n");
                foreach (Para lecture in pari)
                {
                    lecture.PrintOutData();
                }
            }
            else Console.WriteLine("Note: no lectures were previously assigned");
        }

    }
}
