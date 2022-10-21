using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Notation
    {
        public int duration;
        public bool isChord;
        protected Notation(int pDuration, bool pIsChord)
        {
            duration = pDuration;
            isChord = pIsChord;
        }

        

        public override string ToString()
        {
            return $"Unknown music notation for {duration} beats";
        }
    }
}
