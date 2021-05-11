using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iridium_Editor.Types
{
    // Used to represent the length of a MIDI object (eg note or phrase)
    struct MidiLength
    {
        public int Length { get; set; }

        public MidiLength(int ticks)
        {
            Length = ticks;
        }

        // Return length in terms of ticks
        public int ticks()
        {
            return Length;
        }
    }
}
