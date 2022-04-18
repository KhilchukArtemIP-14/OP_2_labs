using System;

namespace OP_laba2Library
{
    [Serializable]
    public struct Para
    {
        public string name, 
                      startTime,
                      endTime;
        public Para(string nazva, string start, string end)
        {
            name = nazva;
            startTime = start;
            endTime=end;
        }

        public void PrintOutData()
        {
                Console.Write(this.name.PadRight(24, '-'));
                Console.Write(this.startTime.PadRight(10, '-'));
                Console.Write(this.endTime);
                Console.WriteLine("\n");
        }
    }


}
