using System;
using System.Collections.Generic;
namespace TextAbstractionClass
{
    public class TText
    {
        private List<string> strings = new List<string>();

        public void AppendString(string str)
        {
            strings.Add(str);
        }

        public List<string> GetStrings()
        {
            return strings;
        }

        public TText()
        {
            string temp;
            while ((temp = Console.ReadLine()) != Convert.ToString('\u0002'))
            {
                strings.Add(temp);
            }
        }
        public string GetLongestString()
        {
            string longest = "";

            foreach(string str in strings)
            {
                if (str.Length > longest.Length)
                {
                    longest = str;
                }
            }
            return longest;
        }
    }
}
