using System;
using System.Collections.Generic;
using Person;
namespace Lecturer
{
    public class Vykladach:Osoba
    {
        private List<string> disciplines = new List<string>();
        private Dictionary<string, int> popularityPerDiscipline = new Dictionary<string, int>();
        decimal avaragePopularity;

        public Vykladach()
        {
            Random rand = new Random();
            Console.WriteLine("Please, input name of the lecturer:");
            pIB = Console.ReadLine();
            dateOfBirth = new DateTime(rand.Next(1949, 1995), rand.Next(1, 13), rand.Next(1, 30));
            Console.WriteLine("Date of birth:{0}\n Age:{1}", GetDateOfBirth(), GetAge());
            SetDisciplines();
            OutputDisciplines();
            SetGrades();
            OutputGrades();
            avaragePopularity = CalculateRating();
        }
        protected override decimal CalculateRating()
        {
            decimal overall = 0;
            foreach (string discipline in disciplines)
            {
                overall += popularityPerDiscipline[discipline];
            }
            return overall / popularityPerDiscipline.Count;
        }
        private void SetGrades()
        {
            Random rand = new Random();
            foreach (string discipline in disciplines)
            {
                if (!popularityPerDiscipline.ContainsKey(discipline))
                {
                    popularityPerDiscipline.Add(discipline, rand.Next(0, 11));
                }
            }
        }
        public void OutputGrades()
        {
            Console.WriteLine("Grades of {0}:", pIB);
            foreach (string discipline in disciplines)
            {
                Console.WriteLine("\t-{0}:{1}", discipline.PadRight(12), popularityPerDiscipline[discipline]);
            }
        }
        private void SetDisciplines()
        {
            Console.WriteLine("Please, input your disciplines\n To exit, enter empty string");
            string temp;
            while ((temp = Console.ReadLine()) != "")
            {
                disciplines.Add(temp);
            }
        }

        public void OutputDisciplines()
        {
            Console.WriteLine("Disciplines of {0}:", pIB);
            foreach (string discipline in disciplines)
            {
                Console.WriteLine("\t-{0}", discipline);
            }
        }
        public string GetPopularity()
        {
            return String.Format("Rating of {0} is {1}", pIB, avaragePopularity.ToString());
        }
    }
}
