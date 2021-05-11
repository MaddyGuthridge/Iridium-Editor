using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iridium_Editor.Types
{
    // Used to represent the point at which a MIDI object begins or happens
    struct MidiPos
    {
        public int Position { get; set; }

        public MidiPos(int pos)
        {
            Position = pos;
        }

        // Return the position in terms of ticks
        public int ticks()
        {
            return Position;
        }
    }
}
