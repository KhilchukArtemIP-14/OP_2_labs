using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

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
    }


}
