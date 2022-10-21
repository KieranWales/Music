using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Note : Notation
    {
        public int tone;
        int volume;
        public Note(int pTone, int pDuration, bool pIsChord = false, int pVolume = 127) : base(pDuration, pIsChord)
        {
            tone = pTone;
            volume = pVolume;
        }

        public override string ToString()
        {
            return $"Note {tone} for {duration} beats";
        }

        public void Play(MidiEvent objMidi)
        {
            objMidi.NoteOn((byte)tone, 127);
            System.Threading.Thread.Sleep(duration * 1000);
            objMidi.NoteOff((byte)tone, 127);
        }
    }
}
