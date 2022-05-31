using System;
using Lecturer;
using Student;
using System.Collections.Generic;
namespace OPLaba5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("Please, input n (number of students)");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Plese, input m (number of lecturers)");
            m = Convert.ToInt32(Console.ReadLine());
            StudentClass[] studenti = new StudentClass[n];
            Vykladach[] vikladachi = new Vykladach[m];
            InitAcademics(studenti, vikladachi);
            OutputRatings(studenti, vikladachi);
            OutputUnderageWithDebt(studenti);
        }
        public static void InitAcademics(StudentClass[] studenti, Vykladach[] vikladachi)
        {
            Console.WriteLine("Initiating creation of students");
            for (int i = 0; i < studenti.Length; i++)
            {
                studenti[i] = new StudentClass();
            }
            Console.WriteLine();
            Console.WriteLine("Intiating creation of lecturers");
            for (int i = 0; i < vikladachi.Length; i++)
            {
                vikladachi[i] = new Vykladach();
            }
            Console.WriteLine();
        }
        public static void OutputRatings(StudentClass[] studenti, Vykladach[] vikladachi)
        {
            Console.WriteLine("Ratings of students:");
            foreach(StudentClass stud in studenti)
            {
                Console.WriteLine("\t{0}", stud.GetRating());
            }
            Console.WriteLine();
            Console.WriteLine("Ratings of lecturers:");
            foreach (Vykladach lecturer in vikladachi)
            {
                Console.WriteLine("\t{0}", lecturer.GetPopularity());
            }
        }
        public static void OutputUnderageWithDebt(StudentClass[] studenti)
        {
            List<Tuple<StudentClass, String>> underagesAndInDebted = new List<Tuple<StudentClass, string>>();
            Console.WriteLine("Ages of students:");
            foreach(StudentClass stud in studenti)
            {
                Console.WriteLine("\t{0}: {1}",stud.GetName().PadLeft(12),stud.GetAge());
                if (stud.GetAge() < 18)
                {
                    var temp = stud.GetGrades();
                    foreach (String discipline in stud.GetDisciplines())
                    {
                        if (temp[discipline] < 60)
                        {
                            underagesAndInDebted.Add(Tuple.Create(stud,discipline));
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("And so, underage students with debt and one discipline that is indebted are:");
            if (underagesAndInDebted.Count == 0)
            {
                Console.WriteLine("Fortunately, none!");
            }
            else
            {
                foreach (var studentAndDiscipline in underagesAndInDebted)
                {
                    Console.WriteLine("{0}: {1}", studentAndDiscipline.Item1.GetName().PadLeft(12), studentAndDiscipline.Item2.PadLeft(12));
                }
                Console.WriteLine("Their number-{0}",underagesAndInDebted.Count);
            }
        }
    }
}
