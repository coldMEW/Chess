using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    // Stores the board index and the piece currently displayed on this tile.
    public class BoardSquare : PictureBox
    {
        public int SquareNumber { get; set; }
        public int PieceOnSquare { get; set; }
    }
}

