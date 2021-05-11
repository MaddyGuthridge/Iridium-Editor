using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Types
{
    // Used to represent the length of a MIDI object (eg note or phrase)
    struct MidiLength
    {
        public uint Length { get; set; }

        public MidiLength(uint ticks)
        {
            Length = ticks;
        }

        // Return length in terms of ticks
        public uint Ticks()
        {
            return Length;
        }
    }
}
