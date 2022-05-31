using System;

namespace Person
{
    public abstract class Osoba
    {
        protected string pIB;
        protected DateTime dateOfBirth;
        protected abstract decimal CalculateRating();
        public int GetAge()
        {
            return (DateTime.Now-dateOfBirth).Days/365;
        }
        public string GetName()
        {
            return pIB;
        }
        public string GetDateOfBirth()
        {
            return String.Format("{0:d2}.{1:d2}.{2}", dateOfBirth.Day, dateOfBirth.Month, dateOfBirth.Year);
        }
    }
}
