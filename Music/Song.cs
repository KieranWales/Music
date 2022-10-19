using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Music
{
    class Song
    {
        List<Notation> notes = new List<Notation>();
        List<string> typeNotes = new List<string> {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
        string fileName;
        MidiEvent notePlayer = new MidiEvent();
        int octave;
        
        public Song(string pFileName)
        {
            fileName = pFileName;
            SplitNotes();
        }

        private void SplitNotes()
        {
            bool flat = false;
            bool sharp = false;

            string contents = System.IO.File.ReadAllText(fileName);
            contents = Regex.Replace(contents, @"\/\/.*", "");
            foreach(Match m in Regex.Matches(contents, @"([A-G])([b#])*(\d)*(:(\d))*"))
            {
                string note = m.Groups[1].Value;
                int duration = 0;

                if (m.Groups[5].Value.Length > 0)
                {
                    duration = int.Parse(m.Groups[5].Value);
                }

                if(m.Groups[3].Value.Length > 0)
                {
                    octave = int.Parse(m.Groups[3].Value);
                }

                flat = m.Groups[2].Value == "b";
                sharp = m.Groups[2].Value == "#";
                int numNote = NoteToNumber(note[0], flat, sharp, octave);

                notes.Add(new Note(numNote, duration));

                Console.WriteLine($"Notes: {numNote} Octave: {octave}, Duration: {duration}");
            }

            /*List<string> stringNotes = contents.ToList();
            List<List <int>> intNotes = new List<List<int>>();
            int offset = 0;
            int noteNum;
            foreach (string note in stringNotes)
            {
                string[] strings;
                string[] tempStrings = new string[2];
                int[] ints = new int[2] {0, 0};
                strings = note.Split(',');
                if (strings[0] == "R")
                {
                    notes.Add(new Rest(int.Parse(strings[1])));
                }
                else
                {
                    if (strings[0].Length == 3)
                    {
                        tempStrings[0] = strings[0].Substring(0, 2);
                        tempStrings[1] = strings[0].Substring(2, 1);
                    }
                    else if (strings[0].Length == 2)
                    {
                        tempStrings[0] = strings[0][0].ToString();
                        tempStrings[1] = strings[0][1].ToString();
                    }

                    foreach (string typeNote in typeNotes)
                    {

                        if (tempStrings[0] == typeNote)
                        {
                            offset = typeNotes.IndexOf(typeNote);
                        }
                    }
                    noteNum = ((int.Parse(tempStrings[1]) + 1) * 12) + offset;
                    notes.Add(new Note(noteNum, int.Parse(strings[1])));
                }
            }*/
        }

        private int NoteToNumber(char noteName, bool flat, bool sharp, int octave)
        {
            int noteNumber = 0;
            switch (noteName)
            {
                case 'A':
                    noteNumber = 0;
                    break;
                case 'B':
                    noteNumber = 2;
                    break;
                case 'C':
                    noteNumber = 3;
                    break;
                case 'D':
                    noteNumber = 5;
                    break;
                case 'E':
                    noteNumber = 7;
                    break;
                case 'F':
                    noteNumber = 8;
                    break;
                case 'G':
                    noteNumber = 10;
                    break;
            }

            if (sharp)
            {
                noteNumber++;
            }
            if (flat)
            {
                noteNumber--;
            }

            return ((octave + 1) * 12) - 3 + noteNumber;
        }

        public void Play()
        {
            SplitNotes();
            foreach (Notation note in notes)
            {
                note.Play(notePlayer);
            }
        }
    }
}
