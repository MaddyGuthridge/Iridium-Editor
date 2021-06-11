
namespace IridiumEditor.Types
{
    // Used to represent a coordinate: (x, y)
    // where x is a MidiPos relative to the start of the parent object
    // and y is the vertical position in terms of tracks
    struct MidiCoord
    {
        // X coordinate
        public MidiPos X { get; set; }

        // Y coordinate (in terms of tracks)
        public uint Y { get; set; }

        public MidiCoord(MidiPos x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}
