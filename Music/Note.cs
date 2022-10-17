using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Note : Notation
    {
        int tone;
        int volume;
        public Note(int pTone, int pVolume = 127, int pDuration) : base(pDuration)
        {
            tone = pTone;
            volume = pVolume;
        }
    }
}
