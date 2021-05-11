using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iridium_Editor.Models
{
    // Used to represent the length of a MIDI object (eg note or phrase)
    struct MidiLength
    {
        private int length;

        public MidiLength(int ticks)
        {
            length = ticks;
        }

        public int ticks()
        {
            return length;
        }
    }
}
