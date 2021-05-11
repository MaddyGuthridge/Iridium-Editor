using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IridiumEditor.Types
{
    // Two non-overlapping MidiCoord objects
    class MidiBox
    {
        // Throws an ArgumentException if the start and end values overlap
        private static void CheckOverlap(MidiCoord start, MidiCoord end)
        {
            if (start.X > end.X || start.Y > end.Y)
            {
                throw new ArgumentException("Start and end values overlap");
            }
        }

        // Returns true if two MidiBox objects are overlapping
        public static bool BoxesOverlap(MidiBox b1, MidiBox b2)
        {
            // If they don't overlap horizontally
            if (b1.End.X <= b2.Start.X || b2.End.X <= b1.Start.X)
            {
                return false;
            }
            // If they don't overlap vertically
            if (b1.End.Y <= b2.Start.Y || b2.End.Y <= b1.Start.Y)
            {
                return false;
            }

            // If we reach here, then they overlap
            return true;
        }
        
        // Create MidiBox object
        public MidiBox(MidiCoord start, MidiCoord end)
        {
            CheckOverlap(start, end);
            _start = start;
            _end = end;
        }

        // Start and End properties
        private MidiCoord _start;
        private MidiCoord _end;
        public MidiCoord Start
        {
            get { return _start; }
            set
            {
                CheckOverlap(value, End);
                _start = value;
            }
        }
        public MidiCoord End
        {
            get { return _end; }
            set
            {
                CheckOverlap(Start, value);
                _end = value;
            }
        }
    }
}
