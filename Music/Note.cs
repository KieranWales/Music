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
        public Note(int pTone, int pDuration, int pVolume = 127) : base(pDuration)
        {
            tone = pTone;
            volume = pVolume;
        }
    }
}
