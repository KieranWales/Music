using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class Song
    {
        List<Note> notes = new List<Note>();
        string fileName;
        public Song(string pFileName)
        {
            fileName = pFileName;
            SplitNotes();
        }

        private void SplitNotes()
        {
            List<string> stringNotes = (System.IO.File.ReadAllLines(fileName)).ToList();
            List<List <int>> intNotes = new List<List<int>>();
            foreach (string note in stringNotes)
            {
                string[] strings;
                string tempString = note.Remove(3, 1);
                strings = tempString.Split(',')
            }
        }

        public Play()
        {

        }
    }
}
