namespace Chess
{
    // Builds the standard starting position directly in code.
    public class BoardSetup
    {
        public const int StartingSide = Piece.White;

        private static readonly int[] StartingPieces =
        {
            Piece.Black | Piece.Rook, Piece.Black | Piece.Knight, Piece.Black | Piece.Bishop, Piece.Black | Piece.Queen,
            Piece.Black | Piece.King, Piece.Black | Piece.Bishop, Piece.Black | Piece.Knight, Piece.Black | Piece.Rook,
            Piece.Black | Piece.Pawn, Piece.Black | Piece.Pawn, Piece.Black | Piece.Pawn, Piece.Black | Piece.Pawn,
            Piece.Black | Piece.Pawn, Piece.Black | Piece.Pawn, Piece.Black | Piece.Pawn, Piece.Black | Piece.Pawn,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            Piece.White | Piece.Pawn, Piece.White | Piece.Pawn, Piece.White | Piece.Pawn, Piece.White | Piece.Pawn,
            Piece.White | Piece.Pawn, Piece.White | Piece.Pawn, Piece.White | Piece.Pawn, Piece.White | Piece.Pawn,
            Piece.White | Piece.Rook, Piece.White | Piece.Knight, Piece.White | Piece.Bishop, Piece.White | Piece.Queen,
            Piece.White | Piece.King, Piece.White | Piece.Bishop, Piece.White | Piece.Knight, Piece.White | Piece.Rook
        };

        public static void LoadStartingBoard()
        {
            // Reset piece-location lists, then copy the starting layout onto the board.
            PieceLocator.Clear();

            for (int square = 0; square < StartingPieces.Length; square++)
            {
                int piece = StartingPieces[square];
                GameControl.Board[square].PieceOnSquare = piece;
                GameControl.Board[square].Image = Piece.PieceToImage(piece);

                if (piece != 0)
                {
                    PieceLocator.AddToList(piece, square);
                }
            }
        }
    }
}

