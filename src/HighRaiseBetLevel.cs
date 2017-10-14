using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class HighRaiseBetLevel : IBetLevel
    {
        public int FoldLevel { get; private set; }
        public int CallLevel { get; private set; }
        public int RaiseLevel { get; private set; }

        public HighRaiseBetLevel()
        {
            FoldLevel = 8;
            CallLevel = 9;
            RaiseLevel = 9;
        }
    }
}
