using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    // Tracks where pieces are located so move generation does not need to scan all 64 squares every time.
    class PieceLocator
    {
        public const int LocationMask = 0b01111111;
        public const int ColourMask = 0b10000000;

        public static List<int> PawnLocations = new List<int>();
        public static List<int> KnightLocations = new List<int>();
        public static List<int> BishopLocations = new List<int>();
        public static List<int> RookLocations = new List<int>();
        public static List<int> QueenLocations = new List<int>();
        public static List<int> BKingLocation = new List<int> { 4 };
        public static List<int> WKingLocation = new List<int> { 60 };

        public static void Clear()
        {
            PawnLocations.Clear();
            KnightLocations.Clear();
            BishopLocations.Clear();
            RookLocations.Clear();
            QueenLocations.Clear();
            BKingLocation.Clear();
            WKingLocation.Clear();
        }
 
 
 
        public static List<int> GetLocationsOf(int piece)
        {
            // Non-king piece lists store both colours together, so colour is packed into the saved value.
            List<int> locationList = new List<int>();
            int colour = Piece.Colour(piece) == 8 ? 128 : 0;
            int type = Piece.Type(piece);

            if (type == Piece.King)
            {
                return colour == 128 ? WKingLocation : BKingLocation;
            }
            switch (type)
            {
                case Piece.Pawn:
                    locationList = PawnLocations;
                    break;
                case Piece.Knight:
                    locationList = KnightLocations;
                    break;
                case Piece.Bishop:
                    locationList = BishopLocations;
                    break;
                case Piece.Rook:
                    locationList = RookLocations;
                    break;
                case Piece.Queen:
                    locationList = QueenLocations;
                    break;
            }
            
            return searchList(locationList, colour);

        }
 
 
 
        public static List<int> searchList(List<int> locationList, int colour)
        {
            // Filters a shared piece list down to the requested side.
            List<int> locations = new List<int>();

            foreach(int location in locationList)
            {
                if ((location & ColourMask) == colour)
                {
                    locations.Add(location & LocationMask);
                }
            }

            

            return locations;
        }
 
 
 
        public static int GetPosEval()
        {
            // Simple material-based evaluation used by the bot.
            int PositionEval = 0;
            int WhitePieceTotal = 0;
            int BlackPieceTotal = 0;

            WhitePieceTotal += (searchList(PawnLocations, 128).Count() * 130);
            WhitePieceTotal += (searchList(KnightLocations, 128).Count() * 300);
            WhitePieceTotal += (searchList(BishopLocations, 128).Count() * 350);
            WhitePieceTotal += (searchList(RookLocations, 128).Count() * 500);
            WhitePieceTotal += (searchList(QueenLocations, 128).Count() * 900);
                               
            BlackPieceTotal += (searchList(PawnLocations, 0).Count() * 130);
            BlackPieceTotal += (searchList(KnightLocations, 0).Count() * 300);
            BlackPieceTotal += (searchList(BishopLocations, 0).Count() * 350);
            BlackPieceTotal += (searchList(RookLocations, 0).Count() * 500);
            BlackPieceTotal += (searchList(QueenLocations,0).Count() * 900);

            if(GameControl.CheckSideToMove() == 8)
            {
                PositionEval += WhitePieceTotal -= BlackPieceTotal;
            }
            else
            {
                PositionEval += BlackPieceTotal -= WhitePieceTotal;
            }

            return PositionEval;
        }
 
 
        public static void AddToList(int piece, int location)
        {
            // Kings are stored separately because there is only one per side and they are queried often.
            int colour = Piece.Colour(piece) == 8 ? 128 : 0;
            int type = Piece.Type(piece);
            int data = location + colour;

            switch (type)
            {
                case Piece.Pawn:
                    PawnLocations.Add(data);
                    break;
                case Piece.Knight:
                    KnightLocations.Add(data);
                    break;
                case Piece.Bishop:
                    BishopLocations.Add(data);
                    break;
                case Piece.Rook:
                    RookLocations.Add(data);
                    break;
                case Piece.Queen:
                    QueenLocations.Add(data);
                    break;
                case Piece.King:
                    if (colour == 128)
                    {
                        WKingLocation.Clear();
                        WKingLocation.Add(location);
                    }
                    else
                    {
                        BKingLocation.Clear();
                        BKingLocation.Add(location);
                    }
                    break;
            }
        }
 
 
        public static void RemoveFromList(int piece, int location)
        {
            int colour = Piece.Colour(piece) == 8 ? 128 : 0;
            int type = Piece.Type(piece);
            int data = location + colour;

            switch (type)
            {
                case Piece.Pawn:
                    PawnLocations.Remove(data);
                    break;
                case Piece.Knight:
                    KnightLocations.Remove(data);
                    break;
                case Piece.Bishop:
                    BishopLocations.Remove(data);
                    break;
                case Piece.Rook:
                    RookLocations.Remove(data);
                    break;
                case Piece.Queen:
                    QueenLocations.Remove(data);
                    break;
            }
        }
    }
}

