using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Midi;

namespace Music
{
    class MidiEvent
    {
        private byte[] buffer = new byte[3];
        private int channel;
        MidiOut midiOut = new MidiOut(0);

        protected void Send(byte channel, byte note, byte volume = 127)
        {
            midiOut.Volume = 65535;
            midiOut.SendBuffer(new byte[3] { channel, note, volume });
        }

        public void NoteOn(byte note, byte volume)
        {
            Send(0x90, note, volume);
        }

        public void NoteOff(byte note, byte volume)
        {
            Send(0x80, note, volume);
        }

        public void ProgramChange()
        {

        }
    }
}
