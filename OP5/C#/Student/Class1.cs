using System;
using Person;
using System.Collections.Generic;
namespace Student
{
    public class StudentClass:Osoba
    {
        private string groupNumber;
        private decimal rating;

        private List<string> disciplinesOfLastSemestr= new List<string>();
        private Dictionary<string, int> gradesFromLastSemstr = new Dictionary<string, int>();

        public StudentClass()
        {
            Random rand = new Random();
            Console.WriteLine("Please, input name of the student:");
            pIB = Console.ReadLine();
            Console.WriteLine("Please, input his group");
            groupNumber = Console.ReadLine();
            dateOfBirth = new DateTime(rand.Next(2003,2006),rand.Next(1,13),rand.Next(1,30));
            Console.WriteLine("Date of birth:{0}\n Age:{1}", GetDateOfBirth(), GetAge());
            SetDisciplines();
            OutputDisciplines();
            SetGrades();
            OutputGrades();
            rating = CalculateRating();
        }
        protected override decimal CalculateRating()
        {
            decimal overall = 0;
            foreach (string discipline in disciplinesOfLastSemestr)
            {
                overall += gradesFromLastSemstr[discipline];
            }
            return overall / disciplinesOfLastSemestr.Count;
        }
        private void SetGrades()
        {
            Random rand = new Random();
            foreach (string discipline in disciplinesOfLastSemestr)
            {
                if (!gradesFromLastSemstr.ContainsKey(discipline))
                {
                    gradesFromLastSemstr.Add(discipline, rand.Next(40, 101));
                }
            }
        }
        public void OutputGrades()
        {
            Console.WriteLine("Grades of {0}:",pIB);
            foreach(string discipline in disciplinesOfLastSemestr)
            {
                Console.WriteLine("\t-{0}:{1}",discipline.PadRight(12),gradesFromLastSemstr[discipline]);
            }
        }
        private void SetDisciplines()
        {
            Console.WriteLine("Please, input your disciplines\n To exit, enter empty string");
            string temp;
            while ((temp = Console.ReadLine()) != "")
            {
                disciplinesOfLastSemestr.Add(temp);
            }
        }

        public void OutputDisciplines()
        {
            Console.WriteLine("Disciplines of {0}:", pIB);
            foreach (string discipline in disciplinesOfLastSemestr)
            {
                Console.WriteLine("\t-{0}", discipline);
            }
        }
        public string GetRating()
        {
            return String.Format("Rating of {0} is {1}",pIB,rating.ToString());
        }
        public List<string> GetDisciplines()
        {
            return disciplinesOfLastSemestr;
        }
        public Dictionary<string, int> GetGrades()
        {
            return gradesFromLastSemstr;
        }
    }
}
