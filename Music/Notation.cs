using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Notation
    {
        int duration;
        protected Notation(int pDuration)
        {
            duration = pDuration;
        }

        public void Play(MidiEvent objMidi)
        {
            objMidi.NoteOn(0x60, 127);
            System.Threading.Thread.Sleep(duration * 1000);
            objMidi.NoteOff(0x60, 127);
        }
    }
}
