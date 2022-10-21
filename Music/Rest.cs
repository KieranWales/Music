using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Rest : Notation
    {
        public Rest(int pDuration, bool pIsChord = false) : base(pDuration, pIsChord)
        {

        }

        public override string ToString()
        {
            return $"Rest for {duration} beats";
        }

        public void Play(MidiEvent objMidi)
        {
            System.Threading.Thread.Sleep(duration * 1000);
        }
    }
}
