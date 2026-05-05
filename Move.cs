using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    // Represents one move from a starting square to a destination square.
    public class Move
    {
        public int Piece { get; set; }
        public int MoveFrom { get; set; }
        public int MoveTo { get; set; }
        public int MoveScore { get; set; }
    }
}

