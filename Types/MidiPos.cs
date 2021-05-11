using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Types
{
    // Used to represent the point at which a MIDI object begins or happens
    struct MidiPos
    {
        public uint Position { get; set; }

        public MidiPos(uint pos)
        {
            Position = pos;
        }

        // Return the position in terms of ticks
        public uint Ticks()
        {
            return Position;
        }

        // Operator overloads
        // Damn this is not concise
        public static bool operator ==(MidiPos left, MidiPos right)
        {
            return left.Position == right.Position;
        }
        public static bool operator !=(MidiPos left, MidiPos right)
        {
            return !(left == right);
        }
        public static bool operator <(MidiPos left, MidiPos right)
        {
            return left.Position < right.Position;
        }
        public static bool operator >(MidiPos left, MidiPos right)
        {
            return left.Position > right.Position;
        }
        public static bool operator <=(MidiPos left, MidiPos right)
        {
            return !(left > right);
        }
        public static bool operator >=(MidiPos left, MidiPos right)
        {
            return !(left < right);
        }
    }
}
